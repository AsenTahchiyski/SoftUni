﻿namespace HotelBookingSystem.Controllers
{
    using System;
    using System.Linq;
    using Infrastructure;
    using Interfaces;
    using Models;

    public class RoomsController : Controller
    {
        public RoomsController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        /// <summary>
        /// Adds new room to a specified venue.
        /// </summary>
        /// <param name="venueId">Id of the venue.</param>
        /// <param name="places">Places in the room.</param>
        /// <param name="pricePerDay">Price for stay in the room per day.</param>
        /// <returns>IView containing the result of the action.</returns>
        public IView Add(int venueId, int places, string pricePerDay) // BUG: parameter is passed as string, should be parsed to decimal
        {
            decimal pricePerDayDecimal = decimal.Parse(pricePerDay);
            this.Authorize(Roles.VenueAdmin);
            var venue = this.Data.RepositoryWithVenues.Get(venueId);
            
            // BUG: boolean statement inverted
            if (venue == null) 
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", venueId));
            }

            var newRoom = new Room(places, pricePerDayDecimal);
            venue.Rooms.Add(newRoom);
            this.Data.RepositoryWithRooms.Add(newRoom);
            return this.View(newRoom);
        }

        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            this.Authorize(Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            // BUG: comparator sign must be > not <
            if (startDate > endDate) 
            {
                throw new ArgumentException("The date range is invalid.");
            }

            room.AvailableDates.Add(new AvailableDate(startDate, endDate));
            return this.View(room);
        }

        public IView ViewBookings(int id)
        {
            this.Authorize(Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(id);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", id));
            }

            return this.View(room.Bookings);
        }

        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            if (endDate < startDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }

            var availablePeriod = room.AvailableDates
                .FirstOrDefault(d => d.StartDate <= startDate || d.EndDate >= endDate);
            if (availablePeriod == null)
            {
                throw new ArgumentException(string.Format("The room is not available to book in the period {0:dd.MM.yyyy} - {1:dd.MM.yyyy}.", startDate, endDate));
            }

            decimal totalPrice = (endDate - startDate).Days * room.PricePerDay;
            var booking = new Booking(CurrentUser, startDate, endDate, totalPrice, comments);
            room.Bookings.Add(booking);
            this.CurrentUser.Bookings.Add(booking);
            this.UpdateRoomAvailability(startDate, endDate, room, availablePeriod);
            return this.View(booking);
        }

        private void UpdateRoomAvailability(DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.StartDate, availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), availablePeriod.EndDate));
            }
        }
    }
}

namespace HotelBookingSystem.Views.Venues
{
    using System.Linq;
    using System.Text;
    using Infrastructure;
    using Models;

    public class Rooms : View
    {
        public Rooms(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("Available rooms for venue {0}:", venue.Name).AppendLine();
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available.");
            }
            else
            {
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" *[{0}] {1} places, ${2:F2} per day", room.Id, room.Places, room.PricePerDay).AppendLine(); // BUG: room id placeholder {} brackets were missing
                    if (!room.AvailableDates.Any())
                    {
                        viewResult.AppendLine("This room is not currently available.");
                    }
                    else
                    {
                        viewResult.AppendLine("Available dates:");

                        // PERFORMANCE: multiple orderby call not needed, moved before foreach
                        var dates = room.AvailableDates.OrderBy(datePair => datePair.EndDate);
                        foreach (var datePair in dates)
                        {
                            viewResult.AppendFormat(" - {0:dd.MM.yyyy} - {1:dd.MM.yyyy}", datePair.StartDate, datePair.EndDate).AppendLine(); // BUG: start and end dates were swapped
                        }
                    }
                }
            }
        }
    }
}

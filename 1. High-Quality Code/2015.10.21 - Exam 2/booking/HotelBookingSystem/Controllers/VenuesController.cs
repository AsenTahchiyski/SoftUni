namespace HotelBookingSystem.Controllers
{
    using Infrastructure;
    using Interfaces;
    using Models;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.RepositoryWithVenues.GetAll();
            return this.View(venues);
        }

        public IView Details(int id) // BUG: variable renamed from venueId to id so reflection finds proper parameter name in dictionary
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var venue = this.Data.RepositoryWithVenues.Get(id);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
            }

            return this.View(venue);
        }

        public IView Rooms(int id)
        {
            var venue = this.Data.RepositoryWithVenues.Get(id);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
            }

            return this.View(venue);
        }

        public IView Add(string name, string address, string description)
        {
            var newVenue = new Venue(name, address, description, CurrentUser);
            this.Data.RepositoryWithVenues.Add(newVenue);
            return this.View(newVenue);
        }
    }
}
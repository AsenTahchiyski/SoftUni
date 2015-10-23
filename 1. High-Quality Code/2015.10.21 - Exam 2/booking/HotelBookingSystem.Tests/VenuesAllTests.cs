namespace HotelBookingSystem.Tests
{
    using Controllers;
    using Data;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class VenuesAllTests
    {
        [TestMethod]
        public void VenuesAllThreeVenues_ShouldReturnCorrectResult()
        {
            // Arrange
            IHotelBookingSystemData data = new HotelBookingSystemData();
            User user = new User("test user", "password", Roles.User);
            VenuesController controller = new VenuesController(data, user);

            // Act
            controller.Add("venue name1", "Pernik", "test");
            controller.Add("venue name2", "Pernik", "test");
            controller.Add("venue name3", "Pernik", "test");
            IView view = controller.All();
            string result = view.Display();
            string expected = "*[1] venue name1, located at Pernik\r\nFree rooms: 0\r\n*[2] venue name2, located at Pernik\r\nFree rooms: 0\r\n*[3] venue name3, located at Pernik\r\nFree rooms: 0";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VenuesAllNoVenues_ShouldReturnCorrectResult()
        {
            // Arrange
            IHotelBookingSystemData data = new HotelBookingSystemData();
            User user = new User("test user", "password", Roles.User);
            VenuesController controller = new VenuesController(data, user);

            // Act
            IView view = controller.All();
            string result = view.Display();
            string expected = "There are currently no venues to show.";

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

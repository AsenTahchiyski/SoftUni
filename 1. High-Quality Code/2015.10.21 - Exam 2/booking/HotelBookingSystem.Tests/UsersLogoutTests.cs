namespace HotelBookingSystem.Tests
{
    using System;
    using Controllers;
    using Data;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class UsersLogoutTests
    {
        [TestMethod]
        public void UsersLogoutValidUser_ShouldReturnCorrectResult()
        {
            // Arrange
            IHotelBookingSystemData data = new HotelBookingSystemData();
            User user = new User("test user", "password", Roles.User);
            UsersController controller = new UsersController(data, user);

            // Act
            controller.CurrentUser = user;
            IView view = controller.Logout();
            string result = view.Display();
            string expected = "The user test user has logged out.";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UsersLogoutNoUserLogged_ShouldThrowExceptionWithCorrectMessage()
        {
            // Arrange
            IHotelBookingSystemData data = new HotelBookingSystemData();
            User user = new User("test user", "password", Roles.User);
            UsersController controller = new UsersController(data, user);

            // Act
            controller.CurrentUser = null;
            string result = string.Empty;
            try
            {
                IView view = controller.Logout();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            string expected = "There is no currently logged in user.";

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

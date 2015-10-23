namespace HotelBookingSystem.Tests
{
    using System;
    using Controllers;
    using Data;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;

    [TestClass]
    public class RoomsAddMockTests
    {
        [TestMethod]
        public void RoomsAddInvalidVenue_ShouldThrowExceptionWithCorrectMessage()
        {
            // Arrange
            Mock<IHotelBookingSystemData> dataMoq = new Mock<IHotelBookingSystemData>();
            User user = new User("test user", "password", Roles.User);
            RoomsController controller = new RoomsController(dataMoq as IHotelBookingSystemData, user);

            // Act
            string result = string.Empty;
            try
            {
                IView view = controller.Add(1, 1, "30.00");
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            string expected = "The currently logged in user doesn't have sufficient rights to perform this operation.";

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

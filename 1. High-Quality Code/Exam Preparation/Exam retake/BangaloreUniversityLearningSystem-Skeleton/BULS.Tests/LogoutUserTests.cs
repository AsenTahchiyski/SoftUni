namespace BULS.Tests
{
    using System;
    using BangaloreUniversityLearningSystem;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enumerations;
    using BangaloreUniversityLearningSystem.Exceptions;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class LogoutUserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), GlobalMessages.NoUserLogged)]
        public void TestLogoutWhileNotLoggedIn_ShouldThrowArgumentException()
        {
            // Arrange
            IBangaloreUniversityDatabase database = new BangaloreUniversityDatabase();
            UsersController controller = new UsersController(database, null);

            // Act
            controller.Logout();
        }

        [TestMethod]
        public void TestLogoutWhileLoggedIn_ShouldReturnCorrectResult()
        {
            // Arrange
            IBangaloreUniversityDatabase database = new BangaloreUniversityDatabase();
            User user = new User("test user", "password", Role.Student);
            UsersController controller = new UsersController(database, user);

            // Act
            IView view = controller.Logout();
            string reuslt = view.Display();

            // Assert
            Assert.AreEqual("User test user logged out successfully.", reuslt);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException), GlobalMessages.AuthorizationFailed)]
        public void TestLogoutWhileLoggedInWithIncorectRole_ShouldThrowAuthorizationFailedException()
        {
            // Arrange
            IBangaloreUniversityDatabase database = new BangaloreUniversityDatabase();
            User user = new User("test user", "password", Role.ForTestingPurposesOnly);
            UsersController controller = new UsersController(database, user);

            // Act
            controller.Logout();
        }
    }
}

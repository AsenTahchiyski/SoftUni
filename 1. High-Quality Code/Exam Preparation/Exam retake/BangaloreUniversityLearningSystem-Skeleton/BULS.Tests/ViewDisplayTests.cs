namespace BULS.Tests
{
    using BangaloreUniversityLearningSystem.Enumerations;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Views.Users;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ViewDisplayTests
    {
        [TestMethod]
        public void TestDisplayViewWithLogin_ShouldReturnCorrectResult()
        {
            // Arrange
            User testUser = new User("test user", "password", Role.Student);
            IView testView = new Login(testUser);
            
            // Act
            string result = testView.Display();

            // Assert
            Assert.AreEqual("User test user logged in successfully.", result);
        }

        [TestMethod]
        public void TestDisplayViewMockView_ShouldReturnCorrectResult()
        {
            // Arrange
            Mock<IView> mockView = new Mock<IView>();
            mockView.Setup(x => x.Display()).Returns("Mock successful.");

            // Act
            string result = mockView.Object.Display();

            // Assert
            Assert.AreEqual("Mock successful.", result);
        }
    }
}

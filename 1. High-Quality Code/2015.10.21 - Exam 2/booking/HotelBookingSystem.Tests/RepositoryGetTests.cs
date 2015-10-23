namespace HotelBookingSystem.Tests
{
    using Data;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class RepositoryGetTests
    {
        [TestMethod]
        public void RepositoryGetFromOneItem_ShouldReturnCorrectResult()
        {
            // Arrange
            IRepository<User> repository = new Repository<User>();
            User user = new User("test user", "password", Roles.User);
            repository.Add(user);

            // Act
            User foundUser = repository.Get(1);

            // Assert
            Assert.AreEqual(user, foundUser);
        }

        [TestMethod]
        public void RepositoryGetFromMultipleItems_ShouldReturnCorrectResult()
        {
            // Arrange
            IRepository<User> repository = new Repository<User>();
            User user1 = new User("test user1", "password", Roles.User);
            User user2 = new User("test user2", "password", Roles.User);
            User user3 = new User("test user3", "password", Roles.User);
            User user4 = new User("test user4", "password", Roles.User);
            User user5 = new User("test user5", "password", Roles.User);
            User user6 = new User("test user6", "password", Roles.User);
            User user7 = new User("test user7", "password", Roles.User);
            repository.Add(user1);
            repository.Add(user2);
            repository.Add(user3);
            repository.Add(user4);
            repository.Add(user5);
            repository.Add(user6);
            repository.Add(user7);

            // Act
            User foundUser = repository.Get(7);

            // Assert
            Assert.AreEqual(user7, foundUser);
        }

        [TestMethod]
        public void RepositoryGetFromEmpty_ShouldReturnNull()
        {
            // Arrange
            IRepository<User> repository = new Repository<User>();

            // Act
            User foundUser = repository.Get(1);

            // Assert
            Assert.AreEqual(null, foundUser);
        }

        [TestMethod]
        public void RepositoryGetInvalidIndex_ShouldReturnNull()
        {
            // Arrange
            IRepository<User> repository = new Repository<User>();
            User user = new User("test user", "password", Roles.User);
            repository.Add(user);

            // Act
            User foundUser = repository.Get(13);

            // Assert
            Assert.AreEqual(null, foundUser);
        }

        [TestMethod]
        public void RepositoryGetNegativeIndex_ShouldReturnNull()
        {
            // Arrange
            IRepository<User> repository = new Repository<User>();
            User user = new User("test user", "password", Roles.User);
            repository.Add(user);

            // Act
            User foundUser = repository.Get(-1);

            // Assert
            Assert.AreEqual(null, foundUser);
        }
    }
}

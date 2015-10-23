namespace BULS.Tests
{
    using System;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryGetIdTests
    {
        [TestMethod]
        public void TestAddAndSearchValidCourse()
        {
            // Arrange
            IRepository<Course> testRepo = new Repository<Course>();
            Course testCourse = new Course("test course");

            // Act
            testRepo.Add(testCourse);
            Course returnedCourse = testRepo.Get(1);

            // Assert
            Assert.AreEqual(testCourse, returnedCourse);
        }

        [TestMethod]
        public void TestEmptyRepository_ShouldReturnNullObject()
        {
            // Arrange
            IRepository<Course> testRepo = new Repository<Course>();

            // Act
            Course returnedCourse = testRepo.Get(1);

            // Assert
            Assert.AreEqual(returnedCourse, null);
        }

        [TestMethod]
        public void TestNonEmptyRepositoryIncorrectIndex_ShouldReturnNullObject()
        {
            // Arrange
            IRepository<Course> testRepo = new Repository<Course>();
            Course testCourse = new Course("test course");

            // Act
            testRepo.Add(testCourse);
            Course returnedCourse = testRepo.Get(2543242);

            // Assert
            Assert.AreEqual(returnedCourse, null);
        }

        [TestMethod]
        public void TestNonEmptyRepositoryNegativeIndex_ShouldReturnNullObject()
        {
            // Arrange
            IRepository<Course> testRepo = new Repository<Course>();
            Course testCourse = new Course("test course");

            // Act
            testRepo.Add(testCourse);
            Course returnedCourse = testRepo.Get(-1);

            // Assert
            Assert.AreEqual(returnedCourse, null);
        }

        [TestMethod]
        public void TestNonEmptyRepository_ShouldReturnCorrectObject()
        {
            // Arrange
            IRepository<Course> testRepo = new Repository<Course>();
            Course testCourse1 = new Course("test course1");
            Course testCourse2 = new Course("test course2");
            Course testCourse3 = new Course("test course3");
            Course testCourse4 = new Course("test course4");
            Course testCourse5 = new Course("test course5");
            Course testCourse6 = new Course("test course6");
            Course testCourse7 = new Course("test course7");
            Course testCourse8 = new Course("test course8");
            Course testCourse9 = new Course("test course9");
            Course testCourse10 = new Course("test course10");
            Course testCourse11 = new Course("test course11");
            Course testCourse12 = new Course("test course12");

            // Act
            testRepo.Add(testCourse1);
            testRepo.Add(testCourse2);
            testRepo.Add(testCourse3);
            testRepo.Add(testCourse4);
            testRepo.Add(testCourse5);
            testRepo.Add(testCourse6);
            testRepo.Add(testCourse7);
            testRepo.Add(testCourse8);
            testRepo.Add(testCourse9);
            testRepo.Add(testCourse10);
            testRepo.Add(testCourse11);
            testRepo.Add(testCourse12);
            Course returnedCourse = testRepo.Get(10);

            // Assert
            Assert.AreEqual(returnedCourse, testCourse10);
        }

        [TestMethod]
        public void TestNonEmptyRepositoryIndexIntMaxValue_ShouldReturnNullObject()
        {
            // Arrange
            IRepository<Course> testRepo = new Repository<Course>();
            Course testCourse = new Course("test course");

            // Act
            testRepo.Add(testCourse);
            Course returnedCourse = testRepo.Get(Int32.MaxValue);

            // Assert
            Assert.AreEqual(returnedCourse, null);
        }
    }
}

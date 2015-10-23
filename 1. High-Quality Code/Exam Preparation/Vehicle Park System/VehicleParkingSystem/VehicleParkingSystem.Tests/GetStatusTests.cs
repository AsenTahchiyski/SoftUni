namespace VehicleParkingSystem.Tests
{
    using System;
    using Controllers;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class GetStatusTests
    {
        [TestMethod]
        public void GetStatusEmptyParking_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);

            // Act
            string result = park.GetStatus();
            string expected = "Sector 1: 0 / 2 (0% full)\r\nSector 2: 0 / 2 (0% full)";

            // Assert
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void GetStatusOneVehicle_ShouldReturnCorrectResult()
        {
            // Arrange
            int totalSectors = 2;
            IVehiclePark park = new VehiclePark(totalSectors, 2);
            IVehicle car = new Car("CA1234CA", "Pesho", 3);

            // Act
            park.InsertVehicle(car, 1, 1, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.GetStatus();
            string expected = "Sector 1: 1 / 2 (50% full)\r\nSector 2: 0 / 2 (0% full)";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetStatusFullParking_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car1 = new Car("CA1234CA", "Pesho", 3);
            IVehicle car2 = new Car("CA1235CA", "Pesho", 3);
            IVehicle car3 = new Car("CA1236CA", "Pesho", 3);
            IVehicle car4 = new Car("CA1237CA", "Pesho", 3);

            // Act
            park.InsertVehicle(car1, 1, 1, new DateTime(2015, 10, 17, 10, 30, 0));
            park.InsertVehicle(car2, 1, 2, new DateTime(2015, 10, 17, 10, 30, 0));
            park.InsertVehicle(car3, 2, 1, new DateTime(2015, 10, 17, 10, 30, 0));
            park.InsertVehicle(car4, 2, 2, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.GetStatus();
            string expected = "Sector 1: 2 / 2 (100% full)\r\nSector 2: 2 / 2 (100% full)";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetStatusFullSingleSector_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car3 = new Car("CA1236CA", "Pesho", 3);
            IVehicle car4 = new Car("CA1237CA", "Pesho", 3);

            // Act
            park.InsertVehicle(car3, 2, 1, new DateTime(2015, 10, 17, 10, 30, 0));
            park.InsertVehicle(car4, 2, 2, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.GetStatus();
            string expected = "Sector 1: 0 / 2 (0% full)\r\nSector 2: 2 / 2 (100% full)";

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

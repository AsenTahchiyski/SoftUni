namespace VehicleParkingSystem.Tests
{
    using System;
    using Controllers;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class VehiclesByOwnerTests
    {
        [TestMethod]
        public void VehiclesByOwnerNoVehiclesEmptyPark_ShouldThrowExceptionWithCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string owner = "owner";

            // Act
            string expected = string.Format(GlobalMessages.NoVehiclesByOwner, owner);
            string result = string.Empty;
            try
            {
                park.FindVehiclesByOwner(owner);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehiclesByOwnerNoVehiclesNonEmptyPark_ShouldThrowExceptionWithCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string owner = "Pesho";
            IVehicle car = new Car("CA1234CA", owner, 3);
            park.InsertVehicle(car, 1, 1, new DateTime(2015, 10, 17, 13, 0, 0));

            // Act
            string expected = string.Format(GlobalMessages.NoVehiclesByOwner, "Gosho");
            string result = string.Empty;
            try
            {
                park.FindVehiclesByOwner("Gosho");
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehiclesByOwnerOneVehicle_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string owner = "Pesho";
            IVehicle car = new Car("CA1234CA", owner, 3);
            park.InsertVehicle(car, 1, 1, new DateTime(2015, 10, 17, 13, 0, 0));

            // Act
            string expected = string.Format(GlobalMessages.FindByLicense, car.GetType().Name, car.LicensePlate, owner, "(1,1)");
            string result = park.FindVehiclesByOwner(owner);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehiclesByOwnerMultipleDifferentVehicles_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string owner = "Pesho";
            IVehicle car1 = new Car("CA1234CA", owner, 3);
            IVehicle car2 = new Motorbike("CA1235CA", owner, 3);
            IVehicle car3 = new Truck("CA1236CA", owner, 3);
            IVehicle car4 = new Car("CA1237CA", owner, 3);
            park.InsertVehicle(car1, 1, 1, new DateTime(2015, 10, 17, 13, 0, 0));
            park.InsertVehicle(car2, 1, 2, new DateTime(2015, 10, 17, 13, 0, 0));
            park.InsertVehicle(car3, 2, 1, new DateTime(2015, 10, 17, 13, 0, 0));
            park.InsertVehicle(car4, 2, 2, new DateTime(2015, 10, 17, 13, 0, 0));

            // Act
            string expected = "Car [CA1234CA], owned by Pesho\nParked at (1,1)\r\nMotorbike [CA1235CA], owned by Pesho\nParked at (1,2)\r\nTruck [CA1236CA], owned by Pesho\nParked at (2,1)\r\nCar [CA1237CA], owned by Pesho\nParked at (2,2)";
            string result = park.FindVehiclesByOwner(owner);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehiclesByOwnerMultipleDifferentVehicles_ShouldReturnCorrectResultOrderedCorrectly()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string owner = "Pesho";
            IVehicle car1 = new Car("CA1234CA", owner, 3);
            IVehicle car2 = new Motorbike("CA1235CA", owner, 3);
            IVehicle car3 = new Truck("CA1236CA", owner, 3);
            IVehicle car4 = new Car("CA1237CA", owner, 3);
            park.InsertVehicle(car4, 1, 1, new DateTime(2015, 10, 17, 13, 0, 0));
            park.InsertVehicle(car3, 1, 2, new DateTime(2015, 10, 17, 13, 0, 0));
            park.InsertVehicle(car2, 2, 1, new DateTime(2015, 10, 17, 13, 0, 0));
            park.InsertVehicle(car1, 2, 2, new DateTime(2015, 10, 17, 13, 0, 0));

            // Act
            string expected = "Car [CA1234CA], owned by Pesho\nParked at (2,2)\r\nMotorbike [CA1235CA], owned by Pesho\nParked at (2,1)\r\nTruck [CA1236CA], owned by Pesho\nParked at (1,2)\r\nCar [CA1237CA], owned by Pesho\nParked at (1,1)";
            string result = park.FindVehiclesByOwner(owner);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

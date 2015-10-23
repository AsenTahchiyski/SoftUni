namespace VehicleParkingSystem.Tests
{
    using System;
    using Controllers;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class ExitVehicleTests
    {
        [TestMethod]
        public void VehicleExitExactlyOnTime_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.ExitVehicle(licensePlate, new DateTime(2015, 10, 17, 13, 30, 0), 6M);
            string expected = "********************\r\nCar [CA1234CA], owned by Pesho\nat place (1,1)\nRate: $6,00\nOvertime rate: $0,00\r\n--------------------\r\nTotal: $6,00\nPaid: $6,00\nChange: $0,00\r\n********************";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehicleExitOvertimeRoundLessThanHour_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.ExitVehicle(licensePlate, new DateTime(2015, 10, 17, 13, 40, 0), 6M);
            string expected = "********************\r\nCar [CA1234CA], owned by Pesho\nat place (1,1)\nRate: $6,00\nOvertime rate: $0,00\r\n--------------------\r\nTotal: $6,00\nPaid: $6,00\nChange: $0,00\r\n********************";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehicleExitOvertimeRoundOverHalfHour_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.ExitVehicle(licensePlate, new DateTime(2015, 10, 17, 14, 00, 0), 10M);
            string expected = "********************\r\nCar [CA1234CA], owned by Pesho\nat place (1,1)\nRate: $6,00\nOvertime rate: $3,50\r\n--------------------\r\nTotal: $9,50\nPaid: $10,00\nChange: $0,50\r\n********************";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehicleExitEarly_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.ExitVehicle(licensePlate, new DateTime(2015, 10, 17, 12, 30, 0), 6M);
            string expected = "********************\r\nCar [CA1234CA], owned by Pesho\nat place (1,1)\nRate: $6,00\nOvertime rate: $0,00\r\n--------------------\r\nTotal: $6,00\nPaid: $6,00\nChange: $0,00\r\n********************";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehicleExitOvertimeSmallChange_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.ExitVehicle(licensePlate, new DateTime(2015, 10, 17, 14, 30, 0), 10M);
            string expected = "********************\r\nCar [CA1234CA], owned by Pesho\nat place (1,1)\nRate: $6,00\nOvertime rate: $3,50\r\n--------------------\r\nTotal: $9,50\nPaid: $10,00\nChange: $0,50\r\n********************";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehicleExitOvertimeLargeChange_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.ExitVehicle(licensePlate, new DateTime(2015, 10, 17, 14, 30, 0), 5000M);
            string expected = "********************\r\nCar [CA1234CA], owned by Pesho\nat place (1,1)\nRate: $6,00\nOvertime rate: $3,50\r\n--------------------\r\nTotal: $9,50\nPaid: $5000,00\nChange: $4990,50\r\n********************";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehicleExitOvertimeTenDays_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = park.ExitVehicle(licensePlate, new DateTime(2015, 10, 27, 13, 30, 0), 5000M);
            string expected = "********************\r\nCar [CA1234CA], owned by Pesho\nat place (1,1)\nRate: $6,00\nOvertime rate: $840,00\r\n--------------------\r\nTotal: $846,00\nPaid: $5000,00\nChange: $4154,00\r\n********************";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehicleExit_ShouldBeRemovedFromPark()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            park.ExitVehicle(licensePlate, new DateTime(2015, 10, 17, 13, 30, 0), 6M);
            string result = string.Empty;
            try
            {
                park.FindVehicle(licensePlate);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            string expected = string.Format(GlobalMessages.VehicleNotPresent, licensePlate);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VehicleExitNonPresentLicensePlate_ShouldThrowExceptionWithCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            string licensePlate = "CA1234CA";
            IVehicle car = new Car(licensePlate, "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = string.Empty;
            try
            {
                park.ExitVehicle("CA1234CB", new DateTime(2015, 10, 17, 13, 30, 0), 6M);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            string expected = string.Format(GlobalMessages.VehicleNotPresent, "CA1234CB");

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

namespace VehicleParkingSystem.Tests
{
    using System;
    using System.Text;
    using Controllers;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class InsertVehicleTests
    {
        [TestMethod]
        public void InsertVehicleValidOperation_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car = new Car("CA1234CA", "Pesho", 3);
            int sector = 1;
            int place = 1;

            // Act
            string result = park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string parkPlace = string.Format("({0},{1})", sector, place);
            string expected = string.Format(GlobalMessages.VehicleParked, car.GetType().Name, parkPlace);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertVehicleWithExistingLicensePlate_ShouldThrowExceptionWithCorrectMessage()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car = new Car("CA1234CA", "Pesho", 3);
            int sector = 1;
            int place = 1;
            string result = string.Empty;
            string expected = string.Format(GlobalMessages.VehicleAlreadyParked, "CA1234CA");

            // Act
            park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            try
            {
                park.InsertVehicle(car, sector + 1, place + 1, new DateTime(2015, 10, 17, 10, 30, 0));
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertVehicleAtNonExistingSector_ShouldThrowExceptionWithCorrectMessage()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car = new Car("CA1234CA", "Pesho", 3);
            int sector = 3;
            int place = 1;
            string result = string.Empty;
            string expected = string.Format(GlobalMessages.NoSuchSector, sector);

            // Act
            try
            {
                park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertVehicleAtNegativeSector_ShouldThrowExceptionWithCorrectMessage()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car = new Car("CA1234CA", "Pesho", 3);
            int sector = -1;
            int place = 1;
            string result = string.Empty;
            string expected = string.Format(GlobalMessages.NoSuchSector, sector);

            // Act
            try
            {
                park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertVehicleAtNonExistingPlace_ShouldThrowExceptionWithCorrectMessage()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car = new Car("CA1234CA", "Pesho", 3);
            int sector = 1;
            int place = 3;
            string result = string.Empty;
            string expected = string.Format(GlobalMessages.NoSuchPlaceInSector, place, sector);

            // Act
            try
            {
                park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertVehicleAtNegativePlace_ShouldThrowExceptionWithCorrectMessage()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car = new Car("CA1234CA", "Pesho", 3);
            int sector = 1;
            int place = -1;
            string result = string.Empty;
            string expected = string.Format(GlobalMessages.NoSuchPlaceInSector, place, sector);

            // Act
            try
            {
                park.InsertVehicle(car, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertVehicleAtOccupiedSpace_ShouldThrowExceptionWithCorrectMessage()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 2);
            IVehicle car1 = new Car("CA1234CA", "Pesho", 3);
            IVehicle car2 = new Car("CA1235CA", "Pesho", 3);
            int sector = 1;
            int place = 1;
            string parkPlace = string.Format("({0},{1})", sector, place);
            string expected = string.Format(GlobalMessages.PlaceIsOccupied, parkPlace);

            // Act
            park.InsertVehicle(car1, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            string result = string.Empty;
            try
            {
                park.InsertVehicle(car2, sector, place, new DateTime(2015, 10, 17, 10, 30, 0));
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertMultipleVehicleValidOperation_ShouldReturnCorrectResult()
        {
            // Arrange
            IVehiclePark park = new VehiclePark(2, 3);
            IVehicle car1 = new Car("CA1234CA", "Pesho", 3);
            IVehicle car2 = new Car("CA1235CA", "Pesho", 3);
            IVehicle car3 = new Car("CA1236CA", "Pesho", 3);
            IVehicle car4 = new Car("CA1237CA", "Pesho", 3);
            IVehicle car5 = new Car("CA1238CA", "Pesho", 3);
            IVehicle car6 = new Car("CA1239CA", "Pesho", 3);
            StringBuilder result = new StringBuilder();
            StringBuilder expected = new StringBuilder();

            // Act
            result.AppendLine(park.InsertVehicle(car1, 1, 1, new DateTime(2015, 10, 17, 10, 30, 0)));
            result.AppendLine(park.InsertVehicle(car2, 1, 2, new DateTime(2015, 10, 17, 10, 30, 0)));
            result.AppendLine(park.InsertVehicle(car3, 1, 3, new DateTime(2015, 10, 17, 10, 30, 0)));
            result.AppendLine(park.InsertVehicle(car4, 2, 1, new DateTime(2015, 10, 17, 10, 30, 0)));
            result.AppendLine(park.InsertVehicle(car5, 2, 2, new DateTime(2015, 10, 17, 10, 30, 0)));
            result.AppendLine(park.InsertVehicle(car6, 2, 3, new DateTime(2015, 10, 17, 10, 30, 0)));

            expected.AppendLine(string.Format(GlobalMessages.VehicleParked, car1.GetType().Name, "(1,1)"));
            expected.AppendLine(string.Format(GlobalMessages.VehicleParked, car1.GetType().Name, "(1,2)"));
            expected.AppendLine(string.Format(GlobalMessages.VehicleParked, car1.GetType().Name, "(1,3)"));
            expected.AppendLine(string.Format(GlobalMessages.VehicleParked, car1.GetType().Name, "(2,1)"));
            expected.AppendLine(string.Format(GlobalMessages.VehicleParked, car1.GetType().Name, "(2,2)"));
            expected.AppendLine(string.Format(GlobalMessages.VehicleParked, car1.GetType().Name, "(2,3)"));

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
    }
}

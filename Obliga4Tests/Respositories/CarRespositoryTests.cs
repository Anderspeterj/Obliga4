using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obliga4.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars;


namespace Obliga4.Respository.Tests
{
    [TestClass()]
    public class CarRepositoryTests
    {
        private CarRespository? _respository;

        [TestInitialize]
        public void TestInitialize()
        {
            _respository = new CarRespository();
        }

        [TestMethod()]
        public void GetCarsTest()
        {

            var expectedCount = 3;


            var testResult = _respository.GetCars();


            Assert.IsNotNull(testResult);
            Assert.AreEqual(expectedCount, testResult.Count);
        }

        [TestMethod()]
        public void GetCarByIdTest()
        {
            var existingCarId = 1;


            var testResult = _respository.GetCarById(existingCarId);


            Assert.IsNotNull(testResult);
            Assert.AreEqual(existingCarId, testResult.Id);
        }

        [TestMethod()]
        public void AddCarTest()
        {
            var newCar = new Car { LicensePlate = "ac5462", Model = "BMW", Price = 276.520 };


            var testResult = _respository.AddCar(newCar);

            Assert.IsNotNull(testResult);
            Assert.AreEqual(4, _respository.GetCars().Count);
        }
    }
}
using Obliga4;
using Cars;
using Obliga4.Controllers;

namespace Obliga4.Respository
{
    public class CarRespository
    {
        private int _nextID;
        private List<Car> _cars;


        public CarRespository()
        {
            _nextID = 1;
            _cars = new List<Car>()
            {
                new Car(){Id = _nextID++, LicensePlate = "ac467", Model = "Tesla", Price = 330.000},
                new Car(){Id = _nextID++, LicensePlate = "ba467", Model = "Mercedes", Price = 470.000},
                new Car(){Id = _nextID++, LicensePlate = "ta467", Model = "Fiat", Price = 170.000},
            };
        }

        public List<Car> GetCars()
        {
            List<Car> result = new List<Car>(_cars);
            return result;
        }

        public Car? GetCarById(int id)
        {
            return _cars.Find(x => x.Id == id);
        }

        public Car AddCar(Car newCar)
        {
            newCar.Id = _nextID++;
            _cars.Add(newCar);
            return newCar;
        }

        public Car? DeleteCar(int id)
        {
            Car foundcar = GetCarById(id);
            if (foundcar != null)
            {
                return null;
            }
            _cars.Remove(foundcar);
            return foundcar;
        }

        public Car? UpdateCar(int id, Car updates)
        {
            Car FoundCar = GetCarById(id);

            if (FoundCar != null)
            {
                return null;
            }

            FoundCar.LicensePlate = updates.LicensePlate;
            FoundCar.Model = updates.Model;
            FoundCar.Price = updates.Price;


            return FoundCar;
        }
    }
}

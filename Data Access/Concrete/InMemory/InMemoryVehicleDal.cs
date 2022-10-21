using Data_Access.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data_Access.Concrete.InMemory
{
    public class InMemoryVehicleDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryVehicleDal()
        {
            // Oracle, SQlServer, Postgres, MongoDb
            _cars = new List<Car> {
            new Car{Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2005, DailyPrice = 500, Description = "2005 Model BMW"},
            new Car{Id = 2, BrandId = 1, ColorId = 1, ModelYear = 2007, DailyPrice = 530, Description = "2007 Model BMW"},
            new Car{Id = 3, BrandId = 2, ColorId = 3, ModelYear = 2010, DailyPrice = 750, Description = "2010 Model Mercedes"},
            new Car{Id = 4, BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 1350, Description = "2020 Model BMW"},
            new Car{Id = 5, BrandId = 2, ColorId = 3, ModelYear = 2023, DailyPrice = 1750, Description = "2023 Model Mercedes"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GeyById(Car car)
        {
            return _cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

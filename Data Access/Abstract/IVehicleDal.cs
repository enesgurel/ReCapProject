using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Abstract
{
    public interface IVehicleDal
    {
        Car GeyById(Car car);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}

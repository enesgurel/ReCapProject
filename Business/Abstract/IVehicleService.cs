using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        List<Car> GetAll();
        Car GetById(Car car);
    }
}

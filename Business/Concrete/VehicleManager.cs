using Business.Abstract;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;

        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public List<Car> GetAll()
        {
            // iş kodları
            // yetki sorgulaması
            return _vehicleDal.GetAll();
        }

        public Car GetById(Car car)
        {
            // iş kodları
            // yetki sorgulaması
            return _vehicleDal.GeyById(car);
        }
    }
}

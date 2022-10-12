using Business.Concrete;
using Data_Access.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            VehicleManager vehicleManager = new VehicleManager(new InMemoryVehicleDal());

            foreach (var vehicle in vehicleManager.GetAll())
            {
                Console.WriteLine(vehicle.Description);
            }
        }
    }
}

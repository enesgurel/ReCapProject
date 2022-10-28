using Business.Concrete;
using Business.Constans;
using Data_Access.Concrete.EntityFramework;
using Data_Access.Concrete.InMemory;
using System;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //RentalTest();

            UserManager userManager = new UserManager(new EfUserDal());

            User user1 = new User();
            user1.Id = 2;
            user1.FirstName = "test";
            user1.LastName = "test1";
            user1.Email = "Test1";
            user1.Password = "1345";

            userManager.Add(user1);

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetAll();

            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.RentDate);
                }
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarTest()
        {
            CarManager vehicleManager = new CarManager(new EfCarDal());

            var result = vehicleManager.GetCarDetails();
            if (result.Success)
            {
                Console.WriteLine(result.Success);
                //foreach (var car in result.Data)
                //{
                //    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                //}
            }            
        }
    }
}

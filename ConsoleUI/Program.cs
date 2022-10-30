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

            AddUserTest();

            //CustomerTest();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();

            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
        }

        private static void AddUserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            User user1 = new User();
            user1.Id = 4;
            user1.FirstName = "Test";
            user1.LastName = "test2";
            user1.Email = "test@gmail.com";
            user1.Password = "1345";

            var result = userManager.Add(user1);
            
            if (result.Success)
            {
                Console.WriteLine(Messages.UserAdded);
            }
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
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.Description);
                }
            }            
        }
    }
}

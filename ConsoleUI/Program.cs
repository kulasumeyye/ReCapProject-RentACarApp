using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            // CarTest();
            // BrandTest();
            // ColorTest();

            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { Id = 2, FirstName = "Deniz",LastName = "Çalışkan",Email ="deniz@gmail.com",Password="12345"});
            //userManager.Add(new User { Id = 3, FirstName = "Mert",LastName = "Kaya",Email ="kayamert@gmail.com",Password="12345"});

            RentalTest();

        }

        private static void RentalTest()
        {
            /*RentalManager rentalManager = new RentalManager(new EfRentalDal(),new EfCustomerDal(),new EfCarDal());

            var result = rentalManager.GetAllRentalDetail();
            if (result.Success == true)
            {

                foreach (var rentalDetail in result.Data)
                {
                    Console.WriteLine(rentalDetail.FirstName + "\t" + rentalDetail.LastName + "\t"
                        + rentalDetail.CarName + "\t" + rentalDetail.DailyPrice + "\t"
                        + rentalDetail.RentDate + "\t" + rentalDetail.ReturnDate + "\t");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }*/
        }

            private static void CarTest()
        {

            CarManager carManager = new CarManager(new EfCarDal());
       
            Console.WriteLine("---Arabalar---");

            //carManager.Add(new Car { Id = 8, BrandId = 1, ColorId = 2, DailyPrice = 100000, Description = "Clio", ModelYear = 2000 });
            //carManager.Delete(new Car { Id = 8, BrandId = 1, ColorId = 2, DailyPrice = 100000, Description = "Clio", ModelYear = 2000 });
            //carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 100000, Description = "Clio", ModelYear = 2000 });
            //carManager.Update(new Car { Id = 5, BrandId = 0, ColorId = 0, DailyPrice = 100000, Description = "Dacia Duster", ModelYear = 2000 });
            foreach (var c in carManager.GetAll().Data)
            {
                Console.WriteLine(c.Description);
            }
            Console.WriteLine("2 id li araba : " + carManager.GetById(2).Data.Description);
            Console.WriteLine();



            // GetCarsByBrandId
            Console.WriteLine("---0 Marka Idli Arabalar---");
            foreach (var brandIdCar in carManager.GetCarsByBrand(0).Data)
            {
                Console.WriteLine(brandIdCar.CarName);
            }
            Console.WriteLine();


            // GetCarsByColorId
            Console.WriteLine("---0 Renk Idli Arabalar---");
            foreach (var colorIdCar in carManager.GetCarsByColor(2).Data)
            {
                Console.WriteLine(colorIdCar.CarName);
            }
            Console.WriteLine();
            //CarName, BrandName, ColorName, DailyPrice listelenmesi
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var carDetail in result.Data)
                {
                    Console.WriteLine(carDetail.CarName + "\t" + carDetail.BrandName + "\t" + carDetail.ColorName + "\t" + carDetail.DailyPrice + "\t");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("---Renkler---");
            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("0 id li renk : " + colorManager.GetById(0).Data.Name);
            Console.WriteLine();

        }

        private static void BrandTest()
        {

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("---Markalar---");

            foreach (var b in brandManager.GetAll().Data)
            {
                Console.WriteLine(b.Name);
            }
            Console.WriteLine("0 id li marka : " + brandManager.GetById(0).Data.Name);

            Console.WriteLine();


        }
    }
}

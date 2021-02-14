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
            Console.WriteLine("***********Araç Kiralama Sistemine Hoşgeldiniz***********");
            Console.WriteLine("*********************************************************");


            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 2, 13),
                ReturnDate = new DateTime(2021, 2,25)
            });
            Console.WriteLine(result.Message);
           
                













            /*CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if(result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }*/








            /*CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("-------------------GetAll()-------------------------");

            foreach (var c in carManager.GetAll() )
            {
                Console.WriteLine("CarBrandId:{0} CarColorId:{1} CarDailyPrice:{2} CarModelYear: {3} CarDescription:{4} ",c.BrandId,c.ColorId,c.DailyPrice,c.ModelYear,c.Description);
            }

            Console.WriteLine("-------------------Add()-------------------------");
            Car car = new Car { Id = 5, BrandId = 1, ColorId = 4, DailyPrice = 500, ModelYear = 2015, Description = "Car5" };
            carManager.Add(car);

            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine("CarBrandId:{0} CarColorId:{1} CarDailyPrice:{2} CarModelYear: {3} CarDescription:{4} ", c.BrandId, c.ColorId, c.DailyPrice,c.ModelYear, c.Description);
            }

            Console.WriteLine("-------------------GetById()-------------------------");
            var result = carManager.GetById(2);
            foreach (var r in result)
            {
                Console.WriteLine("CarBrandId:{0} CarColorId:{1} CarDailyPrice:{2} CarModelYear: {3} CarDescription:{4} ",r.BrandId,r.BrandId, r.DailyPrice,r.ModelYear,r.Description);
            }

            Console.WriteLine("-------------------Update()-------------------------");
            Car carUpdate = new Car { 
            Id=4,
            BrandId=6,
            ColorId=4,
            ModelYear=2019,
            DailyPrice=300,
            Description="Car4"
            };
            carManager.Update(carUpdate);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine("CarBrandId:{0} CarColorId:{1} CarDailyPrice:{2} CarModelYear: {3} CarDescription:{4} ", c.BrandId, c.ColorId, c.DailyPrice, c.ModelYear, c.Description);
            }

            Console.WriteLine("-------------------Delete()-------------------------");
            carManager.Delete(car);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine("CarBrandId:{0} CarColorId:{1} CarDailyPrice:{2} CarModelYear: {3} CarDescription:{4} ", c.BrandId, c.ColorId, c.DailyPrice, c.ModelYear, c.Description);
            }

           Car car1 = new Car
           {
               Id = 2,
               BrandId = 2,
               ColorId = 2,
               DailyPrice = 100,
               ModelYear = 2020,
               Description = "Araba2"

           };
          Console.WriteLine("--------------EntityFramework-------------------");
           CarManager carManager = new CarManager(new EfCarDal());
           carManager.Add(car1);
           foreach (var car in carManager.GetAll())
           {
               Console.WriteLine(car.Description);
           }


          Console.WriteLine("--------------EntityFramework+Core-------------------");
          CarManager carManager = new CarManager(new EfCarDal());
          foreach (var car in carManager.GetCarDetails())
          {
              Console.WriteLine("{0}---{1}---{2}---{3}",car.ColorName,car.BrandName,car.DailyPrice,car.Description);
          }

          ModelManager modelManager = new ModelManager();
          modelManager.Add(new Model { Id = 1, ModelNo = 2019 });

          ColorManager colorManager = new ColorManager();
          colorManager.Add(new Color
          {
              Id = 6,
              Name = "Gray"
          });*/






        }

    }
}

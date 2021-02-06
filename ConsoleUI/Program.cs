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
            /*  CarManager carManager = new CarManager(new InMemoryCarDal());

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
            */
            Car car1 = new Car
            {
                Id = 2,
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 100,
                ModelYear = 2020,
                Description = "Araba2"

            };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}

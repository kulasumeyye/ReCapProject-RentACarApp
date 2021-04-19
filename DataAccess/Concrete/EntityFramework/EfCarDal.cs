using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarByBrand(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             select new CarDetailDto
                             {
                                 BrandName = brand.Name,
                                 CarName = car.Description,
                                 CarId = car.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 FindexPoint=car.FindexPoint
                             };
                return result.Where(c => c.BrandId == id).ToList();
            }
        }

        public List<CarDetailDto> GetCarByColor(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id  
                             select new CarDetailDto
                             {
                                 BrandName = brand.Name,
                                 CarName = car.Description,
                                 CarId = car.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 FindexPoint = car.FindexPoint
                             };
                return result.Where(c => c.ColorId == id).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             select new CarDetailDto
                             {
                                 BrandName = brand.Name,
                                 CarName = car.Description,
                                 CarId = car.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 FindexPoint = car.FindexPoint
                             };
                return result.ToList();
            }
        }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetail()
        {
                using (RentACarContext context = new RentACarContext())
                {
                    var result = from rental in context.Rentals
                                 join car in context.Cars
                                 on rental.CarId equals car.Id
                                 join customer in context.Customers
                                 on rental.CustomerId equals customer.Id
                                 join user in context.Users
                                 on customer.UserId equals user.Id
                                 join brand in context.Brands
                                 on car.BrandId equals brand.Id
                                 select new RentalDetailDto
                                 {
                                     FirstName = user.FirstName,
                                     LastName = user.LastName,
                                     CarName = car.Description,
                                     CarId = car.Id,
                                     DailyPrice = car.DailyPrice,
                                     ReturnDate = rental.ReturnDate,
                                     RentDate = rental.RentDate,
                                     BrandName = brand.Name,
                                     CarFindexPoint=car.FindexPoint,
                                     CustomerFindexPoint=customer.FindexPoint,
                                     UserId = user.Id
                                 };
                    return result.ToList();
                }
            
        }

        public List<RentalDetailDto> UserRentedCars(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             select new RentalDetailDto
                             {
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CarName = car.Description,
                                 CarId = car.Id,
                                 DailyPrice = car.DailyPrice,
                                 ReturnDate = rental.ReturnDate,
                                 RentDate = rental.RentDate,
                                 BrandName = brand.Name,
                                 CarFindexPoint = car.FindexPoint,
                                 CustomerFindexPoint = customer.FindexPoint,
                                 UserId = user.Id
                             };
                return result.Where(r => r.UserId == id).ToList();
            }
        }
        public Rental LastRentalCar()
        {
            using (RentACarContext context = new RentACarContext())
            {
               
                return context.Rentals.OrderByDescending(u => u.Id).FirstOrDefault();
            }
        }

        public  int RentalControl(Rental rental)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = context.Rentals.Where(r => r.CarId == rental.CarId && r.ReturnDate == rental.ReturnDate).Count();
                if (result > 0)
                {
                    return result;
                }
                return 0;
            }

        }
    }
}

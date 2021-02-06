using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length>2&&car.DailyPrice>0)
            {
                _carDal.Add(car);

            }
            else
            {
                Console.WriteLine("Araba ismi 2 karakterden küçük ve günlük fiyatı 0 dan büyük olmalıdır.");
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //İş kodları/ kontroller
           
            return _carDal.GetAll();
        }

   
        public List<Car> GetCarsBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        

        public List<Car> GetCarsColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

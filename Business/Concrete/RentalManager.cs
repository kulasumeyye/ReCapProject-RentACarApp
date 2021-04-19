using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerService _customerService;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICustomerService customerService,ICarService carService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
        }


        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(FindeksScoreCheck(rental.CustomerId, rental.CarId));
            if (result != null)
            {

                return result;
            }
            _rentalDal.Add(rental);
             return new SuccessResult(Messages.RentalAdded);
        }


        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }


        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
             _rentalDal.Update(rental);
             return new SuccessResult(Messages.RentalUpdated);
        }


        [CacheAspect] //key,value
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalGetAll);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }
        [PerformanceAspect(5)]
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetail(), Messages.UserRentals);
        }

        [PerformanceAspect(5)]
        public IDataResult<List<RentalDetailDto>> UserRentedCars(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.UserRentedCars(id));
        }

        [CacheAspect] //key,value
        public IDataResult<Rental> LastRentalCar()
        {
            return new SuccessDataResult<Rental>(_rentalDal.LastRentalCar());
        }


        public IResult RentalControl(Rental rental)
        {
            int control = _rentalDal.RentalControl(rental);
            if (control > 0 )
            {
                return new ErrorResult(Messages.RentalControlError);
            }
            return new SuccessResult(Messages.RentalControlSucces);
        }

        private IResult FindeksScoreCheck(int customerId, int carId)
        {
            var customer = _customerService.GetById(customerId).Data;

            if (customer.FindexPoint >= 0 && customer.FindexPoint <= 1900) {

                var car = _carService.GetById(carId).Data;

                if (car.FindexPoint > customer.FindexPoint)
                {
                    return new ErrorResult(Messages.CustomerScoreIsInsufficient);
                }
                else
                {
                    customer.FindexPoint = customer.FindexPoint - car.FindexPoint;
                    _customerService.Update(customer);
                    _carService.Update(car);
                    return new SuccessResult();
                }

            }
            else
            {
                return new ErrorResult(Messages.NotCustomerFindexPoint);
            }


        }
    }
}

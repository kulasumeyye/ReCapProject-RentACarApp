using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetAllRentalDetail();
        IDataResult<List<RentalDetailDto>> UserRentedCars(int id);
        IDataResult<Rental> GetById(int id);

        IResult RentalControl(Rental rental);

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

        IDataResult<Rental> LastRentalCar();
    }
}

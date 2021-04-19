using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {

        List<RentalDetailDto> GetAllRentalDetail();

        Rental LastRentalCar();

        int RentalControl(Rental rental);

        List<RentalDetailDto> UserRentedCars(int id);
    }
}

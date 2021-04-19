using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {

        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarByColor(int id);
        List<CarDetailDto> GetCarByBrand(int id);

    }
}

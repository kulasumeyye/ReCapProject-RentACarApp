﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int Id);
        IDataResult<CarImage> GetById(int imageId);
        IResult Add(CarImage image, IFormFile file);
        IResult Update(CarImage image, IFormFile file);
        IResult Delete(CarImage image);
    }
}

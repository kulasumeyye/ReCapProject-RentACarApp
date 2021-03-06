using Business.Abstract;
using Business.Constants;
using Business.Constants.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Business;
using Core.Utilities.Herper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage image, IFormFile file)
        {
            var result = BusinessRules.Run(
                CheckIfCarImageCountOfCarCorrect(image.CarId));
            if (result != null) return result;

            image.ImagePath = new ImageFileHelper().Add(file, CreateNewPath(file));
            image.Date = DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Delete(CarImage image)
        {
            new ImageFileHelper().Delete(image.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult();
        }
        public IResult Update(CarImage image, IFormFile file)
        {
            var carImageToUpdate = _carImageDal.Get(c => c.Id == image.Id);
            image.CarId = carImageToUpdate.CarId;
            image.ImagePath = new ImageFileHelper().Update(carImageToUpdate.ImagePath, file, CreateNewPath(file));
            image.Date = DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());

        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int Id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == Id));
        }
        private void IfCarImageOfCarNotExistsAddDefault(List<CarImage> result, int carId)
        {
            if (!result.Any())
            {
                var defaultCarImage = new CarImage
                {
                    CarId = carId,
                    ImagePath =
                        $@"{Environment.CurrentDirectory}\Public\CarImages\default.jpg",
                    Date = DateTime.Now
                };
                result.Add(defaultCarImage);
            }
        }

        private string CreateNewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var newPath =
                $@"{Environment.CurrentDirectory}\Public\CarImages\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

            return newPath;
        }

        private IResult CheckIfCarImageCountOfCarCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.CarImageCountOfCarError);
            return new SuccessResult();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Data_Access.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public Result Add(IFormFile imageFile, CarImage carImage)
        {
            var ruleResult = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));

            if (ruleResult != null)
            {
                return new ErrorResult(ruleResult.Message);
            }

            // Adding Image
            var imageResult = FileHelper.Add(imageFile);
            carImage.ImagePath = imageResult.Message;
            
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            _carImageDal.Add(carImage);
            return new SuccesResult(Messages.CarImageAdded);
        }

        public IResult Update(IFormFile imageFile, CarImage carImage)
        {
            var carToBeUpdated = _carImageDal.Get(c => c.Id == carImage.Id);

            if (carToBeUpdated == null)
            {
                return new ErrorResult(Messages.CarImageDoesNotFound);
            }

            var imageResult = FileHelper.Update(imageFile, carToBeUpdated.ImagePath);
            carImage.ImagePath = imageResult.Message;

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            _carImageDal.Update(carImage);
            return new SuccesResult(Messages.CarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            var carToBeDeleted = _carImageDal.Get(c => c.Id == carImage.Id);
            if (carToBeDeleted == null)
            {
                return new ErrorResult(Messages.CarImageDoesNotFound);
            }
            FileHelper.Delete(carToBeDeleted.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccesResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var data = _carImageDal.GetAll(cI=>cI.CarId == carId);
            if (data.Count == 0)
            {
                data.Add(new CarImage
                {
                    CarId = carId,
                    ImagePath = "/Images/default.jpg"

                });
            }

            return new SuccessDataResult<List<CarImage>>(data);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(cI => cI.Id == carImageId));
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImagesOfTheCar = _carImageDal.GetAll(p => p.CarId == carId);

            if (carImagesOfTheCar.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccesResult();
        }
    }
}

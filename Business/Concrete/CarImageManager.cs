using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _CarImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _CarImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            _CarImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(IFormFile formFile, CarImage carImage)
        {
            _CarImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetCarImagesById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            _CarImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }
    }
}

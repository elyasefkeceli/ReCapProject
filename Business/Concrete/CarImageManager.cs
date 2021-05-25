using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
           
            IResult result = BusinessRules.Run(CheckImageLimit(carImage.Id));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _CarImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _CarImageDal.Get(c => c.Id == carImage.Id);
            if (image==null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            FileHelper.Delete(image.ImagePath);
            _CarImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll(),Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetById(int ImageId)
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll(ı=>ı.ImageId==ImageId));
        }

        public IDataResult<List<CarImage>> GetCarImagesById(int ImageId)
        {
            //IResult result = BusinessRules.Run(CheckIfCarImageNull(ImageId));
            //if (result!=null)
            //{
            //    return new ErrorDataResult<List<CarImage>>(result.Message);
            //}
            //return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(ImageId).Data);
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll(ı => ı.ImageId == ImageId));
        }

        //private IDataResult<List<CarImage>> CheckIfCarImageNull(int ImageId)
        //{
        //    string path = @"\uploads\logo.jpg";
        //    var result = _CarImageDal.GetAll(c=>c.Id==ImageId).Any();
        //    if (!result)
        //    {
        //        List<CarImage> carImages = new List<CarImage>();
        //        carImages.Add(new CarImage { Id = ImageId, ImagePath = path, Date = DateTime.Now });
        //        return new SuccessDataResult<List<CarImage>>(carImages);
        //    }
        //}

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage.Id));
            if (result !=null)
            {
                return result;
            }
            var oldPath=Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,"..\\..\\..\\wwwroot")) +_CarImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath, formFile);
            carImage.Date = DateTime.Now;
            _CarImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }
        public IDataResult<CarImage> Get(int ImageId)
        {
            return new SuccessDataResult<CarImage>(_CarImageDal.Get(ı=>ı.Id==ImageId));
        }

        private IResult CheckImageLimit(int Id)
        {
            var result = _CarImageDal.GetAll(c => c.Id == Id).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}

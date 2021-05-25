using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile formFile,CarImage carImage);
        IResult Update(IFormFile formFile,CarImage carImage);
        IResult Delete(CarImage carImage);

        IDataResult<CarImage> Get(int ImageId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetById(int ImageId);
        IDataResult<List<CarImage>> GetCarImagesById(int ImageId);
    }
}

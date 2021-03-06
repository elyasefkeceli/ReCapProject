using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context= new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cc in context.Colors
                             on c.ColorId equals cc.ColorId
                             select new CarDetailDto { Id=c.Id,ColorName=cc.ColorName,BrandName=b.BrandName,Description=c.Description,DailyPrice=c.DailyPrice,ModelYear=c.ModelYear};
                return result.ToList();
            }
        }
    }
}

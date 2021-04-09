using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarText();
        }

        private static void CarText()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Araba Açıklama  : {0}/ Araba Yaşı  :{1}/ Araba Fiyati  : {2}/  Araba Rengi   :{3}/ Araba Markası  : {4}", car.Description, car.ModelYear, car.DailyPrice,car.ColorName,car.BrandName);
            }
        }
    }
}

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
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Arabanın Açıklaması : {0} Arabanın Modeli : {1} Arabanın Fiyatı {2}",car.Description,car.ModelYear,car.DailyPrice);
            }
        }
    }
}

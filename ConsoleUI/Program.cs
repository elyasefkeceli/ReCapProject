using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarText();
            //CarAddText();
            //CarDeleteText();
            //CarUpdateText();
            // BrandListText();
            // BrandAddText();
            //BrandUpdateText();
            //ColorListText();
            // ColorAddText();
            //ColorUpdateText();
            //UserText();
            //UserAddText();
            //CustomerListText();
            //CustomerAddText();
        }

        private static void CarText()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araba Açıklama  : {0}/ Araba Yaşı  :{1}/ Araba Fiyati  : {2}/  Araba Rengi   :{3}/ Araba Markası  : {4}", car.Description, car.ModelYear, car.DailyPrice,car.ColorName,car.BrandName);
            }
        }
        private static void CarDeleteText()
        {
            EfCarDal deletedCar = new EfCarDal();
            deletedCar.Delete(new Car { Id = 7 });
            Console.WriteLine("--------------Araba Silindi-----------------");
            Console.ReadLine();
        }
        private static void CarAddText()
        {
            EfCarDal addNewCar = new EfCarDal();
            addNewCar.Add(new Car { Description = "Audi A2", ModelYear = "2023", DailyPrice = 2000, ColorId = 3, BrandId = 1, Id = 7 });
            Console.WriteLine("--------------Araba eklendi-----------------");
        }
        private static void CarUpdateText()
        {
            EfCarDal updateCar = new EfCarDal();
            updateCar.Update(new Car {Id=6,Description="Mercedes-Benz CLA-180",BrandId=7,ColorId=4,DailyPrice=700,ModelYear="2020"});
            Console.WriteLine("Araba Güncellendi...");
        }
        private static void BrandListText()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0}/{1}",brand.BrandId.ToString(), brand.BrandName); 
            }
            Console.ReadLine();
           
        }
        private static void BrandAddText()
        {
            EfBrandDal addBrand = new EfBrandDal();
            addBrand.Add(new Brand { BrandId = 7, BrandName = "Volvo" });
            Console.WriteLine("Yeni Model eklendi.");
            Console.ReadLine();
        }
        private static void BrandUpdateText()
        {
            EfBrandDal updateBrand = new EfBrandDal();
            updateBrand.Update(new Brand { BrandId=7,BrandName="Mercedes-Benz"});
            Console.WriteLine("Model Güncellendi");
            Console.ReadLine();
        }
        private static void ColorListText()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0}/{1}",color.ColorId,color.ColorName);
            }
            Console.ReadLine();
        }
        private static void ColorAddText()
        {
            EfColorDal addColor = new EfColorDal();
            addColor.Add(new Color {ColorId=7,ColorName= "Yellow" });
            Console.WriteLine("Yeni Renk Eklendi..");
            Console.ReadLine();
        }
        private static void ColorUpdateText()
        {
            EfColorDal updateColor = new EfColorDal();
            updateColor.Update(new Color {ColorId=7,ColorName= "Beige" });
            Console.WriteLine("Renk Güncellendi..");
            Console.ReadLine();
        }
        private static void UserText()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("{0}/{1}/{2}/{3}",user.FirstName,user.LastName,user.Password,user.Email);
            }
            Console.WriteLine(Messages.UserListed);
            Console.ReadLine();
        }
        private static void UserAddText()
        {
            //EfUserDal addNewUser = new EfUserDal();
            //addNewUser.Add(new Users { UserId = 2, FistName = "elyase", LastName = "keceli",Password="12345",Email="farukkeceli52@gmail.com"});
            //Console.WriteLine(Messages.UserAdded);
            //Console.ReadLine();
            UserManager userManager = new UserManager(new EfUserDal());
            var userAdded = userManager.Add(new User { UserId = 2, FirstName = "elyase", LastName = "keceli", Password = "12345", Email = "farukkeceli52@gmail.com" });
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine("{0} / {1}",user.FirstName,user.LastName);
            }
        }
        private static void CustomerListText()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            if (result.Success==true)
            {
                foreach (var customer in customerManager.GetAll().Data)
                {
                    Console.WriteLine("Kullanıcı Id :{0}/ Müsteri Id: {1}/ Şirket Adi :{2}", customer.UserId.ToString(), customer.CustomerId, customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }
        private static void CustomerAddText()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer {UserId=2,CustomerId=2,CompanyName="Star" });
            Console.WriteLine("{0}/{1}",result.Success,result.Message);
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CarImageController : Controller
    {
        ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getCarImageById")]
        public IActionResult GetCarImageById(int Id)
        {
            var result = _carImageService.GetCarImagesById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name =("Image"))] IFormFile file,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpPost("delete")]
        //public IActionResult Delete()
        //{

        //}
        //[HttpPost("update")]
        //public IActionResult Update([FromForm(Name =("Image"))] IFormFile file,[FromForm(Name =("Id"))] int Id)
        //{
        //    var image = _carImageService.GetById(Id).Data;
        //    var result = _carImageService.Update(file,image);
        //        if (result.Success)
        //        {
        //            return Ok(result);
        //        }
        //        return BadRequest(result);
            
            
        //}
    }
}

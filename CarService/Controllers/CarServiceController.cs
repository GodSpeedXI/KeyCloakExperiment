using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CarServiceController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllCar()
        {
            var carList = new List<Car>(3);
            carList.Add(new Car(){ CarId = 1, Brand = "Toyota", Series = "Prius", Nickname = "New Prius 2020"});
            carList.Add(new Car() { CarId = 2, Brand = "Mercedes benz", Series = "C-Class", Nickname = "C-Class Saloon" });
            carList.Add(new Car() { CarId = 3, Brand = "BMW", Series = "i8", Nickname = "i8 Roadster" });

            return Ok(new {cars = carList});
        }
    }
}

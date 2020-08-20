using CarService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.Application.CQRS.CarProduct.Queries.GetCarProduct;
using CarService.Application.Interfaces.Repositories;
using CarService.WebApi.Controllers;
using MediatR;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CarServiceController : MediatorBase
    {
        private readonly ICarProductRepository _carProduct;

        public CarServiceController(ICarProductRepository carProduct)
        {
            _carProduct = carProduct;
        }
        [HttpGet]
        public async Task<ActionResult> GetCars([FromQuery] GetCarProductQuery carProductQuery)
        {
            //var carList = await _carProduct.GetPagedReponseAsync(1, 10);
            //return Ok(new { cars = carList });

            return Ok(await Mediator.Send(carProductQuery));
        }
    }
}

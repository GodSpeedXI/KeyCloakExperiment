using System.Threading.Tasks;
using CarService.Application.CQRS.CarProduct.Commands;
using CarService.Application.CQRS.CarProduct.Queries.GetCarProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CarServiceController : MediatorBase
    {
        //private readonly ICarProductRepository _carProduct;

        public CarServiceController()//ICarProductRepository carProduct)
        {
            //_carProduct = carProduct;
        }
        [HttpGet("", Name = nameof(GetCars))]
        public async Task<ActionResult> GetCars([FromQuery] GetCarProductQuery carProductQuery)
        {
            //var carList = await _carProduct.GetPagedReponseAsync(1, 10);
            //return Ok(new { cars = carList });

            return Ok(await Mediator.Send(carProductQuery));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCar([FromBody] CreateCarProductCommand carProductCommand)
        {
            var createdProduct = await Mediator.Send(carProductCommand);
            return CreatedAtRoute(nameof(GetCars), new {id = createdProduct.CarId} ,createdProduct);
        }
    }
}

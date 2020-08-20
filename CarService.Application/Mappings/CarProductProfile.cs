using AutoMapper;
using CarService.Application.CQRS.CarProduct.Commands;
using CarService.Application.CQRS.CarProduct.Queries.GetCarProduct;
using CarService.Domain.Entities;

namespace CarService.Application.Mappings
{
    public class CarProductProfile : Profile
    {
        public CarProductProfile()
        {
            CreateMap<CarProduct, GetCarProductQueryModel>().ReverseMap();
            CreateMap<CreateCarProductCommand, CarProduct>().ReverseMap();
        }
    }
}

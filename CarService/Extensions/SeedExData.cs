using CarService.Application.Interfaces.Repositories;
using CarService.Domain.Entities;

namespace CarService.WebApi.Extensions
{
    public static class SeedExData
    {
        public static void SeedCarProduct(ICarProductRepository repository)
        {
            repository.AddAsync(new CarProduct() { CarId = 1, Brand = "Toyota", Series = "Prius", Nickname = "New Prius 2020" }).Wait();
            repository.AddAsync(new CarProduct() { CarId = 2, Brand = "Mercedes benz", Series = "C-Class", Nickname = "C-Class Saloon" }).Wait();
            repository.AddAsync(new CarProduct() { CarId = 3, Brand = "BMW", Series = "i8", Nickname = "i8 Roadster" }).Wait();
        }
    }
}

using CarService.Application.Interfaces.Repositories;
using CarService.Domain.Entities;
using CarService.Infrastructure.Persistence.Contexts;

namespace CarService.Infrastructure.Persistence.Repositories
{
    public class CarProductRepository : BaseRepository<CarProduct>, ICarProductRepository
    {
        public CarProductRepository(CarServiceAppDbContext dbContext) : base(dbContext) { }
    }
}

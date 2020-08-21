using CarService.Application.Interfaces.Repositories;
using CarService.Application.Interfaces.UnitOfWork;
using CarService.Infrastructure.Persistence.Contexts;
using CarService.Infrastructure.Persistence.Repositories;
using System.Threading.Tasks;

namespace CarService.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarServiceAppDbContext _context;

        public UnitOfWork(CarServiceAppDbContext context)
        {
            _context = context;
            CarProduct = new CarProductRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public ICarProductRepository CarProduct { get; }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

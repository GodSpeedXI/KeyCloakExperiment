using CarService.Application.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace CarService.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICarProductRepository CarProduct { get; }
        Task<int> SaveAsync();
    }
}

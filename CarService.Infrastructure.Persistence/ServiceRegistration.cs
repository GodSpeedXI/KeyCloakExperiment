using CarService.Application.Interfaces.Repositories;
using CarService.Infrastructure.Persistence.Contexts;
using CarService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<CarServiceAppDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("CarServiceAppDbContext");
            });

            service.AddTransient<ICarProductRepository, CarProductRepository>();
        }
    }
}

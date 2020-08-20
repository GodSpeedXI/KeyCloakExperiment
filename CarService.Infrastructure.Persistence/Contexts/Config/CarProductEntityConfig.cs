using CarService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Infrastructure.Persistence.Contexts.Config
{
    public class CarProductEntityConfig : IEntityTypeConfiguration<CarProduct>
    {
        public void Configure(EntityTypeBuilder<CarProduct> builder)
        {
            builder.HasKey(tb => tb.CarId);
        }
    }
}

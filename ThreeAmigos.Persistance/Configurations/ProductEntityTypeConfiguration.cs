using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreeAmigos.Domain.Entities;

namespace ThreeAmigos.Persistance.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(s => s.IdProduct);
            /*
            builder.HasMany(s => s.StoreProduct)
                   .WithOne(se => se.Product)
                   .HasForeignKey(se => se.IdProduct);
            */
        }
    }
}

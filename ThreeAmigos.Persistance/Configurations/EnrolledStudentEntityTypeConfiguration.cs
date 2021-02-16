using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreeAmigos.Domain.Entities;

namespace ThreeAmigos.Persistance.Configurations
{
    public class ProductStoreEntityTypeConfiguration : IEntityTypeConfiguration<ProductStore>
    {
        public void Configure(EntityTypeBuilder<ProductStore> builder)
        {
            builder.HasKey(es => es.IdProductStore);
            /*
            builder.HasOne(es => es.Product)
                   .WithMany(s => s.StoreProduct)
                   .HasForeignKey(es => es.IdProduct);
            */
            
        }
    }
}

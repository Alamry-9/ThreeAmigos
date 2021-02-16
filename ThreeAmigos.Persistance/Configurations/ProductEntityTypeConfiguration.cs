﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreeAmigos.Domain.Entities;

namespace ThreeAmigos.Persistance.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(es => es.IdProduct);
            /*
            builder.HasOne(es => es.Product)
                   .WithMany(s => s.StoreProduct)
                   .HasForeignKey(es => es.IdProduct);
            */
            
        }
    }
}
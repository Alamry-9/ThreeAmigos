using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreeAmigos.Domain.Entities;

namespace ThreeAmigos.Persistance.Configurations
{
    public class StudiesEntityTypeConfiguration : IEntityTypeConfiguration<Studies>
    {
        public void Configure(EntityTypeBuilder<Studies> builder)
        {
            
            builder.HasKey(s => s.IdStudies);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(s => s.StudentsEnrolled)
                    .WithOne(se => se.Studies)
                    .HasForeignKey(se => se.IdStudies);
            
        }
    }
}

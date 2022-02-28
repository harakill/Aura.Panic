using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class PanicConfiguration : IEntityTypeConfiguration<Panic>
    {
        public void Configure(EntityTypeBuilder<Panic> builder)
        {
            builder.Property(fn => fn.FullName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(ph => ph.Phone)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(n => n.Note)
                .HasMaxLength(512);
        }
    }
}

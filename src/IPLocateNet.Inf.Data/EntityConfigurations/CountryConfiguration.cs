using IPLocateNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPLocateNet.Inf.Data.EntityConfigurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new CountryId(x))
            .IsRequired();

        builder.Property(x => x.Name)
            .HasConversion(x => x.ToString(), x => new CountryName(x))
            .IsRequired();

        builder.HasOne(x => x.Sovereignty)
            .WithMany()
            .IsRequired();

        builder.Property(x => x.Code3)
            .HasConversion(x => x.ToString(), x => new CountryCode3(x))
            .IsRequired();

        builder.HasKey(x => x.Id);
    }
}

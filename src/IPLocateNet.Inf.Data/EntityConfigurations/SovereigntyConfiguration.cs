using IPLocateNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPLocateNet.Inf.Data.EntityConfigurations;

internal sealed class SovereigntyConfiguration : IEntityTypeConfiguration<Sovereignty>
{
    public void Configure(EntityTypeBuilder<Sovereignty> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new SovereigntyId(x))
            .IsRequired();

        builder.Property(x => x.Name)
            .HasConversion(x => x.ToString(), x => new SovereigntyName(x))
            .IsRequired();

        builder.HasKey(x => x.Id);
    }
}

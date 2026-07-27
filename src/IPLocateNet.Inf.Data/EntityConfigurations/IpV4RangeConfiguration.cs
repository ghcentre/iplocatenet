using IPLocateNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace IPLocateNet.Inf.Data.EntityConfigurations;

internal sealed class IPv4RangeConfiguration : IEntityTypeConfiguration<IPv4Range>
{
    public void Configure(EntityTypeBuilder<IPv4Range> builder)
    {
        builder.Property(x => x.StartingIP)
            .HasConversion(x => x.GetAddressBytes() , x => new IPv4Address(x))
            .IsRequired();

        builder.Property(x => x.EndingIP)
            .HasConversion(x => x.GetAddressBytes(), x => new IPv4Address(x))
            .IsRequired();

        builder.HasOne(x => x.Country)
            .WithMany()
            .IsRequired();

        builder.HasKey(x => x.StartingIP);
    }
}

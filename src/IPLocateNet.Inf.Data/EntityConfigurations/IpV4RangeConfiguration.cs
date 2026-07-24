using IPLocateNet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace IPLocateNet.Inf.Data.EntityConfigurations;

internal sealed class IpV4RangeConfiguration : IEntityTypeConfiguration<IpV4Range>
{
    public void Configure(EntityTypeBuilder<IpV4Range> builder)
    {
        builder.Property(x => x.StartingIP)
            .HasConversion(x => x.GetAddressBytes() , x => new IPAddress(x))
            .IsRequired();

        builder.Property(x => x.EndingIP)
            .HasConversion(x => x.GetAddressBytes(), x => new IPAddress(x))
            .IsRequired();

        builder.HasOne(x => x.Country)
            .WithMany()
            .IsRequired();

        builder.HasKey(x => x.StartingIP);
    }
}

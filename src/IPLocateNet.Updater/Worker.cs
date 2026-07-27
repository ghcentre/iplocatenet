using IPLocateNet.Domain;
using IPLocateNet.Domain.Entities;
using IPLocateNet.Inf.Data;
using Microsoft.EntityFrameworkCore;

namespace IPLocateNet.Updater;

internal class Worker(AppDbContext db)
{
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var ipaddr = IPv4Address.Parse("127.0.0.1");
        var ipaddr2 = IPv4Address.Parse("127.255.255.255");

        var list = await db.IPv4Ranges
            .Include(x => x.Country)
            .ThenInclude(x => x.Sovereignty)
            .Where(x => x.StartingIP >= ipaddr)
            .ToListAsync(cancellationToken);

        var country = db.Countries.Include(x => x.Sovereignty).First(x => x.Id == new CountryId("RU"));

        var range = new IPv4Range(ipaddr, ipaddr2, country!);
        db.IPv4Ranges.Add(range);

        await db.SaveChangesAsync(cancellationToken);
    }
}

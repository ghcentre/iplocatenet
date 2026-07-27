using Ample.Core.Network;
using IPLocateNet.Domain.Entities;
using IPLocateNet.Domain.LocalSpecifications;
using IPLocateNet.Inf.Data;
using IPLocateNet.Inf.Data.LocalRepositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace IPLocateNet.Updater;

internal class Worker(AppDbContext db, IPv4RangeRepository repository)
{
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var lo = IPNetwork.ParseExtended("127.0.0.1/8");
        var pr = IPNetwork.ParseExtended("192.168.0.0/16");

        var list = await db.IPv4Ranges.ToListAsync(cancellationToken);
        db.IPv4Ranges.RemoveRange(list);
        await db.SaveChangesAsync(cancellationToken);

        var country = db.Countries.Include(x => x.Sovereignty).First(x => x.Id == new CountryId("ru"));

        var entity = new IPv4Range(new IPv4Address(lo.BaseAddress), new IPv4Address(lo.BroadcastAddress), country);
        db.IPv4Ranges.Add(entity);

        var entity2 = new IPv4Range(new IPv4Address(pr.BaseAddress), new IPv4Address(pr.BroadcastAddress), country);
        db.IPv4Ranges.Add(entity2);

        await db.SaveChangesAsync(cancellationToken);

        var spec = new IPv4AddressesGreaterThanSpecification("10.0.0.0");
        var repoList = await repository.ListAsync(spec, cancellationToken);
    }
}

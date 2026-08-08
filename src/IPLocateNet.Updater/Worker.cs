using Ample.Core.Network;
using IPLocateNet.Domain.Entities;
using IPLocateNet.Domain.LocalSpecifications;
using IPLocateNet.Inf.Data.LocalRepositories;
using System.Net;

namespace IPLocateNet.Updater;

internal class Worker(IPv4RangeRepository rangeRepository, CountryRepository countryRepository)
{
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        await PrepareRanges(cancellationToken);

        var spec1 = new RangeForIPSpecification("10.0.0.1");
        var range1 = await rangeRepository.GetAsync(spec1, cancellationToken);

        var spec2 = new RangeForIPSpecification("192.168.1.1");
        var range2 = await rangeRepository.GetAsync(spec2, cancellationToken);
    }

    private async Task PrepareRanges(CancellationToken cancellationToken)
    {
        var allRanges = await rangeRepository.ListAsync(null, cancellationToken);
        await rangeRepository.DeleteRangeAsync(allRanges, cancellationToken);
        await rangeRepository.UnitOfWork.SaveAsync(cancellationToken);

        var countrySpec = new CountryByCodeSpecification("ru");
        var country = await countryRepository.GetAsync(countrySpec, cancellationToken)
                      ?? throw new InvalidOperationException("No country found.");

        var lo = IPNetwork.ParseExtended("127.0.0.1/8");
        var pr = IPNetwork.ParseExtended("192.168.0.0/16");

        var loe = new IPv4Range(new IPv4Address(lo.BaseAddress), new IPv4Address(lo.BroadcastAddress), country);
        var lop = new IPv4Range(new IPv4Address(pr.BaseAddress), new IPv4Address(pr.BroadcastAddress), country);

        await rangeRepository.InsertRangeAsync([loe, lop], cancellationToken);
        await rangeRepository.UnitOfWork.SaveAsync();

        var ranges = await rangeRepository.ListAsync(new IPv4AddressesGTESpecification("0.0.0.0"), cancellationToken);
        var changedRange = new IPv4Range(ranges[0].StartingIP, IPv4Address.Parse("127.0.0.5"), ranges[0].Country);
        await rangeRepository.UpdateAsync(changedRange, cancellationToken);

        await rangeRepository.UnitOfWork.SaveAsync(cancellationToken);

        changedRange.TempChangeEndingIP(IPv4Address.Parse("1.2.3.4"));
        await rangeRepository.UpdateAsync(changedRange, cancellationToken);

        await rangeRepository.UnitOfWork.SaveAsync(cancellationToken);

        var ranges2 = await rangeRepository.ListAsync(new IPv4AddressesGTESpecification("0.0.0.0"), cancellationToken);
        await rangeRepository.DeleteAsync(ranges[0], cancellationToken);

        await rangeRepository.UnitOfWork.SaveAsync(cancellationToken);
    }
}

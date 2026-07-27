using IPLocateNet.Domain.Entities;
using IPLocateNet.Domain.Specifications;

namespace IPLocateNet.Domain.LocalSpecifications;

public class IPv4AddressesGreaterThanSpecification : Specification<IPv4Range>
{
    public IPv4AddressesGreaterThanSpecification(string ipString)
    {
        var address = IPv4Address.Parse(ipString);

        Query
            .Include(x => x.Country)
            .Include(x => x.Country.Sovereignty)
            .Where(range => range.StartingIP > address)
            .OrderBy(range => range.StartingIP);
    }
}

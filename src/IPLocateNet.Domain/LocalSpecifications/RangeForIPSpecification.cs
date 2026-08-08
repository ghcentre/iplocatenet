using IPLocateNet.Domain.Entities;
using IPLocateNet.Domain.Specifications;

namespace IPLocateNet.Domain.LocalSpecifications;

public class RangeForIPSpecification : Specification<IPv4Range>
{
    public RangeForIPSpecification(string ipString)
    {
        var address = IPv4Address.Parse(ipString);

        Query
            .Include(x => x.Country)
            .Include(x => x.Country.Sovereignty)
            .Where(range => address >= range.StartingIP && address <= range.EndingIP)
            .OrderBy(range => range.StartingIP);
    }
}

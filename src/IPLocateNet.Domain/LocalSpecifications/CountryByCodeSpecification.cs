using Ample.Core.GuardClauses;
using IPLocateNet.Domain.Entities;
using IPLocateNet.Domain.Specifications;

namespace IPLocateNet.Domain.LocalSpecifications;

public class CountryByCodeSpecification : Specification<Country>
{
    public CountryByCodeSpecification(string countryCode)
    {
        Guard.Against.NullOrEmpty(countryCode);
        var countryId = new CountryId(countryCode);

        Query
            .Include(x => x.Sovereignty)
            .Where(x => x.Id == countryId)
            .OrderBy(x => x.Id);
    }
}

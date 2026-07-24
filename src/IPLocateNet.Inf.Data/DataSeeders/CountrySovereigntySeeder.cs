using IPLocateNet.Domain;
using Microsoft.EntityFrameworkCore;

namespace IPLocateNet.Inf.Data.DataSeeders;

internal static class CountrySovereigntySeeder
{
    public static void Seed(ModelBuilder builder)
    {
        var sovereigntyMap = SeedSovereignties(builder);
        var entities = CountryData.Countries
            .Select(
                (x, i) =>
                new
                {
                    Id = new CountryCode2(x.Code2),
                    Name = new CountryName(x.Name),
                    SovereigntyId = new SovereigntyId((ushort)sovereigntyMap[x.Sovereignty]),
                    Code3 = new CountryCode3(x.Code3)
                });
        builder.Entity<Country>().HasData(entities);
    }

    private static Dictionary<string, int> SeedSovereignties(ModelBuilder builder)
    {
        var map = CountryData.Sovereignties.Select((s, i) => (s, i + 1)).ToDictionary();
        var entities = map.Select(x => new Sovereignty((ushort)x.Value, x.Key));
        builder.Entity<Sovereignty>().HasData(entities);
        return map;
    }
}

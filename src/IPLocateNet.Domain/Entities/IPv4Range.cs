using Ample.Core.GuardClauses;

namespace IPLocateNet.Domain.Entities;

public class IPv4Range
{
    private IPv4Range() { }

    public IPv4Range(IPv4Address startingIP, IPv4Address endingIP, Country country)
    {
        StartingIP = Guard.Against.Null(startingIP);
        EndingIP = Guard.Against.Null(endingIP);
        Country = Guard.Against.Null(country);

        if (StartingIP > EndingIP)
        {
            throw new ArgumentException(
                "Starting IP address must be less than or equal to the ending IP address.",
                nameof(startingIP));
        }
    }

    public IPv4Address StartingIP { get; private set; } = default!;
    public IPv4Address EndingIP { get; private set; } = default!;
    public Country Country { get; private set; } = default!;
}

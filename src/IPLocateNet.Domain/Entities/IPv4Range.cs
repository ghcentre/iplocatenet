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

    [Obsolete]
    public void TempChangeEndingIP(IPv4Address ip) => EndingIP = Guard.Against.Null(ip);

    public IPv4Address StartingIP { get; private set; } = default!;
    public IPv4Address EndingIP { get; private set; } = default!;
    public Country Country { get; private set; } = default!;

    public override string ToString() => $"{StartingIP}–{EndingIP} ({Country.Id})";
    public override bool Equals(object? obj) => obj is IPv4Range other && StartingIP.Equals(other.StartingIP);
    public override int GetHashCode() => StartingIP.GetHashCode();
}

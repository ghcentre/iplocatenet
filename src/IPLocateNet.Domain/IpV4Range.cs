using Ample.Core.GuardClauses;
using System.Net;
using System.Runtime.CompilerServices;

namespace IPLocateNet.Domain;

public class IpV4Range
{
    private const int _bytesInIpV4Address = 4;

    private IpV4Range() { }

    public IpV4Range(IPAddress startingIp, IPAddress endingIp, Country country)
    {
        StartingIP = ForceIpV4(startingIp);
        EndingIP = ForceIpV4(endingIp);
        Country = Guard.Against.Null(country);

        ForceLessThanOrEqual(startingIp, endingIp, nameof(startingIp), nameof(endingIp));
    }

    public IPAddress StartingIP { get; private set; } = default!;
    public IPAddress EndingIP { get; private set; } = default!;
    public Country Country { get; private set; } = default!;

    private static IPAddress ForceIpV4(IPAddress address,
                                      [CallerArgumentExpression(nameof(address))] string? paramName = null)
    {
        Guard.Against.Null(address, paramName);
        if (address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
        {
            throw new ArgumentException($"InterNetwork address family expected for address: {address}", paramName);
        }
        return address;
    }

    public static void ForceLessThanOrEqual(IPAddress left, IPAddress right, string leftParamName, string rightParamName)
    {
        if (CompareIpV4Addresses(left, right) > 0)
        {
            throw new ArgumentException(
                $"The {leftParamName} IP address must be less than or equal to the {rightParamName} IP address.",
                leftParamName);
        }
    }

    private static int CompareIpV4Addresses(IPAddress a, IPAddress b)
    {
        Span<byte> bytesA = stackalloc byte[_bytesInIpV4Address];
        a.TryWriteBytes(bytesA, out _);

        Span<byte> bytesB = stackalloc byte[_bytesInIpV4Address];
        b.TryWriteBytes(bytesB, out _);

        return bytesA.SequenceCompareTo(bytesB);
    }
}

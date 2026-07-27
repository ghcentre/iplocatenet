using Ample.Core.GuardClauses;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace IPLocateNet.Domain.Entities;

public class IPv4Address : IPAddress, IComparable, IComparable<IPv4Address>, IEquatable<IPv4Address>
{
    private static class IPAddressParserStatics
    {
        public const int IPv4AddressBytes = 4;
    }

    public IPv4Address(byte[] address) : base(ForceIPv4AddressBytes(Guard.Against.Null(address)))
    {
    }

    public IPv4Address(ReadOnlySpan<byte> address) : base(ForceIPv4AddressBytes(address))
    {
    }

    public IPv4Address(IPAddress address) : base(ForceIPv4AddressBytes(Guard.Against.Null(address).GetAddressBytes()))
    {
    }

    private static ReadOnlySpan<byte> ForceIPv4AddressBytes(ReadOnlySpan<byte> address)
    {
        if (address is not { Length: IPAddressParserStatics.IPv4AddressBytes })
        {
            throw new ArgumentException("Invalid IPv4 address length.", nameof(address));
        }
        return address;
    }

    #region IComparable, IComparable<IPv4Address>

    public int CompareTo(object? obj)
    {
        return obj is IPv4Address address
            ? CompareTo(address)
            : throw new ArgumentException("Object is not an IPv4Address.", nameof(obj));
    }

    public int CompareTo(IPv4Address? other)
    {
        if (other is null)
        {
            return 1; // https://learn.microsoft.com/ru-ru/dotnet/api/system.icomparable-1?view=net-10.0
        }

        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        Span<byte> thisBytes = stackalloc byte[IPAddressParserStatics.IPv4AddressBytes];
        TryWriteBytes(thisBytes, out _);

        Span<byte> otherBytes = stackalloc byte[IPAddressParserStatics.IPv4AddressBytes];
        other.TryWriteBytes(otherBytes, out _);

        return thisBytes.SequenceCompareTo(otherBytes);
    }

    #endregion

    #region Equals, GetHashCode, ToString

    public override bool Equals([NotNullWhen(true)] object? comparand)
    {
        return comparand is IPv4Address ipv4Address && Equals(ipv4Address);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    #endregion

    #region IEquatable<IPv4Address>

    public bool Equals(IPv4Address? comparand)
    {
        if (comparand is null)
        {
            return false;
        }

        if (ReferenceEquals(this, comparand))
        {
            return true;
        }

        Span<byte> thisBytes = stackalloc byte[IPAddressParserStatics.IPv4AddressBytes];
        TryWriteBytes(thisBytes, out _);

        Span<byte> comparandBytes = stackalloc byte[IPAddressParserStatics.IPv4AddressBytes];
        comparand.TryWriteBytes(comparandBytes, out _);

        return thisBytes.SequenceEqual(comparandBytes);
    }

    #endregion

    #region Equality and Comparison Operators

    public static bool operator ==(IPv4Address? left, IPv4Address? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(IPv4Address? left, IPv4Address? right)
    {
        return !(left == right);
    }

    public static bool operator <(IPv4Address? left, IPv4Address? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(IPv4Address? left, IPv4Address? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(IPv4Address? left, IPv4Address? right)
    {
        return left is not null && left.CompareTo(right) > 0;
    }

    public static bool operator >=(IPv4Address? left, IPv4Address? right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }

    #endregion

    #region Parse

    public static new IPv4Address Parse(string ipString)
    {
        Guard.Against.Null(ipString);
        var ipAddress = IPAddress.Parse(ipString);
        return new IPv4Address(ipAddress);
    }

    public static new IPv4Address Parse(ReadOnlySpan<char> ipSpan)
    {
        var ipAddress = IPAddress.Parse(ipSpan);
        return new IPv4Address(ipAddress);
    }

    #endregion
}

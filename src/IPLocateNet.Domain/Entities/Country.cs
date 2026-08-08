using Ample.Core.GuardClauses;
using System.Security.Cryptography;

namespace IPLocateNet.Domain.Entities;

public class Country
{
    private Country() { }

    public Country(CountryId id, CountryName name, Sovereignty sovereignty, CountryCode3 code3)
    {
        Id = Guard.Against.Null(id);
        Name = Guard.Against.Null(name);
        Sovereignty = Guard.Against.Null(sovereignty);
        Code3 = Guard.Against.Null(code3);
    }

    public CountryId Id { get; private set; } = default!;
    public CountryName Name { get; private set; } = default!;
    public Sovereignty Sovereignty { get; private set; } = default!;
    public CountryCode3 Code3 { get; private set; } = default!;

    public override string ToString() => $"{Name} ({Id})";
    public override bool Equals(object? obj) => obj is Country other && Id.Equals(other.Id);
    public override int GetHashCode() => Id.GetHashCode();
}

public record CountryName
{
    public CountryName(string value) => Value = Guard.Against.NullOrEmpty(value?.Trim());
    public string Value { get; }
    public override string ToString() => Value.ToString();
    public static implicit operator CountryName(string value) => new(value);
}

public record CountryId
{
    public CountryId(string value)
    {
        Value = Guard.Against.NullOrEmpty(value?.Trim()).ToUpperInvariant();
        Guard.Against.LessThan(value.Length, 2);
        Guard.Against.GreaterThan(value.Length, 2);
    }
    public string Value { get; }
    public override string ToString() => Value.ToString();
}

public record CountryCode3
{
    public CountryCode3(string value)
    {
        Value = Guard.Against.NullOrEmpty(value?.Trim()).ToUpperInvariant();
        Guard.Against.LessThan(value.Length, 3);
        Guard.Against.GreaterThan(value.Length, 3);
    }
    public string Value { get; }
    public override string ToString() => Value.ToString();
}

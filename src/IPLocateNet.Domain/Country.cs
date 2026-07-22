using Ample.Core.GuardClauses;

namespace IPLocateNet.Domain;

public class Country
{
    private Country() {}

    public Country(CountryId id, CountryTitle title, CountryCode2 code2)
    {
        Id = Guard.Against.Null(id);
        Title = Guard.Against.Null(title);
        Code2 = Guard.Against.Null(code2);
    }

    public CountryId Id { get; private set; }
    public CountryTitle Title { get; private set; } = default!;
    public CountryCode2 Code2 { get; private set; } = default!;
}

public readonly record struct CountryId
{
    public CountryId(ushort value) => Value = value;

    public ushort Value { get; }

    public static implicit operator CountryId(ushort value) => new(value);
}

public record CountryTitle
{
    public CountryTitle(string value) => Value = Guard.Against.NullOrEmpty(value?.Trim());

    public string Value { get; }

    public static implicit operator CountryTitle(string value) => new(value);
}

public record CountryCode2
{
    public CountryCode2(string value)
    {
        Value = Guard.Against.NullOrEmpty(value?.Trim());
        Guard.Against.LessThan(Value.Length, 2);
        Guard.Against.GreaterThan(Value.Length, 2);
    }

    public string Value { get; }

    public static implicit operator CountryCode2(string value) => new(value);
}

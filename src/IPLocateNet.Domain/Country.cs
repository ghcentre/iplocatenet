using Ample.Core.GuardClauses;

namespace IPLocateNet.Domain;

public class Country
{
    private Country() {}

    public Country(CountryCode2 id, CountryName name, Sovereignty sovereignty, CountryCode3 code3)
    {
        Id = Guard.Against.Null(id);
        Name = Guard.Against.Null(name);
        Sovereignty = Guard.Against.Null(sovereignty);
        Code3 = Guard.Against.Null(code3);
    }

    public CountryCode2 Id { get; private set; } = default!;
    public CountryName Name { get; private set; } = default!;
    public Sovereignty Sovereignty { get; private set; } = default!;
    public CountryCode3 Code3 { get; private set; } = default!;
}

public record CountryName
{
    public CountryName(string value) => Value = Guard.Against.NullOrEmpty(value?.Trim());
    public string Value { get; }
    public override string ToString() => Value.ToString();
    public static implicit operator CountryName(string value) => new(value);
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
    public override string ToString() => Value.ToString();
    public static implicit operator CountryCode2(string value) => new(value);
}

public record CountryCode3
{
    public CountryCode3(string value)
    {
        Value = Guard.Against.NullOrEmpty(value?.Trim());
        Guard.Against.LessThan(Value.Length, 3);
        Guard.Against.GreaterThan(Value.Length, 3);
    }
    public string Value { get; }
    public override string ToString() => Value.ToString();
    public static implicit operator CountryCode3(string value) => new(value);
}

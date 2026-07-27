using Ample.Core.GuardClauses;

namespace IPLocateNet.Domain.Entities;

public class Sovereignty
{
    private Sovereignty() { }

    public Sovereignty(SovereigntyId id, SovereigntyName name)
    {
        Id = Guard.Against.Null(id);
        Name = Guard.Against.Null(name);
    }

    public SovereigntyId Id { get; private set; }
    public SovereigntyName Name { get; private set; } = default!;
}

public readonly record struct SovereigntyId
{
    public SovereigntyId(ushort value) => Value = value;
    public ushort Value { get; }
    public override string ToString() => Value.ToString();
    public static implicit operator SovereigntyId(ushort value) => new(value);
}

public record SovereigntyName
{
    public SovereigntyName(string value) => Value = Guard.Against.NullOrEmpty(value?.Trim());
    public string Value { get; }
    public override string ToString() => Value.ToString();
    public static implicit operator SovereigntyName(string value) => new(value);
}

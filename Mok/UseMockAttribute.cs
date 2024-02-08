namespace Mok;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
public sealed class UseMockAttribute : Attribute
{
    public required string Identifier { get; init; }
}
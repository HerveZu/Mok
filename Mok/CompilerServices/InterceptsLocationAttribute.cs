using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices;

[UsedImplicitly]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class InterceptsLocationAttribute(
    [UsedImplicitly] string filePath,
    [UsedImplicitly] int line,
    [UsedImplicitly] int character
) : Attribute
{
}
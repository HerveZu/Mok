﻿using JetBrains.Annotations;

namespace Mok;

[PublicAPI]
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
public sealed class UseMockAttribute : Attribute
{
    public required string Identifier { get; init; }
}
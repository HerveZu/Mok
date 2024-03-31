using Microsoft.CodeAnalysis;

namespace Mok.Parsing;

internal interface IMockSourceGenerator
{
    public IEnumerable<MockSource> Generate(Compilation compilation);
}
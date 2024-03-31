using Microsoft.CodeAnalysis;

namespace Mok.Parsing;

[Generator]
internal sealed class SourceGenerator : ISourceGenerator
{
    private readonly IMockSourceGenerator _mockSourceGenerator = new MockSourceGenerator();
    
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var mocks = _mockSourceGenerator.Generate(context.Compilation);

        foreach (var mock in mocks)
        {
            context.AddSource($"{mock.Name}.g.cs", mock.Source);
        }
    }
}
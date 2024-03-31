using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mok.Parsing.Extensions;

namespace Mok.Parsing;

internal sealed class MockSourceGenerator : IMockSourceGenerator
{
    public IEnumerable<MockSource> Generate(Compilation compilation)
    {
        return compilation.SyntaxTrees
            .SelectMany(syntaxTree => Generate(syntaxTree, compilation));
    }

    private IEnumerable<MockSource> Generate(SyntaxTree syntaxTree, Compilation compilation)
    {
        var semanticModel = compilation.GetSemanticModel(syntaxTree);
        var root = syntaxTree.GetRoot();

        var attributes = root
            .DescendantNodes()
            .OfType<FieldDeclarationSyntax>()
            .WithAttribute(typeof(UseMockAttribute), semanticModel, compilation)
            .ToArray();

        foreach (var (node, attribute) in attributes)
        {
            var mockId = attribute.ArgumentList?.Arguments.Where(argument => argument.NameEquals.)
            var source =
                """
                public class Mock
                """;
        }
        
        return Array.Empty<MockSource>();
    }
}
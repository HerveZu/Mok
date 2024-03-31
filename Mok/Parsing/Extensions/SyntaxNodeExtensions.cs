using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Mok.Parsing.Extensions;

internal static class SyntaxNodeExtensions
{
    public static IEnumerable<(TSyntaxNode syntaxNode, AttributeSyntax attribute)> WithAttribute<TSyntaxNode>(
        this IEnumerable<TSyntaxNode> nodes,
        Type attributeType,
        SemanticModel semanticModel,
        Compilation compilation
    )
        where TSyntaxNode : MemberDeclarationSyntax
    {
        var attributeName = attributeType.FullName ?? attributeType.Name;
        var attributeSymbol = compilation.GetTypeByMetadataName(attributeName)
                              ?? throw new InvalidOperationException($"No attribute matched '{attributeName}'");

        return nodes
            .Select(node => (node, node.AttributeLists))
            .SelectMany(t => t.AttributeLists.Select(attributes => (t.node, attributes.Attributes)))
            .Select(
                t => (t.node, t.Attributes
                    .FirstOrDefault(attribute => attribute.MatchesType(attributeSymbol, semanticModel)))
            )
            .Where(t => t.Item2 is not null)
            .Select(t => (t.node, t.Item2!));
    }

    private static bool MatchesType(this SyntaxNode node, ISymbol targetSymbol, SemanticModel semanticModel)
    {
        var comparer = SymbolEqualityComparer.IncludeNullability;
        var symbol = semanticModel.GetSymbolInfo(node).Symbol;
        
        return comparer.Equals(symbol?.ContainingType, targetSymbol);
    }
}
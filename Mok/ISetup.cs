using JetBrains.Annotations;

namespace Mok;

[PublicAPI]
public interface ISetup<in TResult>
{
    void Returns(TResult result);
}
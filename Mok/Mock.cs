using JetBrains.Annotations;

namespace Mok;

[PublicAPI]
public sealed class Mock<T> : IMock<T>
    where T : class
{
    public T Object { get; } = null!;

    public ISetup<TResult> Setup<TResult>(Func<T, TResult> setup)
    {
        return new Setup<TResult>();
    }
}
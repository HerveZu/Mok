using JetBrains.Annotations;

namespace Mok;

[PublicAPI]
public interface IMock<out T>
{
    T Object { get; }

    ISetup<TResult> Setup<TResult>(Func<T, TResult> setup);
}
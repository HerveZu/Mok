using JetBrains.Annotations;

namespace Mok;

[PublicAPI]
public sealed class Mock<T> : IMock<T>
    where T : class
{
    public T Object => throw new InvalidOperationException(
        $"This mock has not been generated." +
        $" Make sure to directly reference a mock from a field decorated with'{nameof(UseMockAttribute)}'"
    );

    public ISetup<TResult> Setup<TResult>(Func<T, TResult> setup)
    {
        return new Setup<TResult>();
    }
}
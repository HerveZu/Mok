using Mok;

namespace Examples.Test;

public class UnitTest1
{
    [UseMock(Identifier = "my-unique-id")]
    private readonly Mock<IMyService> _myMock = new();

    [Fact]
    public void Test1()
    {
        _myMock.Setup(m => m.GetNumber()).Returns(7);
        
        Assert.Equal(7, _myMock.Object.GetNumber());
    }
}
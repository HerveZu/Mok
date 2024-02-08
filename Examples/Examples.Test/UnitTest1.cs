using Mok;

namespace Examples.Test;

public class UnitTest1
{
    [UseMock(Identifier = "my-unique-id")]
    private readonly Mock<MyService> _myMock;
    
    public UnitTest1()
    {
        _myMock = new Mock<MyService>();
    }

    [UseMock(Identifier = "my-unique-id")]
    private Mock<MyService> GetMock() => _myMock;
    
    [Fact]
    public void Test1()
    {
        _myMock.Setup(m => m.A).Returns(7);
        
        // same mock instance here 
        GetMock().Setup(m => m.A).Returns(7);
    }
}
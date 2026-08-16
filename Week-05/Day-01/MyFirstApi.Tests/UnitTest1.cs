using MyFirstApi.Services;
namespace MyFirstApi.Tests;

public class UnitTest1
{
    [Fact]
    public void GetMessage_ReturnsExpectedMessage()
    {
       //Arrange
       var service = new MessageService();

       //Act
       var result = service.GetMessage();

       //Assert
       Assert.Equal("Hello from Dependancy Injection!", result);  
    }

   [Fact]
    public void GetMessage_ReturnsNotEmpty()
    {
       //Arrange
       var service = new MessageService();

       //Act
       var result = service.GetMessage();

       //Assert
       Assert.NotEmpty(result);  
    }

   [Fact]
    public void GetMessage_ReturnsNotNull()
    {
       //Arrange
       var service = new MessageService();

       //Act
       var result = service.GetMessage();

       //Assert
       Assert.NotNull(result);
    }

 [Theory]
 [InlineData(10, 5, 15)]
 [InlineData(-3, 3, 0)]
 [InlineData(0, 0, 0)]
  public void Add_ReturnsCorrectSum(int a, int b, int expected)
    {
        //Arrange
        var service = new MessageService();

        //Act
        var result = service.Add(a, b);

        //Assert
        Assert.Equal(expected, result);  
    }

}
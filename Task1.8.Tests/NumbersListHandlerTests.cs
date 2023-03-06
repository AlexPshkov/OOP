using Xunit;

namespace Task1._8.Tests;

public class NumbersListHandlerTests
{
    [Fact]
    public void NumbersListHandler_Handle_NormaInput_CorrectAnswer()
    {
        //Arrange
        List<double> list = new List<double>
        {
            1, 2, 2.5, 4, -5
        };
        
        //Act
        NumbersListHandler.Handle( list );
        
        //Assert
        List<double> mustBe = new List<double>
        {
            -8.5, 4, -7, 8, -14.5
        };
        
        Assert.Equal( 5, list.Count );
        Assert.Equal( mustBe, list );
    }
    
    [Fact]
    public void NumbersListHandler_Handle_EmptyList_NoErrors()
    {
        //Arrange
        List<double> list = new List<double>();
        
        //Act
        NumbersListHandler.Handle( list );
        
        //Assert
        Assert.Empty( list );
    }
}
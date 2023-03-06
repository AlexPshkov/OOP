using Xunit;

namespace Task1._8.Tests;

public class NumbersListHandlerTests
{
    [Fact]
    public void NumbersListHandler_Handle_NormaInput_CorrectAnswer()
    {
        //Arrange
        List<float> list = new List<float>
        {
            1, 2, 2.5F, 4, -5
        };
        
        //Act
        NumbersListHandler.Handle( list );
        
        //Assert
        List<float> mustBe = new List<float>
        {
            -8.5F, 4, -7, 8, -14.5F
        };
        
        Assert.Equal( 5, list.Count );
        Assert.Equal( mustBe, list );
    }
    
    [Fact]
    public void NumbersListHandler_Handle_EmptyList_NoErrors()
    {
        //Arrange
        List<float> list = new List<float>();
        
        //Act
        NumbersListHandler.Handle( list );
        
        //Assert
        Assert.Empty( list );
    }
}
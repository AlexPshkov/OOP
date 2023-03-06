using Task1._8.Sort;
using Xunit;

namespace Task1._8.Tests;

public class QuickSortTests
{
    [Fact]
    public void QuickSort_Sort_NormaInput_CorrectAnswer()
    {
        //Arrange
        List<float> list = new List<float>
        {
            1, 2, 2.5F, 4, -5
        };
        
        //Act
        List<float> sortedList = QuickSort.Sort( list );
        
        //Assert
        List<float> mustBe = new List<float>
        {
            -5, 1, 2, 2.5F, 4
        };
        
        Assert.Equal( mustBe, sortedList );
    }
    
    [Fact]
    public void QuickSort_Sort_BigInput_QuickWork()
    {
        //Arrange
        List<float> list = new List<float>();
        for ( int index = 0; index < 10000; index++ )
        {
            list.Add( (float) new Random().NextDouble() );
        }

        //Act
        DateTime timeStart = DateTime.Now;
        QuickSort.Sort( list );
        TimeSpan workingTime = DateTime.Now - timeStart;
        
        //Assert
        Assert.InRange( workingTime, TimeSpan.FromMicroseconds( 1 ), TimeSpan.FromMilliseconds( 5 ) );
    }
    
    [Fact]
    public void QuickSort_Sort_EmptyInput_NoErrors()
    {
        //Arrange
        List<float> list = new List<float>();

        //Act
        List<float> sortedList = QuickSort.Sort( list );
        
        //Assert
        Assert.Empty( sortedList );
    }
}
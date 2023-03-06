using Task1._8.Sort;
using Xunit;

namespace Task1._8.Tests;

public class QuickSortTests
{
    [Fact]
    public void QuickSort_Sort_NormaInput_CorrectAnswer()
    {
        //Arrange
        List<double> list = new List<double>
        {
            1, 2, 2.5, 4, -5
        };
        
        //Act
        List<double> sortedList = QuickSort.Sort( list );
        
        //Assert
        List<double> mustBe = new List<double>
        {
            -5, 1, 2, 2.5, 4
        };
        
        Assert.Equal( mustBe, sortedList );
    }
    
    [Fact]
    public void QuickSort_Sort_BigInput_QuickWork()
    {
        //Arrange
        List<double> list = new List<double>();
        for ( int index = 0; index < 10000; index++ )
        {
            list.Add( new Random().NextDouble() );
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
        List<double> list = new List<double>();

        //Act
        List<double> sortedList = QuickSort.Sort( list );
        
        //Assert
        Assert.Empty( sortedList );
    }
}
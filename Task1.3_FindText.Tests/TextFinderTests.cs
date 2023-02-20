using System.Text;
using Xunit;

namespace Task1._3_FindText.Tests;

public class TextFinderTests
{
    [Fact]
    public void FindText_OneMatch_CorrectAnswer()
    {
        //Arrange
        using MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes( "AlexPshkov\nAlex\nPshkov" ));
        using StreamReader streamReader = new StreamReader( memoryStream );

        //Act
        HashSet<int> lines = TextFinder.FindText( streamReader, "Alex" );
        
        //Assert
        Assert.Single( lines );
        Assert.Equal( 2, lines.ElementAt( 0 ) );
    }
    
    [Fact]
    public void FindText_TwoMatch_CorrectAnswer()
    {
        //Arrange
        using MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes( "Alex\nAlex\nPshkov" ));
        using StreamReader streamReader = new StreamReader( memoryStream );

        //Act
        HashSet<int> lines = TextFinder.FindText( streamReader, "Alex" );
        
        //Assert
        Assert.Equal( 2 , lines.Count );
        Assert.Equal( 1, lines.ElementAt( 0 ) );
        Assert.Equal( 2, lines.ElementAt( 1 ) );
    }
    
    [Fact]
    public void FindText_NoOneMatch_CorrectAnswer()
    {
        //Arrange
        using MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes( "AlexPshkov\nAlex\nPshkov" ));
        using StreamReader streamReader = new StreamReader( memoryStream );

        //Act
        HashSet<int> lines = TextFinder.FindText( streamReader, "Bob" );
        
        //Assert
        Assert.Empty( lines );
    }
    
    [Fact]
    public void FindText_EmptyFine_NoOneMatch()
    {
        //Arrange
        using MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes( "" ));
        using StreamReader streamReader = new StreamReader( memoryStream );

        //Act
        HashSet<int> lines = TextFinder.FindText( streamReader, "Bob" );
        
        //Assert
        Assert.Empty( lines );
    }
}
using Task2._5_HtmlDecode;
using Xunit;

namespace Tas2._5_HtmlDecoder.Tests;

public class HtmlDecoderTests
{
    [Fact]
    public void HtmlDecoder_HtmlDecode_NormalInput_CorrectAnswer()
    {
        //Arrange
        string inputString = "Cat &lt;says&gt; &quot;Meow&quot;. M&amp;M&apos;s";

        //Act
        string decodedString = HtmlDecoder.HtmlDecode( inputString );

        //Assert
        Assert.Equal( "Cat <says> \"Meow\". M&M’s", decodedString );
    }
    
    [Fact]
    public void HtmlDecoder_HtmlDecode_NoSpaces_CorrectAnswer()
    {
        //Arrange
        string inputString = "Myage&lt;1&gt;&lt;0&gt;";

        //Act
        string decodedString = HtmlDecoder.HtmlDecode( inputString );

        //Assert
        Assert.Equal( "Myage<1><0>", decodedString );
    }
    
    [Fact]
    public void HtmlDecoder_HtmlDecode_EmptyInput_NoErrors()
    {
        //Arrange
        string inputString = "";

        //Act
        string decodedString = HtmlDecoder.HtmlDecode( inputString );

        //Assert
        Assert.Equal( "", decodedString );
    }
    
    [Fact]
    public void HtmlDecoder_HtmlDecode_CorrectSmallInput_CorrectAnswer()
    {
        //Arrange
        string inputString = "&lt;";

        //Act
        string decodedString = HtmlDecoder.HtmlDecode( inputString );

        //Assert
        Assert.Equal( "<", decodedString );
    }
    
    [Fact]
    public void HtmlDecoder_HtmlDecode_WrongSmallInput1_CorrectAnswer()
    {
        //Arrange
        string inputString = "Here is &l; and no more";

        //Act
        string decodedString = HtmlDecoder.HtmlDecode( inputString );

        //Assert
        Assert.Equal( "Here is &l; and no more", decodedString );
    }
    
    [Fact]
    public void HtmlDecoder_HtmlDecode_WrongHtmlEntityInput2_CorrectAnswer()
    {
        //Arrange
        string inputString = "Here is &lt and no more";

        //Act
        string decodedString = HtmlDecoder.HtmlDecode( inputString );

        //Assert
        Assert.Equal( "Here is &lt and no more", decodedString );
    }
    
    [Fact]
    public void HtmlDecoder_HtmlDecode_WrongHtmlEntityInput3_CorrectAnswer()
    {
        //Arrange
        string inputString = "Here is lt; and no more";

        //Act
        string decodedString = HtmlDecoder.HtmlDecode( inputString );

        //Assert
        Assert.Equal( "Here is lt; and no more", decodedString );
    }
    
    [Fact]
    public void HtmlDecoder_HtmlDecode_WrongSmallInput4_CorrectAnswer()
    {
        //Arrange
        string inputString = "Here is &; and no more";

        //Act
        string decodedString = HtmlDecoder.HtmlDecode( inputString );

        //Assert
        Assert.Equal( "Here is &; and no more", decodedString );
    }
}
using Task5._1_UrlParser.Enums;
using Xunit;

namespace Task5._1_UrlParser.Tests;

public class UrlParserTests
{
    [Fact] public void UrlParser_ParseURL_HttpProtocolWithoutPort_CorrectOutput()
    {
        // Arrange
        string url = "http://www.mysite.com/docs/document1.html?page=30&lang=en#title";

        // Act
        bool result = UrlParser.ParseURL( url, out Protocol protocol, out int port, out string? host, out string? document );

        // Assert
        Assert.True( result );
        Assert.Equal( Protocol.HTTP, protocol );
        Assert.Equal( 80, port );
        Assert.Equal( "www.mysite.com", host );
        Assert.Equal( "docs/document1.html?page=30&lang=en#title", document );
    }
    
    [Fact] public void UrlParser_ParseURL_FtpProtocolWithoutPort_CorrectOutput()
    {
        // Arrange
        string url = "ftp://mysite.com/docs/document1.html?page=30&lang=en#title";

        // Act
        bool result = UrlParser.ParseURL( url, out Protocol protocol, out int port, out string? host, out string? document );

        // Assert
        Assert.True( result );
        Assert.Equal( Protocol.FTP, protocol );
        Assert.Equal( 21, port );
        Assert.Equal( "mysite.com", host );
        Assert.Equal( "docs/document1.html?page=30&lang=en#title", document );
    }
    
    [Fact] public void UrlParser_ParseURL_NormalInputWithPort_CorrectOutput()
    {
        // Arrange
        string url = "http://www.mysite.com:25565/docs/document1.html?page=30&lang=en#title";

        // Act
        bool result = UrlParser.ParseURL( url, out Protocol protocol, out int port, out string? host, out string? document );

        // Assert
        Assert.True( result );
        Assert.Equal( Protocol.HTTP, protocol );
        Assert.Equal( 25565, port );
        Assert.Equal( "www.mysite.com", host );
        Assert.Equal( "docs/document1.html?page=30&lang=en#title", document );
    }
    
    [Fact] public void UrlParser_ParseURL_WithPortWithoutPath_CorrectOutput()
    {
        // Arrange
        string url = "http://www.mysite.com:25565/";

        // Act
        bool result = UrlParser.ParseURL( url, out Protocol protocol, out int port, out string? host, out string? document );

        // Assert
        Assert.True( result );
        Assert.Equal( Protocol.HTTP, protocol );
        Assert.Equal( 25565, port );
        Assert.Equal( "www.mysite.com", host );
        Assert.Equal( "/", document );
    }
    
    [Fact] public void UrlParser_ParseURL_OnlyHost_CorrectOutput()
    {
        // Arrange
        string url = "http://www.mysite.com";

        // Act
        bool result = UrlParser.ParseURL( url, out Protocol protocol, out int port, out string? host, out string? document );

        // Assert
        Assert.True( result );
        Assert.Equal( Protocol.HTTP, protocol );
        Assert.Equal( 80, port );
        Assert.Equal( "www.mysite.com", host );
        Assert.Equal( "", document );
    }
    
    [Fact] public void UrlParser_ParseURL_InvalidPort_GetBadResult()
    {
        // Arrange
        string url = "http://www.mysite.com:/";

        // Act
        bool result = UrlParser.ParseURL( url, out Protocol protocol, out int port, out string? host, out string? document );

        // Assert
        Assert.False( result );
    }
    
    [Fact] public void UrlParser_ParseURL_InvalidHost_GetBadResult()
    {
        // Arrange
        string url = "http://";

        // Act
        bool result = UrlParser.ParseURL( url, out Protocol protocol, out int port, out string? host, out string? document );

        // Assert
        Assert.False( result );
    }
    
    [Fact] public void UrlParser_ParseURL_EmptyUrl_GetBadResult()
    {
        // Arrange
        string url = "";

        // Act
        bool result = UrlParser.ParseURL( url, out Protocol protocol, out int port, out string? host, out string? document );

        // Assert
        Assert.False( result );
    }
}
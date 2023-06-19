using NUnit.Framework;
using Task1._7_HttpUrl.Enums;
using Task1._7_HttpUrl.Exceptions;
using Task1._7_HttpUrl.Parsers;

namespace Task1._7_HttpUrl.Tests;

public class HttpUrlParserTests
{
    [Test]
    public void HttpUrlParser_ParseURL_HttpProtocolWithoutPort_CorrectOutput()
    {
        // Arrange
        const string url = "http://www.mysite.com/docs/document1.html?page=30&lang=en#title";

        // Act
        HttpUrlParser.ParseUrl( url, out Protocol protocol, out ushort port, out string host, out string document );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( protocol, Is.EqualTo( Protocol.Http ) );
            Assert.That( port, Is.EqualTo( 80 ) );
            Assert.That( host, Is.EqualTo( "www.mysite.com" ) );
            Assert.That( document, Is.EqualTo( "/docs/document1.html?page=30&lang=en#title" ) );
        } );
    }

    [Test]
    public void HttpUrlParser_ParseURL_FtpProtocolWithoutPort_CorrectOutput()
    {
        // Arrange
        const string url = "ftp://mysite.com/docs/document1.html?page=30&lang=en#title";

        // Act
        HttpUrlParser.ParseUrl( url, out Protocol protocol, out ushort port, out string host, out string document );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( protocol, Is.EqualTo( Protocol.Ftp ) );
            Assert.That( port, Is.EqualTo( 21 ) );
            Assert.That( host, Is.EqualTo( "mysite.com" ) );
            Assert.That( document, Is.EqualTo( "/docs/document1.html?page=30&lang=en#title" ) );
        } );
    }

    [Test]
    public void HttpUrlParser_ParseURL_NormalInputWithPort_CorrectOutput()
    {
        // Arrange
        const string url = "https://www.mysite.com:25565/docs/document1.html?page=30&lang=en#title";

        // Act
        HttpUrlParser.ParseUrl( url, out Protocol protocol, out ushort port, out string host, out string document );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( protocol, Is.EqualTo( Protocol.Https ) );
            Assert.That( port, Is.EqualTo( 25565 ) );
            Assert.That( host, Is.EqualTo( "www.mysite.com" ) );
            Assert.That( document, Is.EqualTo( "/docs/document1.html?page=30&lang=en#title" ) );
        } );
    }

    [Test]
    public void HttpUrlParser_ParseURL_WithPortWithoutPath_CorrectOutput()
    {
        // Arrange
        const string url = "https://www.mysite.com:25565/";

        // Act
        HttpUrlParser.ParseUrl( url, out Protocol protocol, out ushort port, out string host, out string document );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( protocol, Is.EqualTo( Protocol.Https ) );
            Assert.That( port, Is.EqualTo( 25565 ) );
            Assert.That( host, Is.EqualTo( "www.mysite.com" ) );
            Assert.That( document, Is.EqualTo( "/" ) );
        } );
    }

    [Test]
    public void HttpUrlParser_ParseURL_OnlyHost_CorrectOutput()
    {
        // Arrange
        const string url = "http://www.mysite.com";

        // Act
        HttpUrlParser.ParseUrl( url, out Protocol protocol, out ushort port, out string host, out string document );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( protocol, Is.EqualTo( Protocol.Http ) );
            Assert.That( port, Is.EqualTo( 80 ) );
            Assert.That( host, Is.EqualTo( "www.mysite.com" ) );
            Assert.That( document, Is.EqualTo( "" ) );
        } );
    }

    [Test]
    public void HttpUrlParser_ParseURL_OnlySimpleHost_CorrectOutput()
    {
        // Arrange
        const string url = "mysite";

        // Act
        HttpUrlParser.ParseUrl( url, out Protocol protocol, out ushort port, out string host, out string document );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( protocol, Is.EqualTo( Protocol.Http ) );
            Assert.That( port, Is.EqualTo( 80 ) );
            Assert.That( host, Is.EqualTo( "mysite" ) );
            Assert.That( document, Is.EqualTo( "" ) );
        } );
    }

    [Test]
    public void HttpUrlParser_ParseURL_OnlySimpleHostAndDocument_CorrectOutput()
    {
        // Arrange
        const string url = "mysite/Enter.aspx";

        // Act
        HttpUrlParser.ParseUrl( url, out Protocol protocol, out ushort port, out string host, out string document );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( protocol, Is.EqualTo( Protocol.Http ) );
            Assert.That( port, Is.EqualTo( 80 ) );
            Assert.That( host, Is.EqualTo( "mysite" ) );
            Assert.That( document, Is.EqualTo( "/Enter.aspx" ) );
        } );
    }

    [TestCase( "" )]
    [TestCase( "http://" )]
    [TestCase( "http://www.mysite.com:/" )]
    [TestCase( "http://http://www.mysite.com/" )]
    [TestCase( "http://www.mysite.com/doc.." )]
    [TestCase( "slp://www.mysite.com" )]
    [TestCase( "not mysiteEnter.aspx" )]
    public void HttpUrlParser_ParseURL_InvalidUrl_GetBadResult( string url )
    {
        // Act
        Assert.Throws<UrlParsingException>( () => HttpUrlParser.ParseUrl(
            url,
            out Protocol _,
            out ushort _,
            out string _,
            out string _ ) );
    }
}
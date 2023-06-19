using NUnit.Framework;
using Task1._7_HttpUrl.Enums;
using Task1._7_HttpUrl.Models;

namespace Task1._7_HttpUrl.Tests;

public class HttpUrlTests
{
    [Test]
    public void HttpUrl_Ctor1_NormalUrl_CorrectOutput()
    {
        // Arrange
        const string url = "mysite/Enter.aspx";

        // Act
        HttpUrl httpUrl = new HttpUrl( url );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( httpUrl.Protocol, Is.EqualTo( Protocol.Http ) );
            Assert.That( httpUrl.Port, Is.EqualTo( 80 ) );
            Assert.That( httpUrl.Domain, Is.EqualTo( "mysite" ) );
            Assert.That( httpUrl.Document, Is.EqualTo( "/Enter.aspx" ) );
        } );
    }

    [Test]
    public void HttpUrl_Ctor2_NormalParams_CorrectOutput()
    {
        // Arrange
        const Protocol protocol = Protocol.Http;
        const ushort port = 80;
        const string domain = "alexpshkov.ru";
        const string document = "/Enter.aspx";

        // Act
        HttpUrl httpUrl = new HttpUrl( domain, document, protocol, port );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( httpUrl.Protocol, Is.EqualTo( Protocol.Http ) );
            Assert.That( httpUrl.Port, Is.EqualTo( 80 ) );
            Assert.That( httpUrl.Domain, Is.EqualTo( "alexpshkov.ru" ) );
            Assert.That( httpUrl.Document, Is.EqualTo( "/Enter.aspx" ) );
        } );
    }
    
    [TestCase(Protocol.Http, (ushort) 0, "alexpshkov", "/site")]
    [TestCase((Protocol) 0, (ushort) 25565, "alexpshkov", "/site")]
    [TestCase(Protocol.Http, (ushort) 25565, "not foralexpshkov", "/site")]
    [TestCase(Protocol.Http, (ushort) 25565, "not foralexpshkov", "/site,")]
    [TestCase(Protocol.Http, (ushort) 25565, "foralexpshkov", "/site...")]
    public void HttpUrl_Ctor2_InvalidParams_GetArgumentException( Protocol protocol, ushort port, string domain, string document )
    {
        // Act && Assert
        Assert.Throws<ArgumentException>(() =>
        {
            HttpUrl httpUrl = new HttpUrl( domain, document, protocol, port );
        } );
    }
}
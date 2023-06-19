using System.Text;
using Task1._7_HttpUrl.Enums;
using Task1._7_HttpUrl.Parsers;
using Task1._7_HttpUrl.Validators;

namespace Task1._7_HttpUrl.Models;

public class HttpUrl
{
    private const char UrlPartSplitChar = '/';

    public readonly ushort Port;
    public readonly string Domain;
    public readonly string Document;
    public readonly Protocol Protocol;

    public HttpUrl( in string url )
    {
        HttpUrlParser.ParseUrl( url, out Protocol, out Port, out Domain, out Document );
    }

    public HttpUrl( in string domain, in string document = "", Protocol protocol = Protocol.Http ) :
        this( domain, document, protocol, (ushort) protocol )
    {
    }

    public HttpUrl( in string domain, in string document, in Protocol protocol, ushort port )
    {
        string formattedDocument = $"{( document.StartsWith( UrlPartSplitChar ) ? "" : UrlPartSplitChar )}{document}";

        HttpUrlValidator.ValidateDomain( domain );
        HttpUrlValidator.ValidateDocument( formattedDocument );
        HttpUrlValidator.ValidateProtocol( protocol );
        HttpUrlValidator.ValidatePort( port );

        Port = port;
        Domain = domain;
        Document = formattedDocument;
        Protocol = protocol;
    }

    public string GetUrl()
    {
        bool isDefaultPort = Port == (ushort) Protocol;
        string strPort = isDefaultPort ? "" : $":{Port}";

        return $"{Protocol.ToString().ToLower()}://{Domain}{strPort}{Document}";
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder( $"URL: {GetUrl()}\n" );
        stringBuilder.Append( $" > Domain: {Domain}\n" );
        stringBuilder.Append( $" > Protocol: {Protocol}\n" );
        stringBuilder.Append( $" > Port: {Port}\n" );
        stringBuilder.Append( $" > Document: {Document}\n" );

        return stringBuilder.ToString();
    }
}
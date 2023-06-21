using System.Text.RegularExpressions;
using Task1._7_HttpUrl.Enums;
using Task1._7_HttpUrl.Exceptions;

namespace Task1._7_HttpUrl.Parsers;

public static partial class HttpUrlParser
{
    [GeneratedRegex( @"^(?:(?<protocol>\w+):\/\/)?(?<domain>[^\/\r\n\s:]+)(?::(?<port>\d+))?(?<document>\/([^.,]+\.{0,1})*){0,}?$" )]
    private static partial Regex UrlRegex();

    public static void ParseUrl( string url, out Protocol protocol, out ushort port, out string domain, out string document )
    {
        Match match = UrlRegex().Match( url );

        if ( !match.Success )
        {
            throw new UrlParsingException( $"Invalid URL format. URL: {url}" );
        }

        GetProtocol( match, out protocol );
        GetDomain( match, out domain );
        GetPort( match, protocol, out port );
        GetDocument( match, out document );
    }

    private static void GetProtocol( Match match, out Protocol protocol )
    {
        if ( !match.Groups.TryGetValue( "protocol", out Group? group ) )
        {
            throw new UrlParsingException( "There is no protocol in URL" );
        }

        if ( string.IsNullOrEmpty( group.Value ) )
        {
            protocol = Protocol.Http;
            return;
        }

        if ( !Enum.TryParse( group.Value.ToUpper(), true, out protocol ) )
        {
            throw new UrlParsingException( $"Invalid protocol in URL: {group.Value}" );
        }
    }

    private static void GetDomain( Match match, out string domain )
    {
        if ( !match.Groups.TryGetValue( "domain", out Group? group ) )
        {
            throw new UrlParsingException( "There is no domain in URL" );
        }

        domain = group.Value;
    }

    // Большая вложенность
    private static void GetPort( Match match, Protocol protocol, out ushort port )
    {
        if ( match.Groups.TryGetValue( "port", out Group? group ) )
        {
            if ( !string.IsNullOrEmpty( group.Value ) )
            {
                if ( !ushort.TryParse( group.Value, out port ) )
                {
                    throw new UrlParsingException( "Invalid port in URL. Port must be number from 1 to 65535" );
                }

                return;
            }
        }

        if ( protocol <= 0 )
        {
            throw new UrlParsingException( "Invalid port in URL" );
        }

        port = protocol switch
        {
            Protocol.Http => 80,
            Protocol.Https => 443,
            Protocol.Ftp => 21,
            _ => throw new ArgumentOutOfRangeException( nameof( protocol ), protocol, null )
        };
    }

    private static void GetDocument( Match match, out string document )
    {
        if ( match.Groups.TryGetValue( "document", out Group? group ) )
        {
            document = group.Value;
            return;
        }

        document = string.Empty;
    }
}
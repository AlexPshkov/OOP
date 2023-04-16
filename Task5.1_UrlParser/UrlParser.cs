using System.Text.RegularExpressions;
using Task5._1_UrlParser.Enums;

namespace Task5._1_UrlParser;

public static partial class UrlParser
{
    [GeneratedRegex(@"(?'protocol'.+):\/\/(?'host'(\.?\w+){1,3})(?::?(?'port'\d+))?(?:/?(?'path'.+))?")]
    private static partial Regex UrlRegex();
    
    
    // What this code does: 
    // 1. It takes the input string and tries to match it with the regex
    // 2. If the regex matches, it tries to get the protocol, host, port and document from the match
    // 3. If any of the steps fail, it returns false
    // 4. If all the steps succeed, it returns true
    
    // 
    public static bool ParseURL( string url, out Protocol protocol, out int port, out string? host, out string? document )
    {
        Match match = UrlRegex().Match( url );

        try
        {
            TryGetProtocol( match, out protocol );
            TryGetHost( match, out host );
            TryGetPort( match, protocol, out port );
            TryGetDocument( match, out document );
            return true;
        }
        catch ( Exception )
        {
            protocol = Protocol.Unknown;
            host = null;
            document = null;
            port = -1;

            return false;
        }
    }

    private static void TryGetProtocol( Match match, out Protocol protocol )
    {
        if ( !match.Groups.TryGetValue( "protocol", out Group? group ) )
        {
            throw new ArgumentException( "There is no protocol in URL" );
        }

        if ( !Enum.TryParse( group.Value.ToUpper(), out protocol ) )
        {
            throw new ArgumentException( "Invalid protocol in URL" );
        }
    }
    
    private static void TryGetHost( Match match, out string host )
    {
        if ( !match.Groups.TryGetValue( "host", out Group? group ) )
        {
            throw new ArgumentException( "There is no host in URL" );
        }

        host = group.Value;
    }
    
    private static void TryGetPort( Match match, Protocol protocol, out int port )
    {
        if ( match.Groups.TryGetValue( "port", out Group? group ) )
        {
            if ( !string.IsNullOrWhiteSpace( group.Value ) )
            {
                port = int.Parse( group.Value );
                return;
            }
        }

        port = protocol switch {
            Protocol.HTTP => 80,
            Protocol.HTTPS => 443,
            Protocol.FTP => 21,
            Protocol.SFTP => 22,
            _ => throw new ArgumentException( "Invalid port in URL" )
        };
    }
    
    private static void TryGetDocument( Match match, out string? document )
    {
        if ( !match.Groups.TryGetValue( "path", out Group? group ) )
        {
            document = null;
            return;
        }

        if ( group.Value.StartsWith( ":" ) )
        {
            throw new ArgumentException( "Invalid port in URL" );
        }

        if ( group.Value.StartsWith( "." ) )
        {
            throw new ArgumentException( "Invalid host in URL" );
        }
        
        document = group.Value;
    }
}
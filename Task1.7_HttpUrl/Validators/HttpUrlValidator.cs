using System.Text.RegularExpressions;
using Task1._7_HttpUrl.Enums;

namespace Task1._7_HttpUrl.Validators;

public static partial class HttpUrlValidator
{
    [GeneratedRegex(@"^(?<domain>[^\/\r\n\s:]+)$")]
    private static partial Regex HostRegex();
        
    [GeneratedRegex(@"^(?<document>\/([^.,]+\.{0,1})*)$")]
    private static partial Regex DocumentRegex();

    public static void ValidateDomain( string domain )
    {
        if ( string.IsNullOrWhiteSpace( domain ) )
        {
            throw new ArgumentException( "Domain can't be empty" );
        }
        
        if ( !HostRegex().IsMatch( domain ) )
        {
            throw new ArgumentException( $"Invalid domain value: {domain}" );
        }
    }
    
    public static void ValidateDocument( string? document )
    {
        if ( string.IsNullOrEmpty( document ) )
        {
            return;
        }

        if ( !DocumentRegex().IsMatch( document ) )
        {
            throw new ArgumentException( $"Invalid document value {document}" );
        }
    }
    
    public static void ValidateProtocol( Protocol protocol )
    {
        if ( !Enum.IsDefined( protocol ) )
        {
            throw new ArgumentException( $"Invalid protocol value: {protocol}" );
        }
    }

    public static void ValidatePort( int port )
    {
        if ( port is <= 0 or > ushort.MaxValue )
        {
            throw new ArgumentException( $"Port can't be more then {ushort.MaxValue} and less then 0", nameof( port ) );
        }
    }
}
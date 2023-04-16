using Task5._1_UrlParser.Enums;

namespace Task5._1_UrlParser;

public static class Program
{
    public static int Main()
    {
        // Сделать обработку айпишников 127.0.01 ...
        // Сделать обработку localhost/:8080
        // Ограничение порта от 1 до 65535
        while ( true )
        {
            string? inputUrl = Console.ReadLine();
            if ( string.IsNullOrWhiteSpace( inputUrl ) )
            {
                continue;
            }

            if ( !UrlParser.ParseURL( inputUrl, out Protocol protocol, out int port, out string? host, out string? document ) )
            {
                Console.WriteLine( "Invalid URL" );
                continue;
            }
            
            Console.WriteLine( $"PROTOCOL: {protocol}" );
            Console.WriteLine( $"HOST: {host}" );
            Console.WriteLine( $"PORT: {port}" );
            Console.WriteLine( $"DOC: {document}" );
        }
    }
}
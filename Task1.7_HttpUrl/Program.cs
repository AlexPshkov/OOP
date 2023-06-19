using Task1._7_HttpUrl.Exceptions;
using Task1._7_HttpUrl.Models;

namespace Task1._7_HttpUrl;

static class Program
{
    public static void Main()
    {
        while ( Console.ReadLine() is { } line )
        {
            try
            {
                Console.WriteLine( new HttpUrl( line ) );
            }
            catch ( UrlParsingException exception )
            {
                Console.WriteLine( $"UrlParsingError: {exception.Message}" );
            }
        }
    }
}



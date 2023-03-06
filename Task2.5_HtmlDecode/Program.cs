namespace Task2._5_HtmlDecode;

public static class Program
{
    public static int Main()
    {
        string? inputString = Console.ReadLine();
        if ( string.IsNullOrEmpty( inputString ) )
        {
            Console.WriteLine( "Input string can't be empty" );
            return 1;
        }

        string decodedText = HtmlDecoder.HtmlDecode( inputString );

        Console.WriteLine( decodedText );

        return 0;
    }
}
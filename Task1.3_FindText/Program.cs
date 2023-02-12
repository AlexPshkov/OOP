namespace Task1._3_FindText;

public static class Program
{
    public static int Main( string[] args )
    {
        try
        {
            CheckInputArguments( args, 2 );
            Find( args[0], args[1] );
        }
        catch ( Exception exception )
        {
            Console.WriteLine( exception.Message );
            return 1;
        }

        return 0;
    }

    private static void Find( string filePath, string textToFind )
    {
        using StreamReader streamReader = new StreamReader( filePath );
        HashSet<int> lines = TextFinder.FindText( streamReader, textToFind );
           
        if ( !lines.Any() )
        {
            throw new Exception( "Text not found" );
        }
        
        foreach ( int line in lines )
        {
            Console.WriteLine( line ); 
        }
    }
    
    private static void CheckInputArguments( IReadOnlyCollection<string> args, int reqAmount )
    {
        if ( args.Count != reqAmount )
        {
            throw new ArgumentException( $"Amount of arguments must be {reqAmount}" );
        }
    }
}
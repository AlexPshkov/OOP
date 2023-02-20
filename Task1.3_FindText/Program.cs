namespace Task1._3_FindText;

public static class Program
{
    public static int Main( string[] args )
    {
        try
        {
            CheckInputArguments( args );
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
    
    //DONE: Не просто ошибку, а помощь по вводу
    private static void CheckInputArguments( IReadOnlyCollection<string> args )
    {
        const int reqAmount = 2;
        if ( args.Count != reqAmount )
        {
            throw new ArgumentException( "Input must be: <file name> <text to search>" );
        }
    }
}
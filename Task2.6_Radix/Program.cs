namespace Task2._6_Radix;

public static class Program
{
    public static int Main( string[] args )
    {
        try
        {
            Console.WriteLine( (int)'a' );
            Console.WriteLine( (int)'9' );
            CheckInputArguments( args );
            
            int from = GetIntFromArgs( 0, args );
            int to = GetIntFromArgs( 1, args );

            Console.WriteLine( RadixConverter.Convert( from, to, args[2] ) );
        }
        catch ( Exception exception )
        {
            Console.WriteLine( exception.Message );
            return 1;
        }

        return 0;
    }
    
    private static int GetIntFromArgs( int position, IReadOnlyCollection<string> args )
    {
        if ( int.TryParse( args.ElementAt( position ), out int result ) )
        {
            return result;
        }

        throw new ArgumentException( $"Argument {args.ElementAt( position )} is not a number" );
    }

    //DONE: Не просто ошибку, а помощь по вводу
    private static void CheckInputArguments( IReadOnlyCollection<string> args )
    {
        const int reqAmount = 3;
        if ( args.Count != reqAmount )
        {
            throw new ArgumentException( "Input must be: <source notation> <destination notation> <value>" );
        }
    }
}
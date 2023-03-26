namespace Task4._4_PrimeNumbers;

public static class Program
{
    public static int Main( string[] args )
    {
        int upperBound;
        try
        {
            CheckInputArguments( args );
            upperBound = TryGetPositiveNumber( args[0] );
        }
        catch ( Exception exception )
        {
            Console.WriteLine( exception.Message );
            return 1;
        }

        // Гарантировать порядок
        HashSet<int> primeNumbers = EratosthenesSieve.GeneratePrimeNumbersSet( upperBound );
        
        Console.WriteLine( string.Join( ", ", primeNumbers ) );
        
        return 0;
    }

    private static int TryGetPositiveNumber( string strNumber )
    {
        if ( !int.TryParse( strNumber, out int number ) )
        {
            throw new ArgumentException( $"{strNumber} is not a number" );
        }

        if ( number < 0 )
        {
            throw new ArgumentException( $"{strNumber} is not a positive number" );
        }

        return number;
    }
    
    private static void CheckInputArguments( IReadOnlyCollection<string> args )
    {
        const int reqAmount = 1;
        if ( args.Count != reqAmount )
        {
            throw new ArgumentException( "Input must be: <upperBound>" );
        }
    }
}
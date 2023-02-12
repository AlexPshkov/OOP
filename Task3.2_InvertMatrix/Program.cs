using System.Globalization;

namespace Task3._2_InvertMatrix;

public static class Program
{
    public static int Main( string[] args )
    {
        try
        {
            CheckInputArguments( args, 1 );
            using MatrixFileReader matrixFileReader = new MatrixFileReader( args[0] );
            float[][] invertedMatrix = MatrixInverter.InvertMatrix( matrixFileReader.Matrix );
            PrintMatrix( invertedMatrix );
        }
        catch ( Exception exception )
        {
            Console.WriteLine( exception );
            return 1;
        }
        return 0;
    }

    private static void PrintMatrix( IReadOnlyList<float[]> matrix )
    {
        for ( int i = 0; i < 3; i++ )
        {
            for ( int j = 0; j < 3; j++ )
            {
                double normalizedNumber = Math.Round( matrix[i][j], 3 );
                if ( normalizedNumber == 0 )
                {
                    normalizedNumber = 0;
                }
                
                string strNumber = normalizedNumber
                    .ToString( CultureInfo.InvariantCulture )
                    .PadRight( 8 );
                
                Console.Write( strNumber ); 
            }
            
            Console.WriteLine();
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
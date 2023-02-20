using System.Globalization;
using System.Text;

namespace Task3._2_InvertMatrix;

public static class Program
{
    public static int Main( string[] args )
    {
        try
        {
            CheckInputArguments( args );
            using MatrixFileReader matrixFileReader = new MatrixFileReader( args[0] );
            float[][] invertedMatrix = MatrixInverter.InvertMatrix( matrixFileReader.Matrix );
            PrintMatrix( invertedMatrix );
        }
        catch ( Exception exception )
        {
            Console.WriteLine( exception.Message );
            return 1;
        }
        return 0;
    }

    private static void PrintMatrix( IReadOnlyList<float[]> matrix )
    {
        for ( int i = 0; i < 3; i++ )
        {
            List<string> strNumbers = new List<string>();
            for ( int j = 0; j < 3; j++ )
            {
                double normalizedNumber = Math.Round( matrix[i][j], 3 );
                if ( normalizedNumber == 0 )
                {
                    normalizedNumber = 0;
                }

                strNumbers.Add(  normalizedNumber.ToString( CultureInfo.InvariantCulture ) );
            }
            
            Console.WriteLine( string.Join( ' ', strNumbers ) );
        }
    }
    
    private static void CheckInputArguments( IReadOnlyCollection<string> args )
    {
        const int reqAmount = 1;
        if ( args.Count != reqAmount )
        {
            throw new ArgumentException( "Input must be: <matrix file1>" );
        }
    }
}
namespace Task1._8.IO;

public static class ConsoleReader
{
    private const char NumberSeparator = ' ';
    
    public static List<double> ReadNumbers()
    {
        string? inputString = Console.ReadLine();
        if ( string.IsNullOrEmpty( inputString ) )
        {
            throw new ArgumentNullException( inputString );
        }

        List<double> numbers = new List<double>();
        
        string[] strNumbers = inputString.Split( NumberSeparator );
        foreach ( string strNumber in strNumbers )
        {
            if ( !double.TryParse( strNumber, out double value ) )
            {
                throw new ArgumentException( $"'{strNumber}' is not a correct value. Only numbers allowed" );
            }
            numbers.Add( value );
        }

        return numbers;
    }
}
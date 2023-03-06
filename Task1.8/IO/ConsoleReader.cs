namespace Task1._8.IO;

public static class ConsoleReader
{
    private const char NumberSeparator = ' ';
    
    public static List<float> ReadNumbers()
    {
        string? inputString = Console.ReadLine();
        if ( string.IsNullOrEmpty( inputString ) )
        {
            throw new ArgumentNullException( inputString );
        }

        List<float> numbers = new List<float>();
        
        string[] strNumbers = inputString.Split( NumberSeparator );
        foreach ( string strNumber in strNumbers )
        {
            if ( !float.TryParse( strNumber, out float value ) )
            {
                throw new ArgumentException( $"'{strNumber}' is not a correct value. Only numbers allowed" );
            }
            numbers.Add( value );
        }

        return numbers;
    }
}
namespace Task1._2_Shapes;

public static class Utils
{
    private const int AmountDigitsAfterComma = 3;
    
    public static double Round( double number )
    {
        return Math.Round( number, AmountDigitsAfterComma );
    }
}
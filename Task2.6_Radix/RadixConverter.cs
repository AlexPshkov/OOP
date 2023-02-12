using System.ComponentModel;
using System.Numerics;
using System.Text;

namespace Task2._6_Radix;

public static class RadixConverter
{
    private const int CharNumberOffset = 87; 
    
    
    public static string Convert( int from, int to, string value )
    {
        bool minusFlag = false;
        string normalizedValue = value.Trim().ToLower();

        if ( normalizedValue.StartsWith( "-" ) )
        {
            minusFlag = true;
            normalizedValue = normalizedValue[1..];
        }
        
        BigInteger decimalValue = ConvertToDecimal( from, normalizedValue );

        return (minusFlag ? "-" : "") + ConvertToAnother( to, decimalValue );
    }
    
    private static BigInteger ConvertToDecimal( int from, string value )
    {
        BigInteger result = 0;
        
        for ( int i = 0; i < value.Length; i++ )
        {
            int numericalRepresentation = GetNumericalRepresentation( from, value[i] );
            result += numericalRepresentation * Pow( from, value.Length - i - 1 );
        }

        return result;
    }

    private static string ConvertToAnother( int to, BigInteger value )
    {
        StringBuilder stringBuilder = new StringBuilder();

        while ( value >= to )
        {
            BigInteger residue = value % to;
            stringBuilder.Append( GetStringRepresentation( residue ) );
            value /= to;
        }

        stringBuilder.Append( GetStringRepresentation( value ) );

        return new string(stringBuilder.ToString().Reverse().ToArray());
    }

    private static string GetStringRepresentation( BigInteger number )
    {
        if ( number >= 0 && number <= 9 )
        {
            return number.ToString().ToUpper();
        }

        BigInteger code = number + CharNumberOffset;
        return ((char) code).ToString().ToUpper();
    }
    
    private static int GetNumericalRepresentation( int from, char strNumber )
    {
        if ( int.TryParse( strNumber.ToString(), out int result ) )
        {
            return result;
        }

        int code = strNumber - CharNumberOffset;
        if ( code >= from )
        {
            throw new InvalidEnumArgumentException( $"Invalid number {strNumber}. More than a number calculus system" );
        }
        if ( code is > 35 or < 10 )
        {
            throw new InvalidEnumArgumentException( $"Invalid number {strNumber}. More or less, then possible" );
        }
        
        return code;
    }
    
    private static BigInteger Pow( int from, int grade )
    {
        BigInteger result = BigInteger.One;

        for ( int i = 0; i < grade; i++ )
        {
            result *= from;
        }

        return result;
    }
}
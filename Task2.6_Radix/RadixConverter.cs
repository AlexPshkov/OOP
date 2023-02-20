using System.ComponentModel;
using System.Numerics;
using System.Text;

namespace Task2._6_Radix;

public static class RadixConverter
{
    /// <summary>
    /// CharNumberOffset = Позиция 'a' - То, какой цифре равен 'a'
    /// CharNumberOffset = 97 - 10'
    /// </summary>
    private const int CharNumberOffset = 87;
    
    private const int MaxAlphabet = 35; 
    private const int MinAlphabet = 10; 
    
    private const int MaxDecimalNumber = 9; 
    private const int MinDecimalNumber = 0; 
    
    private const int MaxRadixValue = 36; 
    private const int MinRadixValue = 2; 
    
    public static string Convert( int initialRadix, int requiredRadix, string value )
    {
        CheckRadix( initialRadix );
        CheckRadix( requiredRadix );
        
        bool minusFlag = false;
        string normalizedValue = value.Trim().ToLower();

        if ( normalizedValue.StartsWith( "-" ) )
        {
            minusFlag = true;
            normalizedValue = normalizedValue[1..];
        }
        
        BigInteger decimalValue = ConvertStringToNumber( normalizedValue, initialRadix );
        return (minusFlag ? "-" : "") + ConvertNumberToString( decimalValue, requiredRadix );
    }

    private static void CheckRadix( int radix )
    {
        if ( radix is > MaxRadixValue or < MinRadixValue )
        {
            throw new Exception( $"Invalid radix {radix}. More then 36 or less then 2" );
        }
    }
    
    //DONE: В функциях использовать название аргумента абстрактно от общего контекста
    private static BigInteger ConvertStringToNumber( string value, int radix )
    {
        BigInteger result = 0;
        
        for ( int i = 0; i < value.Length; i++ )
        {
            int numericalRepresentation = GetNumericalRepresentation( radix, value[i] );
            result += numericalRepresentation * Pow( radix, value.Length - i - 1 );
        }

        return result;
    }

    //DONE: Переименовать в ConvertNumberToString
    //DONE: Перенести радикс на вторую позицию и дать значение по умолчанию
    private static string ConvertNumberToString( BigInteger value, int radix = 10 )
    {
        StringBuilder stringBuilder = new StringBuilder();

        while ( value >= radix )
        {
            BigInteger residue = value % radix;
            stringBuilder.Append( GetStringRepresentation( residue ) );
            value /= radix;
        }

        stringBuilder.Append( GetStringRepresentation( value ) );

        return new string(stringBuilder.ToString().Reverse().ToArray());
    }

    private static string GetStringRepresentation( BigInteger number )
    {
        if ( number >= MinDecimalNumber && number <= MaxDecimalNumber )
        {
            return number.ToString();
        }

        BigInteger code = number + CharNumberOffset;
        return ((char) code).ToString().ToUpper();
    }
    
    private static int GetNumericalRepresentation( int radix, char strNumber )
    {
        if ( int.TryParse( strNumber.ToString(), out int result ) )
        {
            return result;
        }

        int code = strNumber - CharNumberOffset;
        if ( code >= radix )
        {
            throw new InvalidEnumArgumentException( $"Invalid number {strNumber}. More than possible value in radix" );
        }
        if ( code is > MaxAlphabet or < MinAlphabet )
        {
            throw new InvalidEnumArgumentException( $"Invalid number {strNumber}. More or less, then possible" );
        }
        
        return code;
    }
    
    //Обойтись без возвездения
    private static BigInteger Pow( int number, int grade )
    {
        BigInteger result = BigInteger.One;

        for ( int i = 0; i < grade; i++ )
        {
            result *= number;
        }

        return result;
    }
}
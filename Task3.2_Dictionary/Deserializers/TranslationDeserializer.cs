using Task3._2_Dictionary.Exceptions;
using Task3._2_Dictionary.Models;

namespace Task3._2_Dictionary.Deserializers;

public static class TranslationDeserializer
{
    // В строке должно быть 4 кавычки. Две для ключа и две для значения
    private const int RequiredQuotaAmount = 4;
    
    public static Translation Deserialize( string inputString )
    {
        List<int> quotaIndexes = FindQuotaIndexes( inputString );
        if ( quotaIndexes.Count != RequiredQuotaAmount )
        {
            throw new TranslationDeserializeException( $"{inputString}. Found {quotaIndexes.Count} of quotas but must be {RequiredQuotaAmount}" );
        }

        Translation translation = new Translation
        {
            Word = GetSubString( inputString, quotaIndexes[0], quotaIndexes[1] ),
            WordTranslation = GetSubString( inputString, quotaIndexes[2], quotaIndexes[3] )
        };

        return translation;
    }
    
    private static string GetSubString( string inputString, int startIndex, int endIndex )
    {
        return inputString.Substring( startIndex + 1, endIndex- startIndex - 1 );
    }
    
    private static List<int> FindQuotaIndexes( string inputString )
    {
        List<int> quotaIndexes = new List<int>();
        
        int quotaIndex = inputString.IndexOf( '"' );
        while ( quotaIndex != -1 )
        {
            quotaIndexes.Add( quotaIndex );
            quotaIndex = inputString.IndexOf(  '"', quotaIndex + 1 );
        }

        return quotaIndexes;
    }
}
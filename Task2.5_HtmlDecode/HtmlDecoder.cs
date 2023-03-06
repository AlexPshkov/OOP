using System.Text;

namespace Task2._5_HtmlDecode;

public static class HtmlDecoder
{
    private const int MaxHtmlKeyLength = 4;
    private const char HtmlEntityPrefix = '&';
    
    private static readonly Dictionary<string, char> HtmlEntityComparisonTable = new Dictionary<string, char>
    {
        {"amp;", '&'},
        {"gt;", '>'},
        {"lt;", '<'},
        {"apos;", '’'},
        {"quot;", '\"'}
    };


    public static string HtmlDecode( string html )
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        for ( int index = 0; index < html.Length; index++ )
        {
            char currentChar = html[index];

            if ( currentChar != HtmlEntityPrefix )
            {
                stringBuilder.Append( currentChar );
                continue;
            }

            if ( !TryToFindHtmlEntity( html, index + 1, out int endPosition, out string htmlEntity ) )
            {
                stringBuilder.Append( currentChar );
                continue;
            }
            
            if ( !HtmlEntityComparisonTable.TryGetValue( htmlEntity, out char decodedValue ) )
            {
                throw new KeyNotFoundException();
            }

            stringBuilder.Append( decodedValue );
            index = endPosition;
        }

        return stringBuilder.ToString();
    }

    private static bool TryToFindHtmlEntity( string inputString, int startPosition, out int endPosition, out string htmlEntity )
    {
        htmlEntity = string.Empty;

        int maxPosition = Math.Min( inputString.Length, startPosition + MaxHtmlKeyLength + 1 );
        for ( endPosition = startPosition; endPosition < maxPosition; endPosition++ )
        {
            htmlEntity += inputString[endPosition];

            if ( HtmlEntityComparisonTable.ContainsKey( htmlEntity ) )
            {
                return true;
            }
        }

        return false;
    }
}
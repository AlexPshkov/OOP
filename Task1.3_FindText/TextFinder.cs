namespace Task1._3_FindText;

public static class TextFinder
{
    public static HashSet<int> FindText( StreamReader streamReader, string textToFind )
    {
        HashSet<int> lineNumbers = new HashSet<int>();

        int linesCounter = 1;
        while ( !streamReader.EndOfStream )
        {
            if ( IsSuchText( streamReader.ReadLine(), textToFind ) )
            {
                lineNumbers.Add( linesCounter );
            }
            
            linesCounter++;
        }

        return lineNumbers;
    }

    
    /// <summary>
    /// Checks if inputString contains some text string
    /// </summary>
    /// <param name="inputString">Large text</param>
    /// <param name="textToFind">Some string</param>
    /// <param name="fullWord">Allows to use partial match</param>
    /// <returns>true or false</returns>
    private static bool IsSuchText( string? inputString, string textToFind, bool fullWord = true )
    {
        if ( inputString == null )
        {
            return false;
        }
        
        bool contains = inputString.Contains( textToFind );

        if ( !contains || !fullWord )
        {
            return contains;
        }
        
        int startPosition = inputString.IndexOf( textToFind, StringComparison.Ordinal );
        int endPosition = startPosition + textToFind.Length;

        bool startEmpty = startPosition == 0 || inputString[startPosition - 1] == ' ';
        bool endEmpty = endPosition == inputString.Length || inputString[endPosition] == ' ';
        
        return startEmpty && endEmpty;
    }
}
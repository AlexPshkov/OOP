namespace Task3._2_Dictionary.Models;

public class Dictionary
{
    //Время поиска должны быть не хуже чем O(logN)
    private List<Translation> WordsTranslations { get; }
    private bool _isNewTranslations;

    public Dictionary()
    {
        WordsTranslations = new List<Translation>();
    }

    public Dictionary( List<Translation> wordsTranslations )
    {
        WordsTranslations = wordsTranslations;
    }

    public bool IsNewTranslations()
    {
        return _isNewTranslations;
    }

    public void AddTranslation( string word, string translation )
    {
        string sanitizedWord = GetSanitizedString( word );
        string sanitizedTranslation = GetSanitizedString( translation );

        Translation wordTranslation = new Translation
        {
            Word = sanitizedWord, 
            WordTranslation = sanitizedTranslation
        };

        WordsTranslations.Add( wordTranslation );
        _isNewTranslations = true;
    }

    public List<Translation> GetTranslations()
    {
        return new List<Translation>( WordsTranslations );
    }
    
    public List<string> GetTranslations( string word )
    {
        List<string> translations = new List<string>();

        foreach ( Translation translation in WordsTranslations )
        {
            if ( translation.Word.Equals( word, StringComparison.CurrentCultureIgnoreCase ) )
            {
                translations.Add( translation.WordTranslation );
                continue;
            }
            
            if ( translation.WordTranslation.Equals( word, StringComparison.CurrentCultureIgnoreCase ) )
            {
                translations.Add( translation.Word );
            }
        }

        return translations;
    }

    private static string GetSanitizedString( string inputString )
    {
        string withoutQuotas = inputString.Replace( '"', '”' );
        string trimmed = withoutQuotas.Trim();

        return trimmed;
    }
}
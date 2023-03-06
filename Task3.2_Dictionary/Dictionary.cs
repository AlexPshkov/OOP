namespace Task3._2_Dictionary;

public class Dictionary
{
    public List<KeyValuePair<string, string>> WordsTranslations { get; }
    private bool _isNewTranslations;

    public Dictionary()
    {
        WordsTranslations = new List<KeyValuePair<string, string>>();
    }

    public Dictionary( List<KeyValuePair<string, string>> wordsTranslations )
    {
        WordsTranslations = wordsTranslations;
    }

    public bool IsNewTranslations()
    {
        return _isNewTranslations;
    }
    
    public void AddTranslation( string word, string translation )
    {
        WordsTranslations.Add( new KeyValuePair<string, string>( word, translation ) );
        _isNewTranslations = true;
    }
    
    public IEnumerable<string> GetTranslations( string word )
    {
        List<string> translations = new List<string>();

        foreach ( KeyValuePair<string, string> keyValuePair in WordsTranslations )
        {
            if ( keyValuePair.Key.Equals( word ) )
            {
                translations.Add( keyValuePair.Value );
                continue;
            }
            
            if ( keyValuePair.Value.Equals( word ) )
            {
                translations.Add( keyValuePair.Key );
            }
        }
        return translations;
    }
}
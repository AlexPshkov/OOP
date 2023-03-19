using Task3._2_Dictionary.Deserializers;
using Task3._2_Dictionary.Models;
using Task3._2_Dictionary.Serializers;

namespace Task3._2_Dictionary.Repositories;

public class DictionaryRepository
{
    private readonly string _filePath;

    public DictionaryRepository( string filePath )
    {
        _filePath = filePath;
    }
    
    public void SaveDictionary( Dictionary dictionary )
    {
        using StreamWriter streamWriter = new StreamWriter( _filePath );

        string serializedDictionary = string
            .Join( '\n', dictionary.WordsTranslations.Select( TranslationSerializer.Serialize ) );
        streamWriter.Write( serializedDictionary );

        streamWriter.Close();
    }
    
    public Dictionary GetDictionary()
    {
        if ( !File.Exists( _filePath ) )
        {
            return new Dictionary();
        }
        
        using StreamReader streamReader = new StreamReader( _filePath );

        List<Translation> wordsTranslations = new List<Translation>();

        string? line = streamReader.ReadLine();
        while ( !string.IsNullOrWhiteSpace( line ) )
        {
            wordsTranslations.Add( TranslationDeserializer.Deserialize( line ) );
            
            line = streamReader.ReadLine();
        }

        streamReader.Close();

        return new Dictionary( wordsTranslations );
    }
}
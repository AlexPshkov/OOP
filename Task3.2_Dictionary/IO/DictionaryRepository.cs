using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Task3._2_Dictionary.IO;

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
        
        string serializedDictionary = JsonSerializer.Serialize( dictionary );
        streamWriter.Write( serializedDictionary );
        streamWriter.Flush();
        
        streamWriter.Close();
    }
    
    public Dictionary GetDictionary()
    {
        using StringReader streamReader = new StringReader( _filePath );

        string? serializedDictionary = streamReader.ReadLine();
        if ( serializedDictionary == null )
        {
            return new Dictionary();
        }

        try
        {
            Dictionary deserializedDictionary = JsonSerializer.Deserialize<Dictionary>( serializedDictionary )!;
            return deserializedDictionary;
        }
        catch ( Exception exception )
        {
            return new Dictionary();
        }
        finally
        {
            streamReader.Close();
        }
    }
}
using Task3._2_Dictionary.IO;

namespace Task3._2_Dictionary;

public static class Program
{
    public static int Main()
    {
        string filePath = "./dictionary.txt";

        DictionaryRepository dictionaryRepository = new DictionaryRepository( filePath );


        Dictionary dictionary = new Dictionary();
        dictionary.AddTranslation( "Hello", "World" );
        dictionaryRepository.SaveDictionary( dictionary );


        Dictionary storedDictionary = dictionaryRepository.GetDictionary();
        Console.WriteLine( string.Join( ' ', storedDictionary.GetTranslations( "Hello" ) ) );
        
        
        return 0;
    }
}
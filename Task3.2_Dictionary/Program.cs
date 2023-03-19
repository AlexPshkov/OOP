using Task3._2_Dictionary.Repositories;

namespace Task3._2_Dictionary;

public static class Program
{
    public static int Main()
    {
        DictionaryRepository dictionaryRepository = new DictionaryRepository( "dictionary.txt" );

        UserDialog userDialog = new UserDialog( dictionaryRepository );
        userDialog.Start( CancellationToken.None );

        return 0;
    }
}
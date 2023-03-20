using Task3._2_Dictionary.Repositories;

namespace Task3._2_Dictionary;

public static class Program
{
    public static int Main( string[] args )
    {
        //Имя парметра передавать через агрумент
        CheckInputArguments( args );
        
        DictionaryRepository dictionaryRepository = new DictionaryRepository( args[0] );

        UserDialog userDialog = new UserDialog( dictionaryRepository );
        userDialog.Start( CancellationToken.None );

        return 0;
    }

    private static void CheckInputArguments( IReadOnlyCollection<string> args )
    {
        const int reqAmount = 1;
        if ( args.Count != reqAmount )
        {
            throw new ArgumentException( "Input must be: <filePath>" );
        }
    }
}
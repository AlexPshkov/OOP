using Task3._2_Dictionary.Models;
using Task3._2_Dictionary.Repositories;

namespace Task3._2_Dictionary;

public class UserDialog
{
    private readonly DictionaryRepository _dictionaryRepository;
    private readonly Dictionary _currentDictionary;

    public UserDialog( DictionaryRepository dictionaryRepository )
    {
        _dictionaryRepository = dictionaryRepository;
        _currentDictionary = dictionaryRepository.GetDictionary();
    }

    public void Start( CancellationToken cancellationToken ) 
    {
        while ( !cancellationToken.IsCancellationRequested )
        {
            string? userInput = Console.ReadLine();
            if ( string.IsNullOrWhiteSpace( userInput ) )
            {
                continue;
            }

            if ( userInput.Equals( "..." ) )
            {
                HandleEnd();
                return;
            }
            
            HandleInputWord( userInput );
        }
    }

    private void HandleEnd()
    {
        if ( !_currentDictionary.IsNewTranslations() )
        {
            return;
        }

        Console.WriteLine( "В словарь были внесены изменения. Желааете сохранить ваши изменения?" );
        if ( IsUserAgree() )
        {
            _dictionaryRepository.SaveDictionary( _currentDictionary );
            Console.WriteLine( "Изменения сохранены. До свидания." );
            return;
        }

        Console.WriteLine( "Изменения не были сохранены" );
    }

    private void HandleInputWord( string inputWord )
    {
        List<string> translations = _currentDictionary.GetTranslations( inputWord );
        if ( translations.Any() )
        {
            Console.WriteLine( string.Join( ", ", translations ) );
            return;
        }

        HandleNewWordTranslation( inputWord );
    }

    private void HandleNewWordTranslation( string word )
    {
        Console.WriteLine( $"Неизвестное слово “{word}”. Введите перевод или пустую строку для отказа." );
        
        string? newTranslation = Console.ReadLine();
        if ( string.IsNullOrWhiteSpace( newTranslation ) )
        {
            Console.WriteLine( $"Слово “{word}” проигнорировано" );
            return;
        }
        
        _currentDictionary.AddTranslation( word, newTranslation );
        Console.WriteLine( $"Слово “{word}” сохранено в словаре как “{newTranslation}”." );
    }

    private static bool IsUserAgree()
    {
        Console.WriteLine( "Введите \"Y\" для согласия и \"N\" для отмены" );
        
        string? inputString = Console.ReadLine();
        if ( string.IsNullOrWhiteSpace( inputString ) )
        {
            return IsUserAgree();
        }

        return inputString.ToLower() switch
        {
            "y" => true,
            "n" => false,
            _ => IsUserAgree()
        };
    }
}
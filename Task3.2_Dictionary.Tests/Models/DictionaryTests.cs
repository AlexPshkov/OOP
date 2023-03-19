using Task3._2_Dictionary.Models;
using Xunit;

namespace Task3._2_Dictionary.Tests.Models;

public class DictionaryTests
{
    [Fact]
    public void Dictionary_Construct_CreateNew_EmptyDictionary()
    {
        // Arrange
        Dictionary dictionary = new Dictionary();

        // Assert
        Assert.False( dictionary.IsNewTranslations() );
        Assert.Empty( dictionary.WordsTranslations );
    }
    
    [Fact]
    public void Dictionary_AddTranslation_AddNewTranslation_AddedNew()
    {
        // Arrange
        Dictionary dictionary = new Dictionary();

        // Act
        dictionary.AddTranslation( "Hello", "Привет" );
        
        // Assert
        Assert.True( dictionary.IsNewTranslations() );
        Assert.Single( dictionary.WordsTranslations );
        Assert.Single( dictionary.GetTranslations( "Hello" ) );
        Assert.Equal( "Привет", dictionary.GetTranslations( "Hello" ).First() );
    }
    
    [Fact]
    public void Dictionary_AddTranslation_ReversTranslationGet_CorrectAnswer()
    {
        // Arrange
        Dictionary dictionary = new Dictionary();

        // Act
        dictionary.AddTranslation( "Hello", "Привет" );
        
        // Assert
        Assert.True( dictionary.IsNewTranslations() );
        Assert.Single( dictionary.WordsTranslations );
        Assert.Single( dictionary.GetTranslations( "Привет" ) );
        Assert.Equal( "Hello", dictionary.GetTranslations( "Привет" ).First() );
    }
    
    [Fact]
    public void Dictionary_AddTranslation_MultipleTranslations_CorrectOutput()
    {
        // Arrange
        Dictionary dictionary = new Dictionary();

        // Act
        dictionary.AddTranslation( "Hello", "Привет" );
        dictionary.AddTranslation( "Hi", "Привет" );
        
        // Assert
        Assert.True( dictionary.IsNewTranslations() );
        Assert.Equal( 2, dictionary.WordsTranslations.Count );
        Assert.Equal( new List<string> { "Hello", "Hi" }, dictionary.GetTranslations( "Привет" ) );
    }
}
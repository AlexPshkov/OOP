using Task3._2_Dictionary.Deserializers;
using Task3._2_Dictionary.Exceptions;
using Task3._2_Dictionary.Models;
using Xunit;

namespace Task3._2_Dictionary.Tests.Deserializers;

public class TranslationDeserializerTests
{
    [Fact]
    public void TranslationDeserializer_Deserialize_NormalInput_CorrectOutput()
    {
        // Arrange
        string serializedTranslation = "\"Hello\": \"Привет\"";

        // Act
        Translation translation = TranslationDeserializer.Deserialize( serializedTranslation );

        // Assert
        Assert.Equivalent( "Hello", translation.Word );
        Assert.Equivalent( "Привет", translation.WordTranslation );
    }
    
    [Fact]
    public void TranslationDeserializer_Deserialize_EmptyWord_CorrectOutput()
    {
        // Arrange
        string serializedTranslation = "\"\": \"Привет\"";

        // Act
        Translation translation = TranslationDeserializer.Deserialize( serializedTranslation );

        // Assert
        Assert.Equivalent( "", translation.Word );
        Assert.Equivalent( "Привет", translation.WordTranslation );
    }
    
    [Fact]
    public void TranslationDeserializer_Deserialize_EmptyWordTranslation_CorrectOutput()
    {
        // Arrange
        string serializedTranslation = "\"Hello\": \"\"";

        // Act
        Translation translation = TranslationDeserializer.Deserialize( serializedTranslation );

        // Assert
        Assert.Equivalent( "Hello", translation.Word );
        Assert.Equivalent( "", translation.WordTranslation );
    }
    
    [Fact]
    public void TranslationDeserializer_Deserialize_EmptyInput_Error()
    {
        // Arrange
        string serializedTranslation = "";

        // Act & Assert
        Assert.Throws<TranslationDeserializeException>( () =>
            TranslationDeserializer.Deserialize( serializedTranslation ) );
    }
    
    [Fact]
    public void TranslationDeserializer_Deserialize_WrongAmountOfQuotas_Error()
    {
        // Arrange
        string serializedTranslation = "\"Hello\": \"Слово значит \"Привет\" \"";

        // Act & Assert
        Assert.Throws<TranslationDeserializeException>( () =>
            TranslationDeserializer.Deserialize( serializedTranslation ) );
    }
}
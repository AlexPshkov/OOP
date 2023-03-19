using Task3._2_Dictionary.Models;
using Task3._2_Dictionary.Serializers;
using Xunit;

namespace Task3._2_Dictionary.Tests.Serializers;

public class TranslationSerializerTests
{
    [Fact]
    public void TranslationSerializer_Serialize_NormalInput_CorrectOutput()
    {
        // Arrange 
        Translation translation = new Translation
        {
            Word = "Hello",
            WordTranslation = "Привет"
        };

        // Act
        string serializedTranslation = TranslationSerializer.Serialize( translation );

        // Assert
        Assert.Equal( "\"Hello\": \"Привет\"", serializedTranslation );
    }
    
    [Fact]
    public void TranslationSerializer_Serialize_EmptyWord_CorrectOutput()
    {
        // Arrange 
        Translation translation = new Translation
        {
            Word = "",
            WordTranslation = "Привет"
        };

        // Act
        string serializedTranslation = TranslationSerializer.Serialize( translation );

        // Assert
        Assert.Equal( "\"\": \"Привет\"", serializedTranslation );
    }
    
    [Fact]
    public void TranslationSerializer_Serialize_EmptyWordTranslation_CorrectOutput()
    {
        // Arrange 
        Translation translation = new Translation
        {
            Word = "Hello",
            WordTranslation = ""
        };

        // Act
        string serializedTranslation = TranslationSerializer.Serialize( translation );

        // Assert
        Assert.Equal( "\"Hello\": \"\"", serializedTranslation );
    }
}
using Task3._2_Dictionary.Models;

namespace Task3._2_Dictionary.Serializers;

public static class TranslationSerializer
{
    public static string Serialize( Translation translation )
    {
        return $"\"{translation.Word}\": \"{translation.WordTranslation}\"";
    }
}
using Task1._8.IO;
using Task1._8.Sort;

namespace Task1._8;

public static class Program
{
    public static int Main()
    {
        if ( !TryGetNumbers( out List<float> numbers ) )
        {
            return 1;
        }

        NumbersListHandler.Handle( numbers );
        List<float> sortedNumbers = QuickSort.Sort( numbers );
        
        ConsoleWriter.WriteLn( sortedNumbers );
        
        return 0;
    }

    private static bool TryGetNumbers( out List<float> numbers )
    {
        try
        {
            numbers = ConsoleReader.ReadNumbers();
            return true;
        }
        catch ( ArgumentNullException )
        {
            Console.WriteLine( "Input string can't be empty" );
        }
        catch ( Exception exception )
        {
            Console.WriteLine( exception.Message );
        }

        numbers = new List<float>();
        return false;
    }
}
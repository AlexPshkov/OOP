using Task2._3_MyList.Models;

namespace Task2._3_MyList.Demos;

public static class DemoMyListString
{
    public static void Demo()
    {
        Console.WriteLine( "Enter some strings and type EOF for the end: " );
        MyList<string> stringList = new MyList<string>();
        
        string? inputLine = Console.ReadLine();
        while ( inputLine != null )
        {
            stringList.Add( inputLine );
            inputLine = Console.ReadLine();
        }

        if ( stringList.Count == 0 )
        {
            Console.WriteLine("Empty input");
            return;
        }
        
        //===========[NORMAL OUT]==================
        Console.WriteLine( "Normal out: " );
        foreach ( string str in stringList )
        {
            Console.WriteLine( $" - {str}" );
        }

        Console.WriteLine();
        //=================================================
        
        
        //===========[REVERSE INPUT LINES]==================
        Console.WriteLine( "Reverse out: " );
        IEnumerator<string> backwardEnumerator = stringList.GetBackwardEnumerator();
        while ( backwardEnumerator.MoveNext() )
        {
            Console.WriteLine( $" - {backwardEnumerator.Current}" );
        }
        Console.WriteLine();
        //================================================= 
        
        
        
        //==========[INSERT AT FIRST AND THE END]=============
        Console.WriteLine( "After insert string at the start and the end: " );

        stringList.InsertAtTheStart( "FIRST LINE" );
        stringList.InsertAtTheEnd( "LAST LINE" );

        foreach ( string str in stringList )
        {
            Console.WriteLine( $" - {str}" );
        }

        Console.WriteLine();
        //====================================================
        
        
        
        //==========[REMOVE FIRST ELEMENT]===================
        Console.WriteLine( "After removing first element " );

        stringList.RemoveAt( 0 );

        foreach ( string str in stringList )
        {
            Console.WriteLine( $" - {str}" );
        }

        Console.WriteLine();
        //====================================================
        
        
        
        //==========[ALL STRINGS IN ONE]================
        Console.Write( "All string in one: " );
        Console.WriteLine( string.Join( " ", stringList ) );
        Console.WriteLine();
        //==============================================
    }
}
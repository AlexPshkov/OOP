using Task2._3_MyList.Models;

namespace Task2._3_MyList.Demos;

public static class DemoMyListInt
{
    public static void Demo()
    {
        Console.WriteLine( "Enter some numbers and type EOF for the end: " );
        MyList<int> numberList = new MyList<int>();
        
        string? inputLine = Console.ReadLine();
        while ( inputLine != null )
        {
            numberList.Add( int.Parse( inputLine ) );
            inputLine = Console.ReadLine();
        }

        if ( numberList.Count == 0 )
        {
            Console.WriteLine("Empty input");
            return;
        }
        
        //===========[NORMAL OUT]==================
        Console.WriteLine( "Normal out: " );
        foreach ( int number in numberList )
        {
            Console.WriteLine( $" - {number}" );
        }

        Console.WriteLine();
        //=================================================
        
        
        //==========[INSERT AT FIRST AND THE END]=============
        Console.WriteLine( "After insert 0 at the start and 99 at the end: " );

        numberList.InsertAtTheStart( 0 );
        numberList.InsertAtTheEnd( 99 );

        foreach ( int number in numberList )
        {
            Console.WriteLine( $" - {number}" );
        }

        Console.WriteLine();
        //====================================================
        
        
        
        //==========[REMOVE FIRST ELEMENT]===================
        Console.WriteLine( "After removing first element " );

        numberList.RemoveAt( 0 );

        foreach ( int number in numberList )
        {
            Console.WriteLine( $" - {number}" );
        }

        Console.WriteLine();
        //====================================================
        
        
        
        //==========[SUM ALL NUMBER]================
        Console.Write( "All numbers sum: " );
        Console.WriteLine( numberList.Sum() );
        Console.WriteLine();
        //==============================================
    }
}
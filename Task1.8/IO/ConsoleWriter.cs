﻿namespace Task1._8.IO;

public static class ConsoleWriter
{
    private const char NumberSeparator = ' ';
    
    public static void WriteLn( IEnumerable<float> numbers )
    {
        Console.WriteLine( string.Join( NumberSeparator, numbers ) );
    }
}
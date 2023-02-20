using Task5._2_Labyrinth.IO;
using Task5._2_Labyrinth.Models;
using Task5._2_Labyrinth.PathFinder;

namespace Task5._2_Labyrinth;

public static class Program
{
    public static int Main( string[] args )
    {
        try
        {
            CheckInputArguments( args );
            using MazeFileReader mazeFileReader = new MazeFileReader( args[0] );
            Maze maze = mazeFileReader.ReadMaze();

            List<MazeCell> mazePath = BreadthFirstSearch.FindPath( maze );

            using MazeFileWriter mazeFileWriter = new MazeFileWriter( args[1] );
            mazeFileWriter.WriteMaze( maze, mazePath );
        }
        catch ( Exception exception )
        {
            Console.WriteLine( exception.Message );
            return 1;
        }
        return 0;
    }

    private static void CheckInputArguments( IReadOnlyCollection<string> args )
    {
        const int reqAmount = 2;
        if ( args.Count != reqAmount )
        {
            throw new ArgumentException( "Input must be: <input file> <output file>" );
        }
    }
}
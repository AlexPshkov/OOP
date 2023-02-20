using System.Text;
using Task5._2_Labyrinth.Models;

namespace Task5._2_Labyrinth.IO;

public class MazeFileWriter : StreamWriter
{
    public MazeFileWriter( string filePath ) : base( filePath ) {}

    public sealed override void Close()
    {
        base.Close();
    }

    public void WriteMaze( Maze maze, ICollection<MazeCell> path )
    {
        try
        {
            WriteLine( ConvertMazeToString( maze, path ) );
            Flush();
        }
        finally
        {
            Close();
            Dispose();
        }
    }
    
    private string ConvertMazeToString( Maze maze, ICollection<MazeCell> path )
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        for ( int y = 0; y < maze.MazeField.Length; y++ )
        {
            for ( int x = 0; x < maze.MazeField[y].Length; x++ )
            {
                MazeCell mazeCell = maze.MazeField[y][x];
                if ( path.Contains( mazeCell ) )
                {
                    stringBuilder.Append( '.' );
                    continue;
                }
                
                stringBuilder.Append( mazeCell.CellContent );
            }

            stringBuilder.Append( '\n' );
        }

        return stringBuilder.ToString();
    }
}
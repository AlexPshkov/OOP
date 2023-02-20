using Task5._2_Labyrinth.Models;
using Task5._2_Labyrinth.Models.Enums;

namespace Task5._2_Labyrinth.IO;

public class MazeFileReader : StreamReader
{
    private const int MaxMazeHeight = 100;
    private const int MaxMazeWidth = 100;
    
    private int _realMazeWidth;
    private int _lineCounter;
    
    public MazeFileReader( string filePath ) : base( filePath ) {}

    public sealed override void Close()
    {
        base.Close();
    }

    public Maze ReadMaze()
    {
        List<MazeCell[]> mazeCells = new List<MazeCell[]>();
        try
        {
            while ( !EndOfStream && _lineCounter < MaxMazeHeight )
            {
                mazeCells.Add( GetCells( ReadLine() ) );
            }
        }
        finally
        {
            Close();
            Dispose();
        }

        MazeCell[][] mazeField = NormalizeMazeField( mazeCells.ToArray() );
        
        return new Maze( mazeField );
    }

    private MazeCell[] GetCells( string? line )
    {
        List<MazeCell> mazeCells = new List<MazeCell>();
        if ( string.IsNullOrEmpty( line ) )
        {
            return mazeCells.ToArray();
        }

        int currentWidth = Math.Min( line.Length, MaxMazeWidth );
        if ( currentWidth > _realMazeWidth )
        {
            _realMazeWidth = currentWidth;
        }
        
        for ( int lineOffset = 0; lineOffset < currentWidth; lineOffset++ )
        {
            char symbol = line[lineOffset];
            mazeCells.Add( CreateCell( symbol, lineOffset, _lineCounter ) );
        }
        
        _lineCounter += 1;
        return mazeCells.ToArray();
    }

    private MazeCell[][] NormalizeMazeField( MazeCell[][] mazeField )
    {
        MazeCell[][] normalizedField = new MazeCell[mazeField.Length][];
        
        for ( int y = 0; y < mazeField.Length; y++ )
        {
            normalizedField[y] = new MazeCell[_realMazeWidth];
            for ( int x = 0; x < _realMazeWidth; x++ )
            {
                normalizedField[y][x] = mazeField[y].Length <= x 
                    ? new MazeCell( x, y ) 
                    : mazeField[y][x];
            }
        }

        return normalizedField;
    }
    
    private MazeCell CreateCell( char symbol, int posX, int posY )
    {
        MazeCellType mazeCellType = symbol switch
        {
            '#' => MazeCellType.WALL,
            'A' => MazeCellType.START,
            'B' => MazeCellType.FINISH,
            ' ' => MazeCellType.BLANK,
            _ => MazeCellType.BLANK
        };
        
        if ( mazeCellType == MazeCellType.BLANK )
        {
            return new MazeCell( posX, posY );
        }
        
        return new MazeCell
        {
            PosY = posY,
            PosX = posX,
            CellContent = symbol,
            CellType = mazeCellType
        };
    }
}
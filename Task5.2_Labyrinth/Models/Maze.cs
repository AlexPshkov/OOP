using Task5._2_Labyrinth.Models.Enums;

namespace Task5._2_Labyrinth.Models;

public class Maze
{
    private MazeCell? _endCell;
    private MazeCell? _startCell;
    
    public readonly MazeCell[][] MazeField;

    public Maze( MazeCell[][] mazeField )
    {
        MazeField = mazeField;
        IndexMazeField();
    }

    private void IndexMazeField()
    {
        int startCellsAmount = 0;
        int endCellsAmount = 0;
        
        for ( int y = 0; y < MazeField.Length; y++ )
        {
            for ( int x = 0; x < MazeField[y].Length; x++ )
            {
                MazeCell mazeCell = MazeField[y][x];

                if ( mazeCell.CellType == MazeCellType.START )
                {
                    _startCell = mazeCell;
                    startCellsAmount++;
                    continue;
                }
                
                if ( mazeCell.CellType == MazeCellType.FINISH )
                {
                    _endCell = mazeCell;
                    endCellsAmount++;
                    continue;
                }
            }
        }

        if ( startCellsAmount != 1 || endCellsAmount != 1 )
        {
            throw new Exception( "The field must contain one start point and one end point" );
        }
    }
    
    public MazeCell? GetStartCell()
    {
        return _startCell;
    }
    
    public MazeCell? GetEndCell()
    {
        return _endCell;
    }

    public List<MazeCell?> GetNeighbours( MazeCell mazeCell )
    {
        List<MazeCell?> neighbours = new List<MazeCell?>
        {
            GetCellAt( mazeCell.PosX + 1, mazeCell.PosY ),
            GetCellAt( mazeCell.PosX - 1, mazeCell.PosY ),
            GetCellAt( mazeCell.PosX, mazeCell.PosY + 1 ),
            GetCellAt( mazeCell.PosX, mazeCell.PosY - 1 )
        };

        return neighbours;
    }

    public bool IsAvailableForVisit( MazeCell? mazeCell )
    {
        if ( mazeCell == null )
        {
            return false;
        }

        if ( mazeCell.CellType == MazeCellType.WALL || mazeCell.CellType == MazeCellType.VISITED )
        {
            return false;
        }
        
        return IsInMazeField( mazeCell.PosX, mazeCell.PosY );
    }
    
    private bool IsInMazeField( int x, int y )
    {
        if ( y < 0 || y >= MazeField.Length )
        {
            return false;
        }
        
        if ( x < 0 || x >= MazeField[y].Length )
        {
            return false;
        }

        return true;
    }

    private MazeCell? GetCellAt( int x, int y )
    {
        return IsInMazeField( x, y ) ? MazeField[y][x] : null;
    }
}
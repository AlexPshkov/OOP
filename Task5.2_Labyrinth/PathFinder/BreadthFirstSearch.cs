using Task5._2_Labyrinth.Models;
using Task5._2_Labyrinth.Models.Enums;

namespace Task5._2_Labyrinth.PathFinder;

public static class BreadthFirstSearch
{
    public static List<MazeCell> FindPath( Maze maze )
    {
        LinkedList<MazeCell> mazeCellQueue = new LinkedList<MazeCell>();
        
        mazeCellQueue.AddFirst( maze.GetStartCell()! );
        
        while ( mazeCellQueue.Count != 0 ) 
        {
            MazeCell currentMazeCell = mazeCellQueue.First();
            mazeCellQueue.RemoveFirst();
            
            if ( currentMazeCell.CellType == MazeCellType.FINISH )
            {
                return GetPath( maze.GetEndCell() );
            }

            currentMazeCell.CellType = MazeCellType.VISITED;
            
            maze.GetNeighbours( currentMazeCell ).ForEach( nextMazeCell =>
            {
                if ( !maze.IsAvailableForVisit( nextMazeCell ) )
                {
                    return;
                }

                nextMazeCell!.FromWhatCell = currentMazeCell;
                
                mazeCellQueue.AddLast( nextMazeCell );
            } );
        }
        
        return new List<MazeCell>();
    }

    private static List<MazeCell> GetPath( MazeCell? mazeCell )
    {
        List<MazeCell> path = new List<MazeCell>();
        
        MazeCell? currentCell = mazeCell;
        while ( currentCell != null )
        {
            path.Add( currentCell );
            currentCell = currentCell.FromWhatCell;
        }

        return path.Skip( 1 ).SkipLast( 1 ).ToList();
    }
}
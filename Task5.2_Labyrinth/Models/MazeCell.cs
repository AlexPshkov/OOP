using Task5._2_Labyrinth.Models.Enums;

namespace Task5._2_Labyrinth.Models;

public class MazeCell
{
    public int PosX { get; init; }
    public int PosY { get; init; }
    public char? CellContent { get; set; } = ' ';
    public MazeCellType CellType { get; set; } = MazeCellType.BLANK;
    public MazeCell? FromWhatCell;

    public MazeCell() { }
    
    public MazeCell( int x, int y )
    {
        PosY = y;
        PosX = x;
    }
}
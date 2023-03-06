using Task5._2_Labyrinth.Models;
using Task5._2_Labyrinth.PathFinder;
using Xunit;

namespace Task5._2_Labyrinth_Tests;

public class BreadthFirstSearchTests
{
    [Fact]
    public void Convert_ZeroInput_CorrectAnswer()
    {
        //Arrange
        Maze maze = GetEmptyMaze();



        //Act
        string result = BreadthFirstSearch.FindPath(  );
        
        //Assert
        Assert.Equal( "0", result );
    }

    private Maze GetEmptyMaze()
    {
        const int Height = 50;
        const int Width = 50;
        
        MazeCell[][] mazeField = new MazeCell[Height][];
        for ( int y = 0; y < mazeField.Length; y++ )
        {
            mazeField[y] = new MazeCell[Width];
            for ( int x = 0; x < Width; x++ )
            {
                mazeField[y][x] = new MazeCell();
            }
        }
    }
}
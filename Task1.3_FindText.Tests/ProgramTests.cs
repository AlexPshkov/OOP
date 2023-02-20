
using Xunit;

namespace Task1._3_FindText.Tests;

public class ProgramTests
{
    [Fact]
    public void Main_WrongAmountOfArguments_BadExitCode()
    {
        //Arrange
        string[] args = Array.Empty<string>();

        //Act
        int programExitCode = Program.Main( args );
        
        //Assert
        Assert.Equal( 1, programExitCode );
    }
    
    [Fact]
    public void Main_WrongFilePath_BadExitCode()
    {
        //Arrange
        string[] args = { "", "Some text" };

        //Act
        int programExitCode = Program.Main( args );
        
        //Assert
        Assert.Equal( 1, programExitCode );
    }
}
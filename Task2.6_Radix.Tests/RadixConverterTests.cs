using Xunit;

namespace Task2._6_Radix.Tests;

public class RadixConverterTests
{
    [Fact]
    public void Convert_ZeroInput_CorrectAnswer()
    {
        //Arrange
        string initialValue = "0";
        int initialNumberSystem = 10;
        int requiredNumberSystem = 2;

        //Act
        string result = RadixConverter.Convert( initialNumberSystem, requiredNumberSystem, initialValue );
        
        //Assert
        Assert.Equal( "0", result );
    }
    
    [Fact]
    public void Convert_EmptyInput_CorrectAnswer()
    {
        //Arrange
        string initialValue = "";
        int initialNumberSystem = 10;
        int requiredNumberSystem = 2;

        //Act
        string result = RadixConverter.Convert( initialNumberSystem, requiredNumberSystem, initialValue );
        
        //Assert
        Assert.Equal( "0", result );
    }

    [Fact]
    public void Convert_DecimalToBinary_CorrectAnswer()
    {
        //Arrange
        string initialValue = "255";
        int initialNumberSystem = 10;
        int requiredNumberSystem = 2;

        //Act
        string result = RadixConverter.Convert( initialNumberSystem, requiredNumberSystem, initialValue );
        
        //Assert
        Assert.Equal( "11111111", result );
    }
    
    [Fact]
    public void Convert_DecimalToBinaryWithMinus_CorrectAnswer()
    {
        //Arrange
        string initialValue = "-255";
        int initialNumberSystem = 10;
        int requiredNumberSystem = 2;

        //Act
        string result = RadixConverter.Convert( initialNumberSystem, requiredNumberSystem, initialValue );
        
        //Assert
        Assert.Equal( "-11111111", result );
    }
    
    
    [Fact]
    public void Convert_From36To11_CorrectAnswer()
    {
        //Arrange
        string initialValue = "9AZV";
        int initialNumberSystem = 36;
        int requiredNumberSystem = 11;

        //Act
        string result = RadixConverter.Convert( initialNumberSystem, requiredNumberSystem, initialValue );
        
        //Assert
        Assert.Equal( "277207", result );
    }
    
    [Fact]
    public void Convert_RadixValueMore36_Exception()
    {
        //Arrange
        string initialValue = "";
        int initialNumberSystem = 37;
        int requiredNumberSystem = 2;

        //Act
        Exception exception = null;
        try
        { 
            RadixConverter.Convert( initialNumberSystem, requiredNumberSystem, initialValue );
        }
        catch ( Exception threwException )
        {
            exception = threwException;
        }
        
        //Assert
        Assert.NotNull( exception );
    }
    
    [Fact]
    public void Convert_IncorrectInputValue_Exception()
    {
        //Arrange
        string initialValue = "130я";
        int initialNumberSystem = 10;
        int requiredNumberSystem = 2;

        //Act
        Exception exception = null;
        try
        { 
            RadixConverter.Convert( initialNumberSystem, requiredNumberSystem, initialValue );
        }
        catch ( Exception threwException )
        {
            exception = threwException;
        }
        
        //Assert
        Assert.NotNull( exception );
    }
    
    [Fact]
    public void Convert_InputValueMoreThenRadix_Exception()
    {
        //Arrange
        string initialValue = "901Z";
        int initialNumberSystem = 10;
        int requiredNumberSystem = 2;

        //Act
        Exception exception = null;
        try
        { 
            RadixConverter.Convert( initialNumberSystem, requiredNumberSystem, initialValue );
        }
        catch ( Exception threwException )
        {
            exception = threwException;
        }
        
        //Assert
        Assert.NotNull( exception );
    }
}
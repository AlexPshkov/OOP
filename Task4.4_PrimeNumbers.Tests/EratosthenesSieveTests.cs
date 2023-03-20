using Xunit;

namespace Task4._4_PrimeNumbers.Tests;

public class EratosthenesSieveTests
{
    [Fact]
    public void EratosthenesSieve_GeneratePrimeNumbersSet_NormalInput_CorrectAnswer()
    {
        // Arrange
        int upperBound = 11;

        // Act
        HashSet<int> primeNumbers = EratosthenesSieve.GeneratePrimeNumbersSet( upperBound );

        // Assert
        Assert.Equal( new HashSet<int> { 2, 3, 5, 7, 11 }, primeNumbers );
    }
    
    [Fact]
    public void EratosthenesSieve_GeneratePrimeNumbersSet_BoundEqualsTwo_CorrectAnswer()
    {
        // Arrange
        int upperBound = 2;

        // Act
        HashSet<int> primeNumbers = EratosthenesSieve.GeneratePrimeNumbersSet( upperBound );

        // Assert
        Assert.Equal( new HashSet<int> { 2 }, primeNumbers );
    }
    
    [Fact]
    public void EratosthenesSieve_GeneratePrimeNumbersSet_BoundLessThenTwo_NoErrors()
    {
        // Arrange
        int upperBound = 1;

        // Act
        HashSet<int> primeNumbers = EratosthenesSieve.GeneratePrimeNumbersSet( upperBound );

        // Assert
        Assert.Empty( primeNumbers );
    }
    
    
    [Fact]
    public void EratosthenesSieve_GeneratePrimeNumbersSet_LargeAmount_QuickWork()
    {
        // Arrange
        int upperBound = 100000000;

        // Act
        DateTime startTime = DateTime.Now;
        HashSet<int> primeNumbers = EratosthenesSieve.GeneratePrimeNumbersSet( upperBound );

        // Assert
        Assert.InRange( DateTime.Now - startTime, TimeSpan.FromMicroseconds( 1 ), TimeSpan.FromSeconds( 10 ) );
        Assert.Equal( 5761455, primeNumbers.Count );
    }
}
using NUnit.Framework;
using Task1._3_FindMaxEx.Comparers;
using Task1._3_FindMaxEx.Models;

namespace Task1._3_FindMaxEx.Tests;

public class ListUtilsTests
{
    [Test]
    public void ListUtils_FindMaxEx_EmptyList_ResultFalse()
    {
        // Arrange
        List<Sportsmen> sportsmenList = new List<Sportsmen>();

        // Act
        bool result = ListUtils.FindMaxEx( sportsmenList, new SportsmenWeightComparer(), out Sportsmen maxWeightSportsmen );
        
        // Assert
        Assert.That(result, Is.False);
    }
    
    
    [Test]
    public void ListUtils_FindMaxEx_FindMaxWeight_CorrectOut()
    {
        // Arrange
        List<Sportsmen> sportsmenList = new List<Sportsmen>
        {
            new Sportsmen( "FirstName", 10, 10 ),
            new Sportsmen( "SecondName", 15, 10 ),
            new Sportsmen( "ThirdName", 5, 50 ),
            new Sportsmen( "FourthName", 14, 50 )
        };
        
        // Act
        bool result = ListUtils.FindMaxEx( sportsmenList, new SportsmenWeightComparer(), out Sportsmen maxWeightSportsmen );
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(maxWeightSportsmen.Name, Is.EqualTo("SecondName"));
        });
    }
    
    [Test]
    public void ListUtils_FindMaxEx_FindMaxName_CorrectOut()
    {
        // Arrange
        List<Sportsmen> sportsmenList = new List<Sportsmen>
        {
            new Sportsmen( "AName", 10, 10 ),
            new Sportsmen( "BName", 15, 10 ),
            new Sportsmen( "ZZname", 5, 50 ),
            new Sportsmen( "ZName", 14, 50 )
        };
        
        // Act
        bool result = ListUtils.FindMaxEx( sportsmenList, new SportsmenNameComparer(), out Sportsmen maxWeightSportsmen );
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(maxWeightSportsmen.Name, Is.EqualTo("ZZname"));
        });
    }
    
    [Test]
    public void ListUtils_FindMaxEx_FindMaxHeight_CorrectOut()
    {
        // Arrange
        List<Sportsmen> sportsmenList = new List<Sportsmen>
        {
            new Sportsmen( "FirstName", 10, 10 ),
            new Sportsmen( "SecondName", 15, 10 ),
            new Sportsmen( "ThirdName", 5, 50 ),
            new Sportsmen( "FourthName", 14, 51 )
        };
        
        // Act
        bool result = ListUtils.FindMaxEx( sportsmenList, new SportsmenHeightComparer(), out Sportsmen maxWeightSportsmen );
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(maxWeightSportsmen.Name, Is.EqualTo("FourthName"));
        });
    }
}
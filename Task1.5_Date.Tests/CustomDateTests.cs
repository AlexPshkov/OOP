using NUnit.Framework;
using Task1._5_Date.Models;
using static NUnit.Framework.Assert;

namespace Task1._5_Date.Tests;

public class CustomDateTests
{
    #region ConditionalOperations
    
    [Test]
    public void CustomDate_ConditionalOperations_NormalValues_CorrectAnswer()
    {
        // Arrange
        CustomDate a = new CustomDate().FromDayMonthYear( 1, 1, 1970 );
        CustomDate b = new CustomDate().FromDayMonthYear( 26, 6, 1974 );

        // Act 
        bool isEqualB = a == b;
        bool isNotEqualB = a != b;
        bool isAMoreThenB = a > b;
        bool isALessThenB = a < b;
        bool isAMoreOrEqualB = a >= b;
        bool isALessOrEqualB = a <= b;

        // Assert
        Multiple( () =>
        {
            That( isEqualB, Is.False );
            That( isNotEqualB, Is.True );
            That( isAMoreThenB, Is.False );
            That( isALessThenB, Is.True );
            That( isAMoreOrEqualB, Is.False );
            That( isALessOrEqualB, Is.True );
        } );
    }

    [Test]
    public void CustomDate_ConditionalOperations_NormalValuesSecond_CorrectAnswer()
    {
        // Arrange
        CustomDate a = new CustomDate().FromDayMonthYear( 1, 1, 1970 );
        CustomDate b = new CustomDate().FromDayMonthYear( 1, 1, 1970 );

        // Act 
        bool isEqualB = a == b;
        bool isNotEqualB = a != b;
        bool isAMoreThenB = a > b;
        bool isALessThenB = a < b;
        bool isAMoreOrEqualB = a >= b;
        bool isALessOrEqualB = a <= b;

        // Assert
        Multiple( () =>
        {
            That( isEqualB, Is.True );
            That( isNotEqualB, Is.False );
            That( isAMoreThenB, Is.False );
            That( isALessThenB, Is.False );
            That( isAMoreOrEqualB, Is.True );
            That( isALessOrEqualB, Is.True );
        } );
    }
    
    [Test]
    public void CustomDate_ConditionalOperations_InvalidValues_CorrectAnswer()
    {
        // Arrange
        CustomDate a = new CustomDate().FromDayMonthYear( 1, 1, 1960 );
        CustomDate b = new CustomDate().FromDayMonthYear( 1, 1, 1970 );

        // Act 
        bool isEqualB = a == b;
        bool isNotEqualB = a != b;
        bool isAMoreThenB = a > b;
        bool isALessThenB = a < b;
        bool isAMoreOrEqualB = a >= b;
        bool isALessOrEqualB = a <= b;

        // Assert
        Multiple( () =>
        {
            That( isEqualB, Is.False );
            That( isNotEqualB, Is.True );
            That( isAMoreThenB, Is.False );
            That( isALessThenB, Is.False );
            That( isAMoreOrEqualB, Is.False );
            That( isALessOrEqualB, Is.False );
        } );
    }
    
    [Test]
    public void CustomDate_ConditionalOperations_InvalidValuesSecond_CorrectAnswer()
    {
        // Arrange
        CustomDate a = new CustomDate().FromDayMonthYear( 1, 1, 1960 );
        CustomDate b = new CustomDate().FromDayMonthYear( 1, 1, 99999 );

        // Act 
        bool isEqualB = a == b;
        bool isNotEqualB = a != b;
        bool isAMoreThenB = a > b;
        bool isALessThenB = a < b;
        bool isAMoreOrEqualB = a >= b;
        bool isALessOrEqualB = a <= b;

        // Assert
        Multiple( () =>
        {
            That( isEqualB, Is.True );
            That( isNotEqualB, Is.False );
            That( isAMoreThenB, Is.False );
            That( isALessThenB, Is.False );
            That( isAMoreOrEqualB, Is.True );
            That( isALessOrEqualB, Is.True );
        } );
    }
    
    #endregion

    #region PrimaryOperations

    [Test]
    public void CustomDate_PrimaryOperations_NormalValues_CorrectAnswer()
    {
        // Arrange
        CustomDate a = new CustomDate().FromDayMonthYear( 1, 1, 1970 );
        CustomDate b = new CustomDate().FromDayMonthYear( 26, 6, 1974 );

        // Act 
        CustomDate aPlus1 = a + 1;
        CustomDate aMinus1 = a - 1;
        CustomDate aPlus1Minus1 = a++ - 1;
        CustomDate aPlus1Plus1 = a + 1;
        int bMinusa = b - a;

        // Assert
        Multiple( () =>
        {
            That( aPlus1.ToString(), Is.EqualTo( "2.1.1970" ) );
            That( aMinus1.ToString(), Is.EqualTo( "INVALID" ) );
            That( aPlus1Minus1.ToString(), Is.EqualTo( "1.1.1970" ) );
            That( aPlus1Plus1.ToString(), Is.EqualTo( "3.1.1970" ) );
            That( bMinusa, Is.EqualTo( 1636 ) );
        } );
    }
    
    [Test]
    public void CustomDate_PrimaryOperations_InvalidValues_CorrectAnswer()
    {
        // Arrange
        CustomDate a = new CustomDate().FromDayMonthYear( 1, 1, 1960 );
        CustomDate b = new CustomDate().FromDayMonthYear( 26, 6, 1974 );

        // Act 
        CustomDate aPlus1 = a + 1;
        CustomDate aMinus1 = a - 1;
        CustomDate aPlus1Minus1 = ( a++ ) - 1;
        CustomDate aPlus1Plus1 = a + 1;
        int bMinusa = b - a;

        // Assert
        Multiple( () =>
        {
            That( aPlus1.ToString(), Is.EqualTo( "INVALID" ) );
            That( aMinus1.ToString(), Is.EqualTo( "INVALID" ) );
            That( aPlus1Minus1.ToString(), Is.EqualTo( "INVALID" ) );
            That( aPlus1Plus1.ToString(), Is.EqualTo( "INVALID" ) );
            That( bMinusa, Is.EqualTo( -1 ) );
        } );
    }
    
    #endregion
    
    
    [Test]
    public void CustomDate_FromDayMonthYearAndFromDays_NormalValues_CorrectAnswer()
    {
        CustomDate date1 = new CustomDate().FromDayMonthYear( 26, 6, 1974 );
        CustomDate date1_1 = new CustomDate().FromDays( 1637 );
        
        CustomDate date2 = new CustomDate().FromDayMonthYear( 5, 5, 2000 );
        CustomDate date2_2 = new CustomDate().FromDays( 11082 );
        
        
        Multiple(() =>
        {
            That( date1.Day, Is.EqualTo( date1_1.Day ) );
            That( date1.Month, Is.EqualTo( date1_1.Month ) );
            That( date1.Year, Is.EqualTo( date1_1.Year ) );
            
            That( date2.Day, Is.EqualTo( date2_2.Day ) );
            That( date2.Month, Is.EqualTo( date2_2.Month ) );
            That( date2.Year, Is.EqualTo( date2_2.Year ) );
        });
    }
    
    [Test]
    public void CustomDate_FromDayMonthYear_LessThenMinimalYear_InvalidAndValidDate()
    {
        CustomDate date1 = new CustomDate().FromDayMonthYear( 1, 5, 1000 );
        CustomDate date2 = new CustomDate().FromDayMonthYear( 31, 5, 1969);
        CustomDate date3 = new CustomDate().FromDayMonthYear( 31, 5, 1970);
        CustomDate date4 = new CustomDate().FromDayMonthYear( 31, 5, 99999);
        
        CustomDate date11 = new CustomDate().FromDays( int.MinValue );
        CustomDate date12 = new CustomDate().FromDays( int.MaxValue );
        CustomDate date13 = new CustomDate().FromDays( 1636 );
        
        Multiple(() =>
        {
            That( date1.IsValid, Is.EqualTo( false ) );
            That( date2.IsValid, Is.EqualTo( false ) );
            That( date3.IsValid, Is.EqualTo( true ) );
            That( date4.IsValid, Is.EqualTo( false ) );
            
            That( date11.IsValid, Is.EqualTo( false ) );
            That( date12.IsValid, Is.EqualTo( false ) );
            That( date13.IsValid, Is.EqualTo( true ) );
        });
    }
}
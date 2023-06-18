using NUnit.Framework;
using Task1._5_Date.Exceptions;
using Task1._5_Date.Models;
using Task1._5_Date.Models.Calendars;
using Task1._5_Date.Models.Calendars.Gregorian;
using Task1._5_Date.Models.Calendars.Gregorian.Enums;
using Task1._5_Date.Models.Gregorian;

namespace Task1._5_Date.Tests;

public class GregorianCalendarTests
{
    [TestCase( 1970, Month.January, 1, 0 )]
    [TestCase( 2023, Month.June, 17, 19525 )]
    [TestCase( 2053, Month.June, 17, 30483 )]
    public void GregorianCalendar_GetDaysOffset_NormalInput_CorrectAnswer( int year, Month month, int day, int expected )
    {
        // Arrange
        ICustomCalendar calendar = new GregorianCalendar();

        // Act
        int daysOffset = calendar.GetDaysOffset( year, month, day );

        // Assert
        Assert.That( daysOffset, Is.EqualTo( expected ) );
    }

    [TestCase( 0, 1970, Month.January, 1 )]
    [TestCase( 12177, 2003, Month.May, 5 )]
    [TestCase( 14452, 2009, Month.July, 27 )]
    [TestCase( 216066, 2561, Month.July, 27 )]
    public void GregorianCalendar_GetDateParamsFromDaysOffset_NormalInput_CorrectAnswer( int daysOffset, int expectedYear, Month expectedMonth, int expectedDay )
    {
        // Arrange
        ICustomCalendar calendar = new GregorianCalendar();

        // Act
        DateParams dateParams = calendar.GetDateParamsFromDaysOffset( daysOffset );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( dateParams.Year, Is.EqualTo( expectedYear ) );
            Assert.That( dateParams.Month, Is.EqualTo( expectedMonth ) );
            Assert.That( dateParams.Day, Is.EqualTo( expectedDay ) );
        } );
    }

    [TestCase( 1970,  true )]
    [TestCase( 1969, false )]
    [TestCase( 1960, false )]
    [TestCase( 99999, false )]
    public void GregorianCalendar_GetDaysOffset_DifferentYears_ErrorOnWrongYear( int year, bool isCorrect )
    {
        // Arrange
        ICustomCalendar calendar = new GregorianCalendar();
        bool flag = isCorrect;
        
        // Act 
        if ( !flag )
        {
            Assert.Throws<DateNotExistsException>( () => calendar.GetDaysOffset( year, Month.January, 1 ) );
            flag = true;
        }

        // Assert
        Assert.That( flag, Is.EqualTo( true ) );
    }

    [TestCase( 2023, Month.February, 28, true )]
    [TestCase( 2023, Month.February, 29, false )]
    [TestCase( 2023, Month.February, -8, false )]
    [TestCase( 1970, Month.January, 0, false )]
    [TestCase( 1970, Month.January, 1, true )]
    [TestCase( 1970, Month.January, 32, false )]
    public void GregorianCalendar_DayExists_NormalInput_CorrectAnswer( int year, Month month, int day, bool dateExists )
    {
        // Arrange
        ICustomCalendar calendar = new GregorianCalendar();

        // Act
        bool isDateExists = calendar.IsDateExists( year, month, day );

        // Assert
        Assert.That( isDateExists, Is.EqualTo( dateExists ) );
    }

    [TestCase( 2003, Month.May, 5, WeekDay.Monday )]
    [TestCase( 2009, Month.July, 27, WeekDay.Monday )]
    [TestCase( 1970, Month.January, 1, WeekDay.Thurdsay )]
    [TestCase( 1974, Month.June, 26, WeekDay.Wednesday )]
    public void GregorianCalendar_GetDayOfWeek_NormalInput_CorrectAnswer( int year, Month month, int day, WeekDay expectedDay )
    {
        // Arrange
        ICustomCalendar calendar = new GregorianCalendar();

        // Act
        WeekDay weekDay = calendar.GetWeekDay( year, month, day );

        // Assert
        Assert.That( weekDay, Is.EqualTo( expectedDay ) );
    }
}
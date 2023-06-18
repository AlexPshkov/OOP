using Task1._5_Date.Models.Enums;

namespace Task1._5_Date.Models.Calendars;

public interface ICustomCalendar
{
    int MinDayOffset { get; }
    int MaxDayOffset { get; }

    bool IsLeapYear( int year );
    WeekDay GetWeekDay( int year, Month month, int day );
    int GetDaysOffset( int year, Month month, int day );
    DateParams GetDateParamsFromDaysOffset( int daysOffset );

    bool IsValidDaysOffset( int daysOffset );
    bool IsDateExists( int year, Month month, int day );
}
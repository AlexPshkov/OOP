using Task1._5_Date.Models;
using Task1._5_Date.Models.Calendars;

namespace Task1._5_Date.Exceptions;

public class DaysOffsetException : Exception
{
    public DaysOffsetException( ICustomCalendar calendar, int daysOffset ) 
        : base( $"Days offset can't be less then {calendar.MinDayOffset} and greater then {calendar.MaxDayOffset}. Your value: {daysOffset}" )
    {
    }
}
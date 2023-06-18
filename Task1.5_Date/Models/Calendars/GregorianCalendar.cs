using Task1._5_Date.Exceptions;
using Task1._5_Date.Models.Enums;

namespace Task1._5_Date.Models.Calendars;

public class GregorianCalendar : ICustomCalendar
{
    private const int MinSupportedYear = 1970;
    private const int MaxSupportedYear = 9999;
    
    private const int DaysInLeapYear = 365;
    private const int DaysInFullYear = 366;

    public int MinDayOffset { get; }
    public int MaxDayOffset { get; }

    private static readonly Dictionary<Month, int> DaysPerMonth = new Dictionary<Month, int>
    {
        { Month.January, 31 },
        { Month.February, 28 },
        { Month.March, 31 },
        { Month.April, 30 },
        { Month.May, 31 },
        { Month.June, 30 },
        { Month.July, 31 },
        { Month.August, 31 },
        { Month.September, 30 },
        { Month.October, 31 },
        { Month.November, 30 },
        { Month.December, 31 }
    };

    public GregorianCalendar()
    {
        MinDayOffset = GetDaysOffset( MinSupportedYear, Month.January, 1 );
        MaxDayOffset = GetDaysOffset( MaxSupportedYear, Month.December, 31 );
    }

    public bool IsLeapYear( int year )
    {
        return year % 4 == 0 && ( year % 100 != 0 || year % 400 == 0 );
    }

    public int GetDaysOffset( int year, Month month, int day )
    {
        if ( !IsDateExists( year, month, day ) )
        {
            throw new DateNotExistsException( year, month, day );
        }

        int days = day;
        for ( int yearIndex = MinSupportedYear; yearIndex < year; yearIndex++ )
        {
            days += IsLeapYear( yearIndex ) ? DaysInFullYear : DaysInLeapYear;
        }
        
        for ( int monthIndex = 1; monthIndex < (int) month; monthIndex++ )
        {
            days += DaysPerMonth[ (Month) monthIndex ];
        }

        if ( IsLeapYear( year ) && month > Month.February )
        {
            days += 1;
        }

        return days - 1;
    }

    public DateParams GetDateParamsFromDaysOffset( int daysOffset )
    {
        int year = MinSupportedYear;
        int month = 1;
        int day = 1;

        int daysInYear = IsLeapYear( year ) ? DaysInFullYear : DaysInLeapYear;

        while ( daysOffset > daysInYear )
        {
            daysOffset -= daysInYear;
            year++;

            daysInYear = IsLeapYear( year ) ? DaysInFullYear : DaysInLeapYear;
        }

        for ( int monthIndex = 1; monthIndex <= (int) Month.December; monthIndex++ )
        {
            int daysInCurrentMonth = GetDaysInMonth( year, (Month) monthIndex );

            if ( daysOffset < daysInCurrentMonth )
            {
                break;
            }

            daysOffset -= daysInCurrentMonth;
            month++;
        }

        if ( month > (int) Month.December )
        {
            month -= (int) Month.December;
            year++;
        }

        day += daysOffset;

        return new DateParams
        {
            Year = year,
            Month = (Month) month,
            Day = day
        };
    }

    public WeekDay GetWeekDay( int year, Month month, int day )
    {
        if ( !IsDateExists( year, month, day ) )
        {
            throw new DateNotExistsException( year, month, day );
        }

        // Коррекция для правильной работы формулы Зеллера
        int monthNum = (int) month;
        if ( monthNum < (int) Month.March ) {
            monthNum += 12;
            year--;
        }
        
        int centuryYear = year % 100;
        int century = year / 100;

        // Формула Зеллера для вычисления дня недели
        int weekDay = ( day + 13 * ( monthNum + 1 ) / 5 + centuryYear + centuryYear / 4 + century / 4 + 5 * century - 1 ) % 7;

        return (WeekDay) weekDay;
    }

    private int GetDaysInMonth( int year, Month month )
    {
        int daysInMonth = DaysPerMonth[ month ];
        if ( month == Month.February && IsLeapYear( year ) )
        {
            daysInMonth++;
        }

        return daysInMonth;
    }

    public bool IsValidDaysOffset( int daysOffset )
    {
        return daysOffset >= MinDayOffset && daysOffset <= MaxDayOffset;
    }

    public bool IsDateExists( int year, Month month, int day )
    {
        if ( year is < MinSupportedYear or > MaxSupportedYear )
        {
            return false;
        }

        if ( month is < Month.January or > Month.December )
        {
            return false;
        }

        if ( day < 1 )
        {
            return false;
        }

        return day <= GetDaysInMonth( year, month );
    }
}
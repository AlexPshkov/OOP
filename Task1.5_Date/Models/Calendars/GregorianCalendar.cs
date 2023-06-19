using Task1._5_Date.Exceptions;
using Task1._5_Date.Models.Enums;

namespace Task1._5_Date.Models.Calendars;

public class GregorianCalendar : ICustomCalendar
{
    private const int MinSupportedYear = 1970;
    private const int MaxSupportedYear = 9999;

    private const int DaysInFullYear = 365;

    private const int DaysInFebruaryLeapYear = 29;
    private const int DaysAfterJulianEra = 719468;
    private const int DaysInFullEra = 146097;
    private const int DaysInSmallEra = 146096;
    private const int YearsInEra = 400;

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

    public int GetDaysOffset( int year, Month month, int day )
    {
        if ( !IsDateExists( year, month, day ) )
        {
            throw new DateNotExistsException( year, month, day );
        }

        int totalDays = day - 1;
        int[] monthDays = GetMonthDays( year );
        for (int index = 0; index < (int) month - 1; index++)
        {
            totalDays += monthDays[index];
        }

        int leapYears = (year - 1969) / 4 - (year - 1901) / 100 + (year - 1601) / 400;
        int daysFromEraToCurrenYear = (year - MinSupportedYear) * DaysInFullYear + leapYears;

        return totalDays + daysFromEraToCurrenYear;
    }

    public DateParams GetDateParamsFromDaysOffset( int daysOffset )
    {
        // Формула Зеллера для вычисления дня, года, месяца
        int daysAfterJulianEra = daysOffset + DaysAfterJulianEra;
        int era = ( daysAfterJulianEra >= 0 ? daysAfterJulianEra : daysAfterJulianEra - DaysInSmallEra ) / DaysInFullEra;
        int daysToCurrentEra = daysAfterJulianEra - era * DaysInFullEra;

        int daysIn1460Years = daysToCurrentEra / 1460; // Количество периодов по 4 года
        int daysIn36524Years = daysToCurrentEra / 36524; // Количество периодов по 100 лет
        int yearsToCurrentEra = ( daysToCurrentEra - daysIn1460Years + daysIn36524Years - daysToCurrentEra / DaysInSmallEra ) / DaysInFullYear;
       
        int daysFromYearBeginning = daysToCurrentEra - ( DaysInFullYear * yearsToCurrentEra + yearsToCurrentEra / 4 - yearsToCurrentEra / 100 + yearsToCurrentEra / YearsInEra );
        
        // Используя "Классический алгоритм даты Йулиана" получем приблизительный месяц
        int monthApproximate = ( 5 * daysFromYearBeginning + 2 ) / 153;
        // Переводим в формат от 1 до 12
        int month = monthApproximate + ( monthApproximate < 10 ? 3 : -9 );
        
        int year = yearsToCurrentEra + era * YearsInEra + ( month <= (int) Month.February ? 1 : 0 );
        int day = daysFromYearBeginning - 1;

        // Нормализуем дни
        int currentMonth = 1;
        int[] monthDays = GetMonthDays( year );
        while ( day > monthDays[ currentMonth - 1 ] )
        {
            day -= monthDays[ currentMonth - 1 ];
            currentMonth++;
        }

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
        if ( monthNum < (int) Month.March )
        {
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
        return GetMonthDays( year )[ (int) month - 1 ];
    }
    
    private int[] GetMonthDays( int year )
    {
        bool isLeapYear = IsLeapYear( year );
        return DaysPerMonth.Select( x =>
        {
            if ( isLeapYear && x.Key == Month.February )
            {
                return DaysInFebruaryLeapYear;
            }

            return x.Value;
        } ).ToArray();
    }
}
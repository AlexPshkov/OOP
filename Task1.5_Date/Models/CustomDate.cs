using Task1._5_Date.Models.Calendars;
using Task1._5_Date.Models.Enums;

namespace Task1._5_Date.Models;

public class CustomDate
{
    private readonly ICustomCalendar _customCalendar;

    private int _daysOffset;

    private DateParams DateParams { get; set; } = new DateParams();

    public bool IsValid { get; set; }
    public int Day => DateParams.Day;
    public int Year => DateParams.Year;
    public Month Month => DateParams.Month;
    public WeekDay WeekDay => _customCalendar.GetWeekDay( Year, Month, Day );

    public CustomDate()
    {
        _customCalendar = new GregorianCalendar();
    }

    #region From-Methods

    public CustomDate FromDayMonthYear( int day, int month, int year )
    {
        Month monthValue = (Month) month;

        IsValid = _customCalendar.IsDateExists( year, monthValue, day );
        if ( !IsValid )
        {
            return this;
        }

        _daysOffset = _customCalendar.GetDaysOffset( year, monthValue, day );
        UpdateDateParams();

        return this;
    }

    public CustomDate FromDays( int daysOffset )
    {
        IsValid = _customCalendar.IsValidDaysOffset( daysOffset );

        if ( !IsValid )
        {
            return this;
        }

        _daysOffset = daysOffset;
        UpdateDateParams();

        return this;
    }

    #endregion

    private void UpdateDateParams()
    {
        if ( !IsValid )
        {
            return;
        }
        
        DateParams = _customCalendar.GetDateParamsFromDaysOffset( _daysOffset );
    }

    private CustomDate AddDays( int days )
    {
        IsValid = _customCalendar.IsValidDaysOffset( _daysOffset + days );

        _daysOffset += days;
        UpdateDateParams();

        return this;
    }

    #region Operators

    public static CustomDate operator ++( CustomDate a ) => a.IsValid ? a.AddDays( 1 ) : a;
    public static CustomDate operator --( CustomDate a ) => a.IsValid ? a.AddDays( -1 ) : a;

    public static CustomDate operator +( CustomDate a, int b ) => a.IsValid ? new CustomDate().FromDays( a._daysOffset + b ) : a;
    public static CustomDate operator -( CustomDate a, int b ) => a.IsValid ? new CustomDate().FromDays( a._daysOffset - b ) : a;
    public static int operator -( CustomDate a, CustomDate b ) => a.IsValid && b.IsValid ? a._daysOffset - b._daysOffset : -1;

    public static bool operator >( CustomDate a, CustomDate b ) => (a._daysOffset > b._daysOffset) && (a.IsValid && b.IsValid);
    public static bool operator <( CustomDate a, CustomDate b ) => (a._daysOffset < b._daysOffset) && (a.IsValid && b.IsValid);

    public static bool operator ==( CustomDate a, CustomDate b ) => (a._daysOffset == b._daysOffset && a.IsValid && b.IsValid) || ( !a.IsValid && !b.IsValid );
    public static bool operator !=( CustomDate a, CustomDate b ) => !( a == b );

    public static bool operator <=( CustomDate a, CustomDate b ) => a < b || a == b;
    public static bool operator >=( CustomDate a, CustomDate b ) => a > b || a == b;

    #endregion Operators

    public override string ToString()
    {
        return IsValid ? $"{Day}.{(int) Month}.{Year}" : "INVALID";
    }
}
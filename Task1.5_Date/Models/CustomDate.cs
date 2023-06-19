using Task1._5_Date.Models.Calendars;
using Task1._5_Date.Models.Enums;

namespace Task1._5_Date.Models;

// Доработать класс, добавить исключения
public class CustomDate
{
    private readonly ICustomCalendar _customCalendar;

    private int _daysOffset;

    private DateParams DateParams { get; set; } = new DateParams();

    public bool IsValid { get; private set; }
    public int Day => DateParams.Day;
    public int Year => DateParams.Year;
    public Month Month => DateParams.Month;
    public WeekDay WeekDay => _customCalendar.GetWeekDay( Year, Month, Day );

    public CustomDate( int day, int month, int year )
    {
        _customCalendar = new GregorianCalendar();
        Month monthValue = (Month) month;

        IsValid = _customCalendar.IsDateExists( year, monthValue, day );
        if ( IsValid )
        {
            _daysOffset = _customCalendar.GetDaysOffset( year, monthValue, day );
            UpdateDateParams();
        }
    }
    
    public CustomDate( int daysOffset )
    {
        _customCalendar = new GregorianCalendar();
        IsValid = _customCalendar.IsValidDaysOffset( daysOffset );

        if ( IsValid )
        {
            _daysOffset = daysOffset;
            UpdateDateParams();
        }
    }

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

    public static CustomDate operator +( CustomDate a, int b ) => a.IsValid ? new CustomDate(a._daysOffset + b ) : a;
    public static CustomDate operator -( CustomDate a, int b ) => a.IsValid ? new CustomDate(a._daysOffset - b ) : a;
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

    private bool Equals( CustomDate other )
    {
        return Equals( _customCalendar, other._customCalendar ) 
               && _daysOffset == other._daysOffset 
               && Equals( DateParams, other.DateParams ) 
               && IsValid == other.IsValid;
    }

    public override bool Equals( object obj )
    {
        if ( ReferenceEquals( null, obj ) ) return false;
        if ( ReferenceEquals( this, obj ) ) return true;
        if ( obj.GetType() != GetType() ) return false;
        return Equals( (CustomDate) obj );
    }

    public override int GetHashCode()
    {
        return HashCode.Combine( _customCalendar, _daysOffset, DateParams, IsValid );
    }
}
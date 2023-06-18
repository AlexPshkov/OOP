using Task1._5_Date.Models.Calendars.Gregorian.Enums;

namespace Task1._5_Date.Models;

public class DateParams
{
    public int Day { get; set; } = 1;
    public Month Month { get; set; } = Month.January;
    public int Year { get; set; } = 1970;
}
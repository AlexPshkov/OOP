using Task1._5_Date.Models.Enums;

namespace Task1._5_Date.Exceptions;

public class DateNotExistsException : Exception
{
    public DateNotExistsException( int year, Month month, int day ) 
        : base( $"Date ({year}/{(int) month}/{day}) not exists" )
    {
    }
}
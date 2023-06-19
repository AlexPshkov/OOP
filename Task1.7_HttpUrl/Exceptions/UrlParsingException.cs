namespace Task1._7_HttpUrl.Exceptions;

public class UrlParsingException : Exception   
{
    public UrlParsingException( string message ) : base( message ) { }
}
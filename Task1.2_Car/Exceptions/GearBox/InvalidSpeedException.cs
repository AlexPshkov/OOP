namespace Task1._2_Car.Exceptions.GearBox;

public class InvalidSpeedException : CarException
{
    public InvalidSpeedException( string? message ) : base( message )
    {
    }
}
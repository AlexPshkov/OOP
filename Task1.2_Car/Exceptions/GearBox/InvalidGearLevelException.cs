namespace Task1._2_Car.Exceptions.GearBox;

public class InvalidGearLevelException : CarException
{
    public InvalidGearLevelException( string? message ) : base( message )
    {
    }
}
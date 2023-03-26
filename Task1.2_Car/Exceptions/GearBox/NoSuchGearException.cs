using Task1._2_Car.Enums;

namespace Task1._2_Car.Exceptions.GearBox;

public class NoSuchGearException : CarException
{
    public NoSuchGearException( GearLevel gearLevel ) 
        : base( $"There is no such gear in gearbox. Gear { (int) gearLevel }" )
    {
    }
}
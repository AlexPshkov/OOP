using Task1._2_Car.Enums;
using Task1._2_Car.Exceptions.GearBox;

namespace Task1._2_Car.Models.Components.Implementation;

public class Gearbox : IGearBox
{
    private readonly Dictionary<GearLevel, Gear> _gears = new Dictionary<GearLevel, Gear>
    {
        { GearLevel.REVERSE, new Gear { MinSpeed = 0, MaxSpeed = 20 } },
        { GearLevel.NEUTRAl, new Gear() },
        { GearLevel.FIRST, new Gear { MinSpeed = 0, MaxSpeed = 30 } },
        { GearLevel.SECOND, new Gear { MinSpeed = 20, MaxSpeed = 50 } },
        { GearLevel.THIRD, new Gear { MinSpeed = 30, MaxSpeed = 60 } },
        { GearLevel.FOURTH, new Gear { MinSpeed = 40, MaxSpeed = 90 } },
        { GearLevel.FIFTH, new Gear { MinSpeed = 50, MaxSpeed = 150 } }
    };
    
    public GearLevel CurrentGearLevel { get; private set; }

    public void EngageGear( GearLevel gearLevel, int speed )
    {
        Gear gear = GetGear( gearLevel );

        if ( gearLevel != GearLevel.NEUTRAl && ( speed > gear.MaxSpeed || speed < gear.MinSpeed ) )
        {
            const string errorMessage = "The speed is too high or too low for gear {0}. Speed: {1}. Min: {2}. Max: {3}";
            throw new InvalidGearLevelException( string.Format( errorMessage, (int) gearLevel, speed, gear.MinSpeed, gear.MaxSpeed ) );
        }
        
        CurrentGearLevel = gearLevel;
    }

    public Gear GetCurrentGear()
    {
        return GetGear( CurrentGearLevel );
    }
    
    private Gear GetGear( GearLevel gearLevel )
    {
        if ( !_gears.TryGetValue( gearLevel, out Gear? gear ) )
        {
            throw new NoSuchGearException( gearLevel );
        }

        return gear ?? throw new NoSuchGearException( gearLevel );
    }
}
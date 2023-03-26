using Task1._2_Car.Enums;
using Task1._2_Car.Models.Components.Implementation;

namespace Task1._2_Car.Models.Components;

public interface IGearBox
{
    public GearLevel CurrentGearLevel { get; }
    void EngageGear( GearLevel gearLevel, int speed );
    Gear GetCurrentGear();
}
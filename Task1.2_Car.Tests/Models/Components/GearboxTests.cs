using Task1._2_Car.Enums;
using Task1._2_Car.Exceptions.GearBox;
using Task1._2_Car.Models.Components;
using Task1._2_Car.Models.Components.Implementation;
using Xunit;

namespace Task1._2_Car.Tests.Models.Components;

public class GearboxTests
{
    [Fact]
    public void Gearbox_EngageGear_ValidFirstGear_EngagedGear()
    {
        // Arrange
        IGearBox gearBox = new Gearbox();

        // Act
        gearBox.EngageGear( GearLevel.FIRST, 0 );

        // Assert
        Assert.Equivalent( GearLevel.FIRST,  gearBox.CurrentGearLevel );
    }
    
    [Fact]
    public void Gearbox_EngageGear_ValidSecondGear_EngagedGear()
    {
        // Arrange
        IGearBox gearBox = new Gearbox();

        // Act
        gearBox.EngageGear( GearLevel.SECOND, 30 );

        // Assert
        Assert.Equivalent( GearLevel.SECOND, gearBox.CurrentGearLevel );
    }
    
    [Fact]
    public void Gearbox_EngageGear_InvalidGear_GetError()
    {
        // Arrange
        IGearBox gearBox = new Gearbox();

        // Act && Assert
        Assert.Throws<NoSuchGearException>( () => gearBox.EngageGear( (GearLevel) (-2), 0 ));
    }
    
    [Fact]
    public void Gearbox_EngageGear_InvalidGearForSpeed_GetError()
    {
        // Arrange
        IGearBox gearBox = new Gearbox();

        // Act && Assert
        Assert.Throws<InvalidGearLevelException>( () => gearBox.EngageGear( GearLevel.SECOND, 0 ));
    }
}
using Task1._2_Car.Enums;
using Task1._2_Car.Exceptions.GearBox;
using Task1._2_Car.Models;
using Xunit;

namespace Task1._2_Car.Tests.Models;

public class CarTests
{
    [Fact]
    public void Car_Construct_ValidateInitialState_CorrectState()
    {
        // Arrange && Act
        ICar car = new Car();

        // Assert
        Assert.False( car.IsTurnedOn() );
        Assert.Equivalent( 0,  car.GetSpeed() );
        Assert.Equivalent( 0,  car.GetGear() );
        Assert.Equivalent( MovementDirection.NONE,  car.GetDirection() );
    }

    #region Engine
    [Fact]
    public void Car_TurnOnEngine_SimpleStartEngine_Started()
    {
        // Arrange
        ICar car = new Car();

        // Act
        car.TurnOnEngine();

        // Assert
        Assert.True( car.IsTurnedOn() );
    }
    
    [Fact]
    public void Car_TurnOffEngine_SimpleStartAndStopEngine_Stopped()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();

        // Act
        car.TurnOffEngine();

        // Assert
        Assert.False( car.IsTurnedOn() );
    }
    
    [Fact]
    public void Car_TurnOffEngine_StopEngineInFirstGear_NonStopped()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( 1 );

        // Act
        car.TurnOffEngine();

        // Assert
        Assert.True( car.IsTurnedOn() );
    }
    
    [Fact]
    public void Car_TurnOffEngine_StopEngineWithSpeed_NonStopped()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( 1 );
        car.SetSpeed( 10 );
        car.SetGear( 0 );

        // Act
        car.TurnOffEngine();

        // Assert
        Assert.True( car.IsTurnedOn() );
    }
    #endregion

    #region SetGear
    [Fact]
    public void Car_SetGear_SetNeutralGearInNonWorkingEngine_NoErrors()
    {
        // Arrange
        ICar car = new Car();

        // Act
        car.SetGear( 0 );

        // Assert
        Assert.Equivalent( 0, car.GetGear());
    }
    
    [Fact]
    public void Car_SetGear_SetFirstGearInNonWorkingEngine_GetErrors()
    {
        // Arrange
        ICar car = new Car();

        // Act && Assert
        Assert.Throws<InvalidGearLevelException>(() => car.SetGear( 1 ) );
    }
    
    [Fact]
    public void Car_SetGear_SetFirstGearInWorkingEngine_NoErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();

        // Act
        car.SetGear( 1 );

        // Assert
        Assert.Equivalent( 1, car.GetGear());
    }
    
    [Fact]
    public void Car_SetGear_SetReverseIfNoSpeed_NoErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( 1 );
        car.SetSpeed( 10 );
        car.SetSpeed( 0 );

        // Act
        car.SetGear( -1 );
        
        // Assert
        Assert.Equivalent( -1, car.GetGear() );
    }
    
    [Fact]
    public void Car_SetGear_SetReverseIfSpeedExists_GetErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( -1 );
        car.SetSpeed( 10 );
        car.SetGear( 0 );

        // Act && Assert
        Assert.Throws<InvalidGearLevelException>(() => car.SetGear( -1 ) );
    }
    
    [Fact]
    public void Car_SetGear_SetFirstIfGoingBackward_GetErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( -1 );
        car.SetSpeed( 10 );
        car.SetGear( 0 );

        // Act && Assert
        Assert.Throws<InvalidGearLevelException>(() => car.SetGear( 1 ) );
    }
    
    [Fact]
    public void Car_SetGear_SetFirstIfStoppedAfterGoingBackward_GetErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( -1 );
        car.SetSpeed( 10 );
        car.SetGear( 0 );
        car.SetSpeed( 0 );

        // Act
         car.SetGear( 1 );
         
         // Assert 
         Assert.Equivalent( 1, car.GetGear() );
    }
    #endregion

    #region SetSpeed
    [Fact]
    public void Car_SetSpeed_SetSpeedInNeutral_GetErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();

        // Act && Assert
        Assert.Throws<InvalidSpeedException>(() => car.SetSpeed( 10 ) );
    }
    
    [Fact]
    public void Car_SetSpeed_SetSpeedMoreInNeutral_GetErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( 1 );
        car.SetSpeed( 10 );
        car.SetGear( 0 );

        // Act && Assert
        Assert.Throws<InvalidSpeedException>(() => car.SetSpeed( 15 ) );
    }

    [Fact]
    public void Car_SetSpeed_SetSpeedLessInNeutral_NoErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( 1 );
        car.SetSpeed( 10 );
        car.SetGear( 0 );

        // Act
        car.SetSpeed( 5 );

        // Assert 
        Assert.Equivalent( 5, car.GetSpeed() );
    }
    
    [Fact]
    public void Car_SetSpeed_SetSpeedMoreThenCurrentGear_GetErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( 1 );

        // Act && Assert
        Assert.Throws<InvalidSpeedException>(() => car.SetSpeed( 35 ) );
    }
    
    [Fact]
    public void Car_SetSpeed_SetSpeedLessThenCurrentGear_GetErrors()
    {
        // Arrange
        ICar car = new Car();
        car.TurnOnEngine();
        car.SetGear( 1 );
        car.SetSpeed( 30 );
        car.SetGear( 2 );

        // Act && Assert
        Assert.Throws<InvalidSpeedException>(() => car.SetSpeed( 15 ) );
    }
    #endregion
}
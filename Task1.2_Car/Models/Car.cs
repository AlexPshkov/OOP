using Task1._2_Car.Enums;
using Task1._2_Car.Exceptions.GearBox;
using Task1._2_Car.Models.Components;
using Task1._2_Car.Models.Components.Implementation;

namespace Task1._2_Car.Models;

public class Car : ICar
{
    private MovementDirection _movementDirection;
    private int _currentSpeed;

    private readonly IEngine _engine;
    private readonly IGearBox _gearBox;

    public Car()
    {
        _engine = new Engine();
        _gearBox = new Gearbox();
    }

    #region Getters

    public bool IsTurnedOn()
    {
        return _engine.IsStarted;
    }

    public MovementDirection GetDirection()
    {
        return _movementDirection;
    }

    public int GetSpeed()
    {
        return _currentSpeed;
    }

    public int GetGear()
    {
        return (int) _gearBox.CurrentGearLevel;
    }

    #endregion

    #region TurnEngine
    public bool TurnOnEngine()
    {
        try
        {
            _engine.Start();
            return true;
        }
        catch ( Exception )
        {
            return false;
        }
    }

    public bool TurnOffEngine()
    {
        if ( _currentSpeed != 0 || _gearBox.CurrentGearLevel != GearLevel.NEUTRAl )
        {
            return false;
        }

        try
        {
            _engine.Stop();
            return true;
        }
        catch ( Exception )
        { 
            return false;
        }
    }
    #endregion

    #region Setters
    public bool SetGear( int gear )
    {
        if ( !_engine.IsStarted && gear != (int) GearLevel.NEUTRAl )
        {
            throw new InvalidGearLevelException( "When the engine is off, you can only shift into neutral" );
        }
        
        if ( _movementDirection != MovementDirection.NONE && gear < (int) GearLevel.NEUTRAl )
        {
            throw new InvalidGearLevelException( "If you are not standing, you can't shift below neutral" );
        }

        if ( _movementDirection == MovementDirection.BACKWARD && gear > (int) GearLevel.NEUTRAl )
        {
            throw new InvalidGearLevelException( "If you're going in reverse, you can't shift above neutral" );
        }

        _gearBox.EngageGear( (GearLevel) gear, _currentSpeed );
        return true;
    }

    public bool SetSpeed( int speed )
    {
        if ( _gearBox.CurrentGearLevel == GearLevel.NEUTRAl && speed > _currentSpeed )
        {
            throw new InvalidSpeedException( "In neutral, the speed can only decrease" );
        }

        Gear gear = _gearBox.GetCurrentGear();
        if ( _gearBox.CurrentGearLevel != GearLevel.NEUTRAl && ( speed > gear.MaxSpeed || speed < gear.MinSpeed ) )
        {
            const string errorMessage = "Speed can't be more or less then current gearLevel support. Max: {0}. Min: {1}";
            throw new InvalidSpeedException( string.Format( errorMessage, gear.MaxSpeed, gear.MinSpeed ) );
        }

        HandleSpeedChange( speed );

        _currentSpeed = speed;
        return true;
    }
    #endregion
    
    private void HandleSpeedChange( int speed )
    {
        if ( speed == 0 )
        {
            _movementDirection = MovementDirection.NONE;
            return;
        }

        switch ( _gearBox.CurrentGearLevel )
        {
            case > GearLevel.NEUTRAl:
                _movementDirection = MovementDirection.FORWARD;
                return;
            case < GearLevel.NEUTRAl:
                _movementDirection = MovementDirection.BACKWARD;
                return;
        }
    }
}
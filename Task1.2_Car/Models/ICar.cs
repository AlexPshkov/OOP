using Task1._2_Car.Enums;

namespace Task1._2_Car.Models;

public interface ICar
{
    bool IsTurnedOn();
    MovementDirection GetDirection();
    int GetSpeed();
    int GetGear();
    
    bool TurnOnEngine();
    bool TurnOffEngine();
    
    bool SetGear( int gear );
    bool SetSpeed( int speed );
}
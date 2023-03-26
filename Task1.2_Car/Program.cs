using Task1._2_Car.Exceptions;
using Task1._2_Car.Models;

namespace Task1._2_Car;

public static class Program
{
    private static Dictionary<string, Action<string[]>> Commands = new Dictionary<string, Action<string[]>>
    {
        {"info", GetCarInfo },
        {"engineon", EngineOn },
        {"engineoff", EngineOff },
        {"setgear", SetGear },
        {"setspeed", SetSpeed }
    };
    
    private static readonly ICar _car = new Car();
    
    public static int Main()
    {
        StartHandlingCommands();
        return 0;
    }

    private static void StartHandlingCommands()
    {
        string? input;
        while ( !string.IsNullOrEmpty( input = Console.ReadLine() ) )
        {
            string[] arguments = input.Split( ' ' );
            if ( Commands.TryGetValue( arguments[0].ToLower(), out Action<string[]>? command ) )
            {
                command.Invoke( arguments[1..] );
                continue;
            }
            
            Console.WriteLine( $"No such command \"{arguments[0]}\"" );
        }
    }
    
    private static void GetCarInfo( IReadOnlyCollection<object> args )
    {
        const string carInfo = "Car Info:\n Engine: {0} \n Direction: {1} \n Speed: {2} \n Gear: {3}\n";
        Console.WriteLine( carInfo, _car.IsTurnedOn(), _car.GetDirection(), _car.GetSpeed(), _car.GetGear() );
    }
    
    private static void EngineOn( IReadOnlyCollection<string> args )
    {
        if ( _car.TurnOnEngine() )
        {
            Console.WriteLine( "Successfully started" );
            return;
        }
        
        Console.WriteLine( "Failed to start engine" );
    }
    
    private static void EngineOff( IReadOnlyCollection<string> args )
    {
        if ( _car.TurnOffEngine() )
        {
            Console.WriteLine( "Successfully stopped" );
            return;
        }
        
        Console.WriteLine( "Failed to stop engine" );
    }
    
    private static void SetGear( IReadOnlyCollection<string> args )
    {
        if ( args.Count != 1 )
        {
            Console.WriteLine("Use: SetGear <gearLevel>");
            return;
        }

        try
        {
            int gearLevel = TryToGetNumber( args.First() );
            if ( _car.SetGear( gearLevel ) )
            {
                Console.WriteLine( "Successfully gear set" );
                return;
            }

            Console.WriteLine( $"Failed to set gear {gearLevel}" );
        }
        catch ( CarException exception )
        {
            Console.WriteLine( $"Fail. {exception.Message}" );
        }
        catch ( ArgumentException exception )
        {
            Console.WriteLine( $"Fail. {exception.Message}. Use: SetGear <gearLevel>" );
        }
    }
    
    private static void SetSpeed( IReadOnlyCollection<string> args  )
    {
        if ( args.Count != 1 )
        {
            Console.WriteLine("Use: SetSpeed <speed>");
            return;
        }
        
        try
        {
            int speed = TryToGetNumber( args.First(), true );
            if ( _car.SetSpeed( speed ) )
            {
                Console.WriteLine( "Successfully speed set" );
                return;
            }
            
            Console.WriteLine( $"Failed to set speed { speed }" );
        }
        catch ( CarException exception )
        {
            Console.WriteLine( $"Fail. { exception.Message }");
        }
        catch ( ArgumentException exception )
        {
            Console.WriteLine( $"Fail. {exception.Message}. Use: SetSpeed <speed>" );
        }
    }

    private static int TryToGetNumber( string? value, bool mustBePositive = false )
    {
        if ( !int.TryParse( value, out int number ) )
        {
            throw new ArgumentException( $"\"{value}\" is not a number" );
        }

        if ( mustBePositive && number < 0 )
        {
            throw new ArgumentException( $"\"{value}\" is not a positive number" );
        }

        return number;
    }
}
using Task1._2_Shapes.UI.Commands;

namespace Task1._2_Shapes.UI;

public static class CommandHandler
{
    private static readonly Dictionary<string, AbstractUserCommand> UserCommands = new Dictionary<string, AbstractUserCommand>
    {
        { StopCommand.CommandName, new StopCommand() },
        { ListCommand.CommandName, new ListCommand() },
        { RectangleCommand.CommandName, new RectangleCommand() },
        { LineSegmentCommand.CommandName, new LineSegmentCommand() },
        { TriangleCommand.CommandName, new TriangleCommand() },
        { CircleCommand.CommandName, new CircleCommand() }
    };

    private static bool _isRunning;


    public static List<string> GetCommandsUsages()
    {
        return UserCommands.Values.Select( x => x.CommandUse ).ToList();
    }
    
    public static void StopCommandHandling()
    {
        _isRunning = false;
    }

    public static void StartCommandHandling()
    {
        _isRunning = true;
        
        while ( _isRunning )
        {
            Console.Write("> ");
            Handle( Console.ReadLine() );
        }
    }

    private static void Handle( string? inputLine )
    {
        if ( inputLine == null )
        {
            return;
        }

        if ( string.IsNullOrWhiteSpace( inputLine ) )
        {
            PrintUnknownCommand( inputLine );
            return;
        }

        string[] args = inputLine.Split( " " );
        if ( args.Length < 1 )
        {
            PrintUnknownCommand( inputLine );
            return;
        }

        string commandName = args[ 0 ].ToLower();
        if ( !UserCommands.ContainsKey( commandName ) )
        {
            PrintUnknownCommand( args[ 0 ] );
            return;
        }
        
        try
        {
            UserCommands[ commandName ].Execute( args );
        }
        catch ( Exception exception )
        {
            Console.WriteLine( exception.Message );
        }
    }

    private static void PrintUnknownCommand( string text )
    {
        Console.WriteLine( $"Unknown command '{text}'" );
    }
}
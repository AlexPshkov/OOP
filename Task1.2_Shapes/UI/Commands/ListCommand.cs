namespace Task1._2_Shapes.UI.Commands;

public class ListCommand : AbstractUserCommand
{
    public static string CommandName => "list";

    public override string CommandUse => "Use: list";


    public override void Execute( string[] args )
    {
        Console.WriteLine( "\nCommands list:" );
        
        foreach ( string commandsUsage in CommandHandler.GetCommandsUsages() )
        {
            Console.WriteLine($" * {commandsUsage}");
        }
        Console.WriteLine();
    }

    
}
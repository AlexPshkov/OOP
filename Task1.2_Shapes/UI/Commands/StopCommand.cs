using Task1._2_Shapes.Shapes;

namespace Task1._2_Shapes.UI.Commands;

public class StopCommand : AbstractUserCommand
{
    public static string CommandName => "stop";

    public override string CommandUse => "Use: stop";


    public override void Execute( string[] args )
    {
        CommandHandler.StopCommandHandling();
        Console.WriteLine( "Stopped" );

        IShape? highestAreaShape = Program.GetShapeWithHighestArea();
        IShape? smallestPerimeterShape = Program.GetShapeWithSmallestPerimeter();

        Console.WriteLine( "============================[RESULT]================================");
        Console.WriteLine( $"\nShape with highest area size: \n{highestAreaShape?.ToString() ?? "NONE"}" );
        Console.WriteLine( $"\n\nShape with smalles perimeter size: \n{smallestPerimeterShape?.ToString() ?? "NONE"}" );
    }
}
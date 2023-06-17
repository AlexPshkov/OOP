using System.Drawing;
using Task1._2_Shapes.Shapes;
using Task1._2_Shapes.Shapes.Implementation;
using Task1._2_Shapes.UI.Exceptions;

namespace Task1._2_Shapes.UI.Commands;

public class CircleCommand : AbstractUserCommand
{
    public static string CommandName => "circle";

    public override string CommandUse =>
        "Use: circle <posX> <posY> <radius> <outlineColor> <fillColor>";


    public override void Execute( string[] args )
    {
        GetParameters( args,
            out double posX,
            out double posY,
            out double radius,
            out Color outlineColor,
            out Color fillColor  );
        
        Point centerPoint = new Point( posX, posY );

        IShape rectangle = new Circle( centerPoint, radius, fillColor, outlineColor );
        Program.AddShape( rectangle );

        Console.WriteLine( "Circle successfully created" );
    }


    private void GetParameters( IReadOnlyList<string> args,
        out double posX,
        out double posY,
        out double radius,
        out Color outlineColor,
        out Color fillColor  )
    {
        if ( args.Count < 6 )
        {
            throw new CommandException( this, "Wrong amount of args." );
        }


        if ( !double.TryParse( args[ 1 ], out posX ) || posX < 0 )
        {
            throw new CommandException( this, "Wrong <posX> type. Must be positive double" );
        }
        if ( !double.TryParse( args[ 2 ], out posY ) || posY < 0 )
        {
            throw new CommandException( this, "Wrong <posY> type. Must be positive double" );
        }
        if ( !double.TryParse( args[ 3 ], out radius ) || radius < 0 )
        {
            throw new CommandException( this, "Wrong <radius> type. Must be positive double" );
        }
        
        try
        {
            outlineColor = ColorTranslator.FromHtml( args[ 4 ] );
            fillColor = ColorTranslator.FromHtml( args[ 5 ] );
        }
        catch ( Exception exception )
        {
            throw new CommandException( this, exception.Message );
        }
    }
}
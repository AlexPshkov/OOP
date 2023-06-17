using System.Drawing;
using Task1._2_Shapes.Shapes;
using Task1._2_Shapes.Shapes.Implementation;
using Task1._2_Shapes.UI.Exceptions;
using Rectangle = Task1._2_Shapes.Shapes.Implementation.Rectangle;

namespace Task1._2_Shapes.UI.Commands;

public class RectangleCommand : AbstractUserCommand
{
    public static string CommandName => "rectangle";

    public override string CommandUse =>
        "Use: rectangle <posX> <posY> <width> <height> <outlineColor> <fillColor>";


    public override void Execute( string[] args )
    {
        GetParameters( args,
            out double posX,
            out double posY,
            out double width,
            out double height,
            out Color outlineColor,
            out Color fillColor );

        double halfWidth = width / 2;
        double halfHeight = height / 2;

        Point leftPoint = new Point( posX - halfWidth, posY + halfHeight );
        Point rightPoint = new Point( posX + halfWidth, posY - halfHeight );
        
        IShape rectangle = new Rectangle( leftPoint, rightPoint, fillColor, outlineColor );
        Program.AddShape( rectangle );

        Console.WriteLine( "Rectangle successfully created" );
    }


    private void GetParameters( IReadOnlyList<string> args,
        out double posX,
        out double posY,

        out double width,
        out double height,
        out Color outlineColor,
        out Color fillColor )
    {
        if ( args.Count < 7 )
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


        if ( !double.TryParse( args[ 3 ], out width ) || width < 0 )
        {
            throw new CommandException( this, "Wrong <width> type. Must be positive double" );
        }

        if ( !double.TryParse( args[ 4 ], out height ) || height < 0 )
        {
            throw new CommandException( this, "Wrong <height> type. Must be positive double" );
        }


        try
        {
            outlineColor = ColorTranslator.FromHtml( args[ 5 ] );
            fillColor = ColorTranslator.FromHtml( args[ 6 ] );
        }
        catch ( Exception exception )
        {
            throw new CommandException( this, exception.Message );
        }
    }
}
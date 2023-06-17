using System.Drawing;
using Task1._2_Shapes.Shapes;
using Task1._2_Shapes.Shapes.Implementation;
using Task1._2_Shapes.UI.Exceptions;
using Rectangle = Task1._2_Shapes.Shapes.Implementation.Rectangle;

namespace Task1._2_Shapes.UI.Commands;

public class TriangleCommand : AbstractUserCommand
{
    public static string CommandName => "triangle";

    public override string CommandUse =>
        "Use: triangle <vertX1> <vertY1> <vertX2> <vertY2> <vertX3> <vertY3> <outlineColor> <fillColor>";


    public override void Execute( string[] args )
    {
        GetParameters( args,
            out double vertX1,
            out double vertY1,
            out double vertX2,
            out double vertY2,
            out double vertX3,
            out double vertY3,
            out Color outlineColor,
            out Color fillColor  );
        

        Point vertexPoint1 = new Point( vertX1, vertY1 );
        Point vertexPoint2 = new Point( vertX2, vertY2 );
        Point vertexPoint3 = new Point( vertX3, vertY3 );

        IShape rectangle = new Triangle( vertexPoint1, vertexPoint2, vertexPoint3, fillColor, outlineColor );
        Program.AddShape( rectangle );

        Console.WriteLine( "Triangle successfully created" );
    }


    private void GetParameters( IReadOnlyList<string> args,
        out double vertX1,
        out double vertY1,
        out double vertX2,
        out double vertY2,
        out double vertX3,
        out double vertY3,
        out Color outlineColor,
        out Color fillColor )
    {
        if ( args.Count < 9 )
        {
            throw new CommandException( this, "Wrong amount of args." );
        }


        if ( !double.TryParse( args[ 1 ], out vertX1 ) || vertX1 < 0 )
        {
            throw new CommandException( this, "Wrong <vertX1> type. Must be positive double" );
        }
        if ( !double.TryParse( args[ 2 ], out vertY1 ) || vertY1 < 0 )
        {
            throw new CommandException( this, "Wrong <vertY1> type. Must be positive double" );
        }
        if ( !double.TryParse( args[ 3 ], out vertX2 ) || vertX2 < 0 )
        {
            throw new CommandException( this, "Wrong <vertX2> type. Must be positive double" );
        }
        if ( !double.TryParse( args[ 4 ], out vertY2 ) || vertY2 < 0 )
        {
            throw new CommandException( this, "Wrong <vertY2> type. Must be positive double" );
        }
        if ( !double.TryParse( args[ 5 ], out vertX3 ) || vertX3 < 0 )
        {
            throw new CommandException( this, "Wrong <vertX3> type. Must be positive double" );
        }
        if ( !double.TryParse( args[ 6 ], out vertY3 ) || vertY3 < 0 )
        {
            throw new CommandException( this, "Wrong <vertY3> type. Must be positive double" );
        }


        try
        {
            outlineColor = ColorTranslator.FromHtml( args[ 7 ] );
            fillColor = ColorTranslator.FromHtml( args[ 8 ] );
        }
        catch ( Exception exception )
        {
            throw new CommandException( this, exception.Message );
        }
    }
}
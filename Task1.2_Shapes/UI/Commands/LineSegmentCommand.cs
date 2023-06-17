using System.Drawing;
using Task1._2_Shapes.Shapes;
using Task1._2_Shapes.Shapes.Implementation;
using Task1._2_Shapes.UI.Exceptions;
using Rectangle = Task1._2_Shapes.Shapes.Implementation.Rectangle;

namespace Task1._2_Shapes.UI.Commands;

public class LineSegmentCommand : AbstractUserCommand
{
    public static string CommandName => "lineSegment";

    public override string CommandUse =>
        "Use: lineSegment <startX> <startY> <endX> <endY> <outlineColor>";


    public override void Execute( string[] args )
    {
        GetParameters( args,
            out double startX,
            out double startY,
            out double endX,
            out double endY,
            out Color outlineColor );
        
        Point startPoint = new Point( startX, startY );
        Point endPoint = new Point( endX, endY );
        
        IShape rectangle = new LineSegment( startPoint, endPoint, outlineColor );
        Program.AddShape( rectangle );

        Console.WriteLine( "LineSegment successfully created" );
    }


    private void GetParameters( IReadOnlyList<string> args,
        out double startX,
        out double startY,
        out double endX,
        out double endY,
        out Color outlineColor )
    {
        if ( args.Count < 6 )
        {
            throw new CommandException( this, "Wrong amount of args." );
        }


        if ( !double.TryParse( args[ 1 ], out startX ) || startX < 0 )
        {
            throw new CommandException( this, "Wrong <startX> type. Must be positive double" );
        }

        if ( !double.TryParse( args[ 2 ], out startY ) || startY < 0 )
        {
            throw new CommandException( this, "Wrong <startY> type. Must be positive double" );
        }


        if ( !double.TryParse( args[ 3 ], out endX ) || endX < 0 )
        {
            throw new CommandException( this, "Wrong <endX> type. Must be positive double" );
        }

        if ( !double.TryParse( args[ 4 ], out endY ) || endY < 0 )
        {
            throw new CommandException( this, "Wrong <endY> type. Must be positive double" );
        }


        try
        {
            outlineColor = ColorTranslator.FromHtml( args[ 5 ] );
        }
        catch ( Exception exception )
        {
            throw new CommandException( this, exception.Message );
        }
    }
}
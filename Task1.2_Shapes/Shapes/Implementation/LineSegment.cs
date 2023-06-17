using System.Drawing;
using System.Text;

namespace Task1._2_Shapes.Shapes.Implementation;

public class LineSegment : IShape
{
    private readonly Point _startPoint;
    private readonly Point _endPoint;
    private readonly Color _outlineColor;

    public LineSegment( Point startPoint, Point endPoint, Color outlineColor )
    {
        _startPoint = startPoint;
        _endPoint = endPoint;
        _outlineColor = outlineColor;
    }

    public double GetArea()
    {
        return 0.0;
    }

    public double GetPerimeter()
    {
        return Point.GetDistance( _startPoint, _endPoint );
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder( "===[LINE]===\n" );

        stringBuilder.Append( $" - Start Point: ({_startPoint.X}, {_startPoint.Y}) \n" );
        stringBuilder.Append( $" - End Point: ({_endPoint.X}, {_endPoint.Y}) \n" );
        stringBuilder.Append( $" - Outline Color: #{GetOutlineColor()} \n" );
        stringBuilder.Append( $" - Area: {GetArea()} \n" );
        stringBuilder.Append( $" - Perimeter: {GetPerimeter()} \n" );

        return stringBuilder.ToString();
    }

    public Color GetOutlineColor()
    {
        return _outlineColor;
    }

    public void Draw( Canvas.Canvas canvas )
    {
        canvas.DrawLine( _startPoint, _endPoint, _outlineColor );
    }

    public Point GetStartPoint()
    {
        return _startPoint;
    }

    public Point GetEndPoint()
    {
        return _startPoint;
    }
}
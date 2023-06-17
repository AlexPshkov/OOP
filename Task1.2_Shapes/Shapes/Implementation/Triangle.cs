using System.Drawing;
using System.Text;

namespace Task1._2_Shapes.Shapes.Implementation;

public class Triangle : ISolidShape
{
    private readonly Point _vertex1;
    private readonly Point _vertex2;
    private readonly Point _vertex3;
    private readonly Color _fillColor;
    private readonly Color _outlineColor;

    public Triangle( Point vertex1, Point vertex2, Point vertex3, Color fillColor, Color outlineColor )
    {
        _vertex1 = vertex1;
        _vertex2 = vertex2;
        _vertex3 = vertex3;
        _fillColor = fillColor;
        _outlineColor = outlineColor;
    }

    public double GetArea()
    {
        double halfPerimeter = GetPerimeter() / 2;
        double distanceVertex12 = Point.GetDistance( _vertex1, _vertex2 );
        double distanceVertex13 = Point.GetDistance( _vertex1, _vertex3 );
        double distanceVertex23 = Point.GetDistance( _vertex2, _vertex3 );

        double triangleArea = Math.Sqrt( halfPerimeter * ( halfPerimeter - distanceVertex12 ) *
                                         ( halfPerimeter - distanceVertex12 ) * ( halfPerimeter - distanceVertex12 ) );
        return triangleArea;
    }

    public double GetPerimeter()
    {
        double distanceVertex12 = Point.GetDistance( _vertex1, _vertex2 );
        double distanceVertex13 = Point.GetDistance( _vertex1, _vertex3 );
        double distanceVertex23 = Point.GetDistance( _vertex2, _vertex3 );

        return distanceVertex12 + distanceVertex13 + distanceVertex23;
    }

    public Color GetOutlineColor()
    {
        return _outlineColor;
    }

    public Color GetFillColor()
    {
        return _fillColor;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder( "===[TRIANGLE]===\n" );

        stringBuilder.Append( $" - Vertex #1: ({_vertex1.X}, {_vertex1.Y}) \n" );
        stringBuilder.Append( $" - Vertex #2: ({_vertex2.X}, {_vertex2.Y}) \n" );
        stringBuilder.Append( $" - Vertex #3: ({_vertex3.X}, {_vertex3.Y}) \n" );
        stringBuilder.Append( $" - Outline Color: #{GetOutlineColor()} \n" );
        stringBuilder.Append( $" - Fill Color: #{GetFillColor()} \n" );
        stringBuilder.Append( $" - Area: {GetArea()} \n" );
        stringBuilder.Append( $" - Perimeter: {GetPerimeter()} \n" );
        
        return stringBuilder.ToString();
    }

    public void Draw( Canvas.Canvas canvas )
    {
        canvas.FillPolygon( new List<Point> { _vertex1, _vertex2, _vertex3 }, GetFillColor() );
        canvas.DrawLine( _vertex1, _vertex2, GetOutlineColor() );
        canvas.DrawLine( _vertex2, _vertex3, GetOutlineColor() );
        canvas.DrawLine( _vertex1, _vertex3, GetOutlineColor() );
    }
}
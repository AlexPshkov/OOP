using System.Drawing;
using System.Text;

namespace Task1._2_Shapes.Shapes.Implementation;

public class Circle : ISolidShape
{
    private readonly Point _centerPoint;
    private readonly double _radius;
    private readonly Color _fillColor;
    private readonly Color _outlineColor;

    public Circle( Point centerPoint, double radius, Color fillColor, Color outlineColor )
    {
        _centerPoint = centerPoint;
        _radius = radius;
        _fillColor = fillColor;
        _outlineColor = outlineColor;
    }

    public double GetArea()
    {
        double area = Math.PI * _radius * _radius;
        return area;
    }

    public double GetPerimeter()
    {
        double perimeter = 2 * Math.PI * _radius;
        return perimeter;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder( "===[CIRCLE]===\n" );

        stringBuilder.Append( $" - Center: ({_centerPoint.X}, {_centerPoint.Y}) \n" );
        stringBuilder.Append( $" - Radius: {_radius} \n" );
        stringBuilder.Append( $" - Outline Color: #{GetOutlineColor()} \n" );
        stringBuilder.Append( $" - Fill Color: #{GetFillColor()} \n" );
        stringBuilder.Append( $" - Area: {GetArea()} \n" );
        stringBuilder.Append( $" - Perimeter: {GetPerimeter()} \n" );

        return stringBuilder.ToString();
    }

    public Color GetOutlineColor()
    {
        return _outlineColor;
    }

    public Color GetFillColor()
    {
        return _fillColor;
    }

    public void Draw( Canvas.Canvas canvas )
    {
        canvas.FillCircle( _centerPoint, _radius, GetFillColor() );
        canvas.DrawCircle( _centerPoint, _radius, GetOutlineColor() );
    }
}
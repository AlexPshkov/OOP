using System.Drawing;
using System.Text;

namespace Task1._2_Shapes.Shapes.Implementation;

public class Rectangle : ISolidShape
{
    private readonly Point _leftTopPoint;
    private readonly Point _rightBottomPoint;
    private readonly Color _fillColor;
    private readonly Color _outlineColor;

    public Rectangle( Point leftTopPoint, Point rightBottomPoint, Color fillColor, Color outlineColor )
    {
        _leftTopPoint = leftTopPoint;
        _rightBottomPoint = rightBottomPoint;
        _fillColor = fillColor;
        _outlineColor = outlineColor;
    }

    public double GetArea()
    {
        return GetHeight() * GetWidth();
    }

    public double GetPerimeter()
    {
        return ( GetHeight() + GetWidth() ) * 2;
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
        StringBuilder stringBuilder = new StringBuilder( "===[RECTANGLE]===\n" );

        stringBuilder.Append( $" - Left Bottom Point: ({_leftTopPoint.X}, {_leftTopPoint.Y}) \n" );
        stringBuilder.Append( $" - Right Bottom Point: ({_rightBottomPoint.X}, {_rightBottomPoint.Y}) \n" );
        stringBuilder.Append( $" - Width: {GetWidth()} \n" );
        stringBuilder.Append( $" - Height: {GetHeight()} \n" );
        stringBuilder.Append( $" - Outline Color: #{GetOutlineColor()} \n" );
        stringBuilder.Append( $" - Fill Color: #{GetFillColor()} \n" );
        stringBuilder.Append( $" - Area: {GetArea()} \n" );
        stringBuilder.Append( $" - Perimeter: {GetPerimeter()} \n" );

        return stringBuilder.ToString();
    }

    public void Draw( Canvas.Canvas canvas )
    {
        Point rightTopPoint = new Point( _rightBottomPoint.X, _leftTopPoint.Y );
        Point leftBottomPoint = new Point( _leftTopPoint.X, _rightBottomPoint.Y );

        List<Point> points = new List<Point> { _leftTopPoint, rightTopPoint, _rightBottomPoint, leftBottomPoint };
        canvas.FillPolygon( points, GetFillColor() );
        canvas.DrawLine( _leftTopPoint, rightTopPoint, GetOutlineColor() );
        canvas.DrawLine( rightTopPoint, _rightBottomPoint, GetOutlineColor() );
        canvas.DrawLine( _rightBottomPoint, leftBottomPoint, GetOutlineColor() );
        canvas.DrawLine( leftBottomPoint, _leftTopPoint, GetOutlineColor() );
    }

    public double GetWidth()
    {
        return Math.Abs( _rightBottomPoint.X - _leftTopPoint.X );
    }

    public double GetHeight()
    {
        return Math.Abs( _leftTopPoint.Y - _rightBottomPoint.Y );
    }
}
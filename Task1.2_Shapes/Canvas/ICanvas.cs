using System.Drawing;

namespace Task1._2_Shapes.Canvas;

public interface ICanvas : IDisposable
{
    public void DrawLine(Point startPoint,Point endPoint, Color lineColor);
    public void FillPolygon(List<Point> points, Color fillColor);
    public void DrawCircle(Point centerPoint, double radius, Color lineColor);
    public void FillCircle(Point centerPoint, double radius, Color fillColor);
}
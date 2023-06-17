using System.Drawing;

namespace Task1._2_Shapes.Shapes;

public interface ISolidShape : IShape
{
    public Color GetFillColor();
}
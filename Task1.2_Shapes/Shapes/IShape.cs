using System.Drawing;

namespace Task1._2_Shapes.Shapes;

public interface IShape
{
    public double GetArea();
    public double GetPerimeter();
    public string ToString();
    public Color GetOutlineColor() ;
}
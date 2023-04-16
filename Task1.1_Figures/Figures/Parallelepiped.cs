namespace Task1._1_Figures.Figures;

public class Parallelepiped : Body
{
    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }

    public Parallelepiped( double density, double width, double height, double depth ) : base( density )
    {
        Width = width;
        Height = height;
        Depth = depth;
    }

    public override double GetVolume()
    {
        return Width * Height * Depth;
    }
}
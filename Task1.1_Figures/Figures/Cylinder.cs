namespace Task1._1_Figures.Figures;

public class Cylinder : Body
{
    public double Height { get; }
    public double BaseRadius { get; }

    public Cylinder( double density, double height, double baseRadius ) : base( density )
    {
        Height = height;
        BaseRadius = baseRadius;
    }

    public override double GetVolume()
    {
        return Math.PI * Math.Pow( BaseRadius, 2 ) * BaseRadius;
    }
}
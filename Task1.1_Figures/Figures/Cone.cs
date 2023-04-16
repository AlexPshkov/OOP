namespace Task1._1_Figures.Figures;

public class Cone : Body
{
    public double Height { get; }
    public double BaseRadius { get; }

    public Cone( double density, double height, double baseRadius ) : base( density )
    {
        Height = height;
        BaseRadius = baseRadius;
    }

    public override double GetVolume()
    {
        return 1/3 * Math.PI * Math.Pow( BaseRadius, 2 ) * Height;
    }
}
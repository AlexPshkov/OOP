namespace Task1._1_Figures.Figures;

public class Sphere : Body
{
    public double Radius { get; }

    public Sphere( double density, double radius ) : base( density )
    {
        Radius = radius;
    }

    public override double GetVolume()
    {
        return 4/3 * Math.PI * Math.Pow( Radius, 3 );
    }
}
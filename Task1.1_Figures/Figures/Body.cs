namespace Task1._1_Figures.Figures;

public abstract class Body
{
    private readonly double _density;

    protected Body( double density )
    {
        _density = density;
    }
    
    public abstract double GetVolume();

    public virtual double GetMass()
    {
        return GetDensity() * GetVolume();
    }
    
    public virtual double GetDensity()
    {
        return _density;
    }

    public override string ToString()
    {
        return string.Format( "Density: {0} Volume: {1} Mass: {2}",
            Utils.Round( GetDensity() ),
            Utils.Round( GetVolume() ),
            Utils.Round( GetMass() ) );
    }
}
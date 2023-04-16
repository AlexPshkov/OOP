using Task1._1_Figures.Figures;

namespace Task1._1_Figures;

public class Compound : Body
{
    private readonly List<Body> _parts = new List<Body>();

    public Compound() : base( 0 ) { }
    
    public Compound( List<Body> parts ) : base( 0 ) 
    {
        parts.ForEach( AddChildBody );
    }
    
    public void AddChildBody( Body child )
    {
        if ( child == this )
        {
            throw new ArgumentException( "You can't add a figure to yourself" );
        }
        
        _parts.Add( child );
    }

    public override double GetDensity()
    {
        double volume = GetVolume();
        if ( volume <= 0 )
        {
            return 0;
        }
        
        return GetMass() / volume;
    }
    
    public override double GetMass()
    {
        return _parts.Sum( x => x.GetMass() );
    }
    
    public override double GetVolume()
    {
        return _parts.Sum( x => x.GetVolume() );
    }
}
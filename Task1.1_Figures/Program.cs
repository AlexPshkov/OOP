using Task1._1_Figures.Figures;

namespace Task1._1_Figures;

public static class Program
{
    
    // Pводы = 1000 кг/м3
    // F_тяжести-F_архимеда=(ρ_тела-ρ_воды)gV
    
    public static int Main( string[] args )
    {

        Sphere sphere = new Sphere( 1000, 1 );
        Cylinder cylinder = new Cylinder( 1000, 5, 1 );

        Compound compound = new Compound();
        compound.AddChildBody( sphere );
        compound.AddChildBody( cylinder );
        
        Console.WriteLine(sphere);
        Console.WriteLine(cylinder);
        Console.WriteLine(compound);
        
        return 0;
    }
}
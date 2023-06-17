using Task1._2_Shapes.Shapes;
using Task1._2_Shapes.UI;

namespace Task1._2_Shapes;

public static class Program
{
    private static readonly List<IShape> Shapes = new List<IShape>();

    private static void Main( string[] args )
    {
        using Canvas.Canvas canvas = new Canvas.Canvas( 800, 600, "Task1.2_Shapes");
        
        CommandHandler.StartCommandHandling();
    }

    public static void AddShape( IShape shape )
    {
        Shapes.Add( shape );
    }

    public static IShape? GetShapeWithHighestArea()
    {
        return Shapes.MaxBy( x => x.GetArea() );
    }
    
    public static IShape? GetShapeWithSmallestPerimeter()
    {
        return Shapes.MinBy( x => x.GetPerimeter() );
    }
}
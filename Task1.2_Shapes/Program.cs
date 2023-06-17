using Task1._2_Shapes.Shapes;
using Task1._2_Shapes.UI;

namespace Task1._2_Shapes;

public static class Program
{
    private static readonly ShapesManager ShapesManager = new ShapesManager();
    
    private static void Main( string[] args )
    {
        CommandsManager.StartCommandHandling();
    }

    public static void AddShape( IShape shape ) => ShapesManager.AddShape( shape );
    public static void ClearShapes() => ShapesManager.ClearShapes();
    public static IShape? GetShapeWithHighestArea() => ShapesManager.GetShapeWithHighestArea();
    public static IShape? GetShapeWithSmallestPerimeter() => ShapesManager.GetShapeWithSmallestPerimeter();
}
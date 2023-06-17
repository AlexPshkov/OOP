using Task1._2_Shapes.Shapes;

namespace Task1._2_Shapes;

public class ShapesManager
{
    private readonly List<IShape> _shapes = new List<IShape>();
    
    public void AddShape( IShape shape )
    {
        _shapes.Add( shape );
    }
    
    public void ClearShapes()
    {
        _shapes.Clear();
    }
    
    public IShape? GetShapeWithHighestArea()
    {
        return _shapes.MaxBy( x => x.GetArea() );
    }
    
    public IShape? GetShapeWithSmallestPerimeter()
    {
        return _shapes.MinBy( x => x.GetPerimeter() );
    }
}
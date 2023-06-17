namespace Task1._2_Shapes;

public class Point
{
    private const double CompareTolerance = 0.01;
    
    public double X { get; private set; }
    public double Y { get; private set; }

    public Point( double x, double y )
    {
        X = x;
        Y = y;
    }

    public static double GetDistance( Point point1, Point point2 )
    {
        return Math.Sqrt( Math.Pow( point2.X - point1.X, 2 ) + Math.Pow( point2.Y - point1.Y, 2 ) );
    }

    public override bool Equals( object? obj )
    {
        if ( obj is null || obj.GetType() != typeof( Point ) )
        {
            return false;
        }

        Point anotherPoint = (Point) obj;
        
        return Math.Abs( X - anotherPoint.X ) < CompareTolerance && Math.Abs( Y - anotherPoint.Y ) < CompareTolerance;
    }
}
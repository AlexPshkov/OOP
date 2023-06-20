namespace Task1._3_FindMaxEx.Models;

public class Sportsmen
{
    public string Name { get; private set; }
    public double Weight { get; private set; }
    public double Height { get; private set; }

    public Sportsmen( string name, double weight, double height )
    {
        Name = name;
        Weight = weight;
        Height = height;
    }
}
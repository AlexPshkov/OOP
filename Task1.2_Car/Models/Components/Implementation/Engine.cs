namespace Task1._2_Car.Models.Components.Implementation;

public class Engine : IEngine
{
    public bool IsStarted { get; private set; }

    public void Start()
    {
        IsStarted = true;
    }

    public void Stop()
    {
        IsStarted = false;
    }
}
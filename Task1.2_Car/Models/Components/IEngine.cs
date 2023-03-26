namespace Task1._2_Car.Models.Components;

public interface IEngine
{
    public bool IsStarted { get; }
    void Start();
    void Stop();
}
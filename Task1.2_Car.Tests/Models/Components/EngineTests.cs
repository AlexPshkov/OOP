using Task1._2_Car.Models.Components;
using Task1._2_Car.Models.Components.Implementation;
using Xunit;

namespace Task1._2_Car.Tests.Models.Components;

public class EngineTests
{
    [Fact]
    public void Engine_Start_StartEngine_Started()
    {
        // Arrange
        IEngine engine = new Engine();

        // Act
        engine.Start();

        // Assert
        Assert.True( engine.IsStarted );
    }
    
    [Fact]
    public void Engine_Stop_StopEngineAfterStart_Stopped()
    {
        // Arrange
        IEngine engine = new Engine();

        // Act
        engine.Start();
        engine.Stop();

        // Assert
        Assert.False( engine.IsStarted );
    }
}
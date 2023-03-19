using Infrastructure;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace TelegramApi;

public class Program
{
    public static int Main( string[] args )
    {
        Container container = new Container();
        container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
        container
            .AddInfrastructure()
            .AddTelegramApiBindings();
        
        container.Verify();
        
        return 0;
    }
}
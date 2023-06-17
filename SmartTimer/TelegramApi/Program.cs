

using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace TelegramApi;

public class Program
{
    public static int Main( string[] args )
    {
        // Container container = new Container();
        //
        //
        //
        // container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
        // container
        //     .AddInfrastructure()
        //     .AddTelegramApiBindings();
        //
        // container.Verify();
        
        return 0;
    }

    public void ConfigureServices( IServiceCollection services )
    {
        Console.WriteLine( "Hello World!" );
        
        
        
        // services.AddSingleton<ISingletonPostmanService, PostmanService>();
        //
        // services.AddTransient<PostmanHandler>();

        // services.AddLogging(loggerBuilder =>
        // {
        //     loggerBuilder.ClearProviders();
        //     loggerBuilder.AddConsole();
        // });
        
    }
}
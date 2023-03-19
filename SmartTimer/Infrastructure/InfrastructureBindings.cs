using System.Configuration;
using Infrastructure.Context;
using SimpleInjector;

namespace Infrastructure;

public static class InfrastructureBindings
{
    public static Container AddInfrastructure( this Container container )
    {
        container.Register( () => new DataBaseContext( ConfigurationManager.ConnectionStrings[ "checkin" ].ConnectionString ), Lifestyle.Scoped );
        
        return container;
    }
}
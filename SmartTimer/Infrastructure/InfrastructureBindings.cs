using System.Configuration;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure;

public static class InfrastructureBindings
{
    // public static Container AddInfrastructure( this Container container )
    // {
    //
    //     
    //     container.Con
    //     
    //     string dbConnectionString = Configuration.GetSection("Swagger:Title").Value;
    //
    //     container.Register<DbContext>( () => new DataBaseContext( dbConnectionString ), Lifestyle.Scoped );
    //
    //     return container;
    // }
}
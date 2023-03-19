using System.Data.Entity;
using Domain.Models;
using Domain.UnitOfWork;
using Infrastructure.Configuration;

namespace Infrastructure.Context;

public class DataBaseContext : DbContext, IUnitOfWork
{
    public DbSet<UserEntity> UserEntities { get; set; }
    
    public DataBaseContext( string nameOrConnectionString ) : base( nameOrConnectionString ) { }
    
    public int CommitChanges() => base.SaveChanges();

    public Task<int> CommitChangesAsync() => base.SaveChangesAsync();

    protected override void OnModelCreating( DbModelBuilder modelBuilder )
    {
        modelBuilder.Configurations.Add( new UserEntityConfiguration() );
    }
}
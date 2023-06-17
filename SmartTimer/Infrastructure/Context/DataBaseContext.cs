using Domain.Models;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataBaseContext : DbContext, IUnitOfWork
{
    protected readonly string ConnectionString;
    
    public DbSet<UserEntity> UserEntities { get; set; }

    public DataBaseContext( string connectionString )
    {
        ConnectionString = connectionString;
    }

    public int CommitChanges() => base.SaveChanges();
    public Task<int> CommitChangesAsync() => base.SaveChangesAsync();
    
    protected override void OnConfiguring( DbContextOptionsBuilder options )
    {
        options.UseNpgsql( ConnectionString );
    }
}
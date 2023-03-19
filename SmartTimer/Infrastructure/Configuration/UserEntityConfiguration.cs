using System.Data.Entity.ModelConfiguration;
using Domain.Models;

namespace Infrastructure.Configuration;

public class UserEntityConfiguration : EntityTypeConfiguration<UserEntity>
{
    public UserEntityConfiguration()
    {
        ToTable("Mobiles");
        
        HasKey(p => p.UserId);
        
        Property(p => p.UserName).IsRequired().HasMaxLength(30);
    }
}
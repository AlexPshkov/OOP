using Domain.Models;
using Domain.Repositories;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task<UserEntity> GetUserAsync()
    {
        throw new NotImplementedException();
    }
}
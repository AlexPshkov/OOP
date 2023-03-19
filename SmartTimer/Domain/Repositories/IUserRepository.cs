using Domain.Models;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetUserAsync();
}
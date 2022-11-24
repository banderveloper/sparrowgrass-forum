using SparrowgrassForum.Server.Domain.Entities;

namespace SparrowgrassForum.Server.Domain.Repositories.Abstract;

public interface IUserRepository
{
    Task RegisterUser(User user);
    Task<bool> UserEmailExists(string email);
    Task<User?> GetUserByEmail(string email);
}
using SparrowgrassForum.Server.Domain.Entities;

namespace SparrowgrassForum.Server.Domain.Repositories.Abstract;

public interface IUserRepository
{
    Task<User> RegisterUser(User user);
    // User with given email exists
    Task<bool> UserEmailExists(string email);
    Task<User?> GetUserByEmail(string email);
}
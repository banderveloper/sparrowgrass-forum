using SparrowgrassForum.Server.Domain.Entities;
using SparrowgrassForum.Server.Domain.Repositories.Abstract;

namespace SparrowgrassForum.Server.Domain.Repositories.EntityFramework;

public class EfUserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public EfUserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task RegisterUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UserEmailExists(string email)
    {
        var result = await _context.Users.FindAsync(email);
        return result is not null;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _context.Users.FindAsync(email);
        return user;
    }
}
using Microsoft.EntityFrameworkCore;
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

    public async Task<User> RegisterUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> UserEmailExists(string email)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u=>u.Email == email);
        return result is not null;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email == email);
        return user;
    }
}
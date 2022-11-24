using SparrowgrassForum.Server.Domain.Entities;
using SparrowgrassForum.Server.Domain.Repositories.Abstract;

namespace SparrowgrassForum.Server.Domain.Repositories;

public class DataManager
{
    public IEatRecordRepository EatRecords { get; init; }
    public IUserRepository Users { get; init; }

    public DataManager(IEatRecordRepository eatRecords, IUserRepository users)
    {
        EatRecords = eatRecords;
        Users = users;
    }

    public async Task<User?> GetOrRegisterUser(string email, string name)
    {
        if (await Users.UserEmailExists(email))
        {
            return await Users.GetUserByEmail(email);
        }

        return await Users.RegisterUser(new User()
        {
            Name = name,
            Email = email
        });
    }
}
using Microsoft.EntityFrameworkCore;
using SparrowgrassForum.Server.Domain.Entities;
using SparrowgrassForum.Server.Domain.Repositories.Abstract;

namespace SparrowgrassForum.Server.Domain.Repositories.EntityFramework;

public class EfEatRecordRepository : IEatRecordRepository
{
    private readonly AppDbContext _context;

    public EfEatRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task IncrementOrCreateEatRecord(User user)
    {
        var record = await _context.EatRecords
            .FirstOrDefaultAsync(rec => rec.UserId == user.Id);

        if (record is not null)
        {
            record.Count++;
        }
        else
        {
            _context.EatRecords.Add(new EatRecord()
            {
                UserId = user.Id,
                Count = 1
            });
        }

        await _context.SaveChangesAsync();
    }
}
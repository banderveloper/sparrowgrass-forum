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

    // Increment sparrowgrass record COUNT field by user id
    // or insert new record 
    public async Task IncrementOrCreateEatRecord(int userId)
    {
        var record = await _context.EatRecords
            .FirstOrDefaultAsync(rec => rec.UserId == userId);

        if (record is not null)
        {
            record.Count++;
            record.LastUpdated = DateTime.Now;
        }
        else
        {
            _context.EatRecords.Add(new EatRecord()
            {
                UserId = userId,
                Count = 1,
                LastUpdated = DateTime.Now
            });
        }

        await _context.SaveChangesAsync();
    }

    // Get all records with included users
    public async Task<List<EatRecord>> GetEatRecordWithUsers()
    {
        return await _context.EatRecords.Include(er => er.User).ToListAsync();
    }
}
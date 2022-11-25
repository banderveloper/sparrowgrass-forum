using SparrowgrassForum.Server.Domain.Entities;

namespace SparrowgrassForum.Server.Domain.Repositories.Abstract;

public interface IEatRecordRepository
{
    // Increment sparrowgrass record COUNT field by user id if records exists
    // or insert new record 
    Task IncrementOrCreateEatRecord(int userId);
    
    // Get all records with included users
    Task<List<EatRecord>> GetEatRecordWithUsers();
}
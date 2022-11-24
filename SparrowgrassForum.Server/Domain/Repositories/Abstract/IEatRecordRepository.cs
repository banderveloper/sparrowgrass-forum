using SparrowgrassForum.Server.Domain.Entities;

namespace SparrowgrassForum.Server.Domain.Repositories.Abstract;

public interface IEatRecordRepository
{
    // Increment sparrowgrass record COUNT field by user id
    Task IncrementOrCreateEatRecord(int userId);
}
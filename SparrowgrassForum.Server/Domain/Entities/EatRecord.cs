using System.Text.Json.Serialization;

namespace SparrowgrassForum.Server.Domain.Entities;

public class EatRecord
{
    public int UserId { get; set; }
    public int Count { get; set; }
    
    [JsonIgnore]
    public User? User { get; set; }
}
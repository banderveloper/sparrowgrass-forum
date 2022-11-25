namespace SparrowgrassForum.Server.Models;

public class RecordGetModel
{
    public string Name { get; set; } = string.Empty;
    public int Count { get; set; }
    public DateTime LastUpdated { get; set; }
}
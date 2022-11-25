namespace SparrowgrassForum.Server.Models;

// Return record model, usually return as list of models
public class RecordGetModel
{
    public string Name { get; set; } = string.Empty;
    public int Count { get; set; }
    public DateTime LastUpdated { get; set; }
}
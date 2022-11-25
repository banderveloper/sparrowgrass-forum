using System.ComponentModel.DataAnnotations;

namespace SparrowgrassForum.Server.Models;

// Form post data for adding new / updating record
public class AddFormPostModel
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Minimal name length is 3")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; } = string.Empty;
}
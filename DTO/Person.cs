using System.ComponentModel.DataAnnotations;

namespace Labb_3_API.DTO;

public record Person
{
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; } = string.Empty;
    [Phone]
    public string? PhoneNumber { get; set; } = string.Empty;

    // Navigation property
    public ICollection<Intrest> Intrests { get; set; } = [];
}



using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Models;

public class Person
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
    public ICollection<PersonService> PersonServices { get; set; } = [];
}



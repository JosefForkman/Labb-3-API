using System;
using System.ComponentModel.DataAnnotations;

namespace Labb_3_API.Models;

public class Service
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;


    // Navigation property
    public ICollection<PersonService> PersonServices { get; set; } = [];
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Labb_3_API.Models;

public class Intrest
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;


    // Navigation property
    public ICollection<PersonIntrest> PersonIntrests { get; set; } = [];
}

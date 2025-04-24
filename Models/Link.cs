using System;
using System.ComponentModel.DataAnnotations;

namespace Labb_3_API.Models;

public class Link
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [Url]
    public string? Url { get; set; }
    public int PersonIntrestId { get; set; }

    // Navigation property
    public PersonIntrest PersonIntrests { get; set; } = null!;
}

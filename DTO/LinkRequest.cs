using System;
using System.ComponentModel.DataAnnotations;

namespace Labb_3_API.DTO;

public record LinkRequest
{
    public int PersonId { get; set; }
    public int IntrestId { get; set; }
    public string Title { get; set; } = string.Empty;
    [Url]
    public string? Url { get; set; }
}

using System;

namespace Labb_3_API.DTO;

public record IntrestRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

namespace Labb_3_API.DTO;

public record LinkRespondDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
}

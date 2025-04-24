using System;

namespace Labb_3_API.Models;

public class PersonIntrest
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int IntrestId { get; set; }

    // Navigation property for the link
    public Person Person { get; set; } = null!;
    public Intrest Intrest { get; set; } = null!;
    public ICollection<Link> Links { get; set; } = null!;
}

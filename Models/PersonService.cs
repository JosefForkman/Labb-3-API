using System;

namespace Labb_3_API.Models;

public class PersonService
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int ServiceId { get; set; }

    // Navigation property for the link
    public Person Person { get; set; } = null!;
    public Service Service { get; set; } = null!;
    public ICollection<Link> Links { get; set; } = null!;
}

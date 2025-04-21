using System;

namespace Labb_3_API.Models;

public class PersonService
{
    public int PersonId { get; set; }
    public int ServiceId { get; set; }

    public virtual Person Person { get; set; } = null!;
    public virtual Service Service { get; set; } = null!;
}

using System;
using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Data;

public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Intrest> Intrests { get; set; }
    public DbSet<PersonIntrest> PersonIntrests { get; set; }
    public DbSet<Link> Links { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>()
            .HasIndex(p => p.Email)
            .IsUnique();

        modelBuilder.Entity<Intrest>()
            .HasIndex(s => s.Title)
            .IsUnique();

        modelBuilder.Entity<Person>().HasData(
            new Person
            {
                Id = 1,
                FirstName = "Anna",
                LastName = "Svensson",
                BirthDate = new DateTime(1990, 5, 15),
                Email = "anna.svensson@example.com",
                PhoneNumber = "070-1234567"
            },
            new Person
            {
                Id = 2,
                FirstName = "Erik",
                LastName = "Karlsson",
                BirthDate = new DateTime(1985, 11, 20),
                Email = "erik.karlsson@example.com",
                PhoneNumber = "073-9876543"
            },
            new Person
            {
                Id = 3,
                FirstName = "Lisa",
                LastName = "Andersson",
                BirthDate = new DateTime(1998, 3, 10),
                Email = "lisa.andersson@example.com"
            }
        );

        modelBuilder.Entity<Intrest>().HasData(
            new Intrest { Id = 1, Title = "Musik", Description = "Intresserad av olika musikgenrer och artister." },
            new Intrest { Id = 2, Title = "Sport", Description = "Följer och utövar olika sporter." },
            new Intrest { Id = 3, Title = "Teknologi", Description = "Fascinerad av den senaste tekniska utvecklingen." },
            new Intrest { Id = 4, Title = "Resor", Description = "Älskar att upptäcka nya platser och kulturer." }
        );

        modelBuilder.Entity<PersonIntrest>().HasData(
            new PersonIntrest { Id = 1, PersonId = 1, IntrestId = 1 },
            new PersonIntrest { Id = 2, PersonId = 1, IntrestId = 2 },
            new PersonIntrest { Id = 3, PersonId = 2, IntrestId = 2 },
            new PersonIntrest { Id = 4, PersonId = 3, IntrestId = 3 }
        );

        modelBuilder.Entity<Link>().HasData(
            new Link { Id = 1, Title = "Länk 1", Url = "https://example.com/link1", PersonIntrestId = 1 },
            new Link { Id = 2, Title = "Länk 2", Url = "https://example.com/link2", PersonIntrestId = 2 },
            new Link { Id = 3, Title = "Länk 3", Url = "https://example.com/link3", PersonIntrestId = 3 },
            new Link { Id = 4, Title = "Länk 4", Url = "https://example.com/link4", PersonIntrestId = 4 }
        );
    }
}

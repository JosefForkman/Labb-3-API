using System;
using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Data;

public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<PersonService> PersonServices { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>()
            .HasIndex(p => p.Email)
            .IsUnique();

        modelBuilder.Entity<Service>()
            .HasIndex(s => s.Title)
            .IsUnique();

        modelBuilder.Entity<PersonService>()
            .HasKey(ps => new { ps.PersonId, ps.ServiceId });
    }
}

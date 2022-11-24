using Microsoft.EntityFrameworkCore;
using SparrowgrassForum.Server.Domain.Entities;

namespace SparrowgrassForum.Server.Domain;

public sealed class AppDbContext : DbContext
{
    public DbSet<EatRecord> EatRecords { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex("Email")
            .IsUnique();
    }
}
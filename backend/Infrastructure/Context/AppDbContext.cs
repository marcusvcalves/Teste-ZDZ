using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; init; }
    public DbSet<Category> Categories { get; init;}
    public string DbPath { get; }

    public AppDbContext()
    {
        DbPath = Path.Combine(Directory.GetCurrentDirectory(), "../Infrastructure/app.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity<CategoryProduct>();
        
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothings" },
            new Category { Id = 3, Name = "Books" }
        );
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
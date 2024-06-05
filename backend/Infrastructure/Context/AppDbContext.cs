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
            .UsingEntity<CategoryProduct>(
                j => j.HasData(
                    new CategoryProduct { ProductId = 1, CategoryId = 1 },
                    new CategoryProduct { ProductId = 2, CategoryId = 1 },
                    new CategoryProduct { ProductId = 3, CategoryId = 2 },
                    new CategoryProduct { ProductId = 4, CategoryId = 2 },
                    new CategoryProduct { ProductId = 5, CategoryId = 3 },
                    new CategoryProduct { ProductId = 6, CategoryId = 3 },
                    new CategoryProduct { ProductId = 7, CategoryId = 1 },
                    new CategoryProduct { ProductId = 8, CategoryId = 1 },
                    new CategoryProduct { ProductId = 9, CategoryId = 2 },
                    new CategoryProduct { ProductId = 10, CategoryId = 3 }
                )
            );
        
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Eletrônicos" },
            new Category { Id = 2, Name = "Roupas" },
            new Category { Id = 3, Name = "Livros" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Smartphone", Price = 1500, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 2, Name = "Laptop", Price = 2500, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 3, Name = "Camiseta", Price = 10, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 4, Name = "Calça Jeans", Price = 100, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 5, Name = "Livro de Romance", Price = 30, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 6, Name = "Livro de Drama", Price = 200, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 7, Name = "Fones de ouvido", Price = 300, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 8, Name = "Smartwatch", Price = 800, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 9, Name = "Jaqueta", Price = 150, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." },
            new Product { Id = 10, Name = "Livro de Biografia", Price = 40, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis." }
        );
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
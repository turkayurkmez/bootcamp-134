using Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccess.Data
{
    public class CatalogDbContext : DbContext
    {
        //Entity Framework'un veritabanına bağlanan ve işlemleri yöneten en önemli sınıfı...
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(100);


            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Telefon" },
                new Category() { Id = 2, Name = "Bilgisayar" },
                new Category() { Id = 3, Name = "Tablet" },
                new Category() { Id = 4, Name = "Kamera" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Samsung S10", Price = 1000, ImageUrl = "1.jpg", Description = "Samsung S10", CategoryId = 1 },
                new Product() { Id = 2, Name = "Dell XPS 13", Price = 10000, ImageUrl = "2.jpg", Description = "Dell....", CategoryId = 2 },
                new Product() { Id = 3, Name = "Lenovo Tab 4", Price = 2000, ImageUrl = "3.jpg", Description = "Lenovo Tab 4", CategoryId = 3 },
                new Product() { Id = 4, Name = "Canon EOS 5D", Price = 3000, ImageUrl = "4.jpg", Description = "Canon EOS 5D", CategoryId = 4 }
                );


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string'in burada olması açık bir risktir. Hem güvensiz hem de maaliyetli...
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");
        }



    }
}

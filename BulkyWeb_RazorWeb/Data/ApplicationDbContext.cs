using BulkyWeb_RazorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_RazorWeb.Data
{
    public class ApplicationDbContext : DbContext // DbContext is a class in EntityFrameworkCore
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
         public DbSet<Category> categories { get; set; } // Categories is table name in DATA BASEthat we have created
                                                         //  Category is CLASS name in Visual studio
        protected override void OnModelCreating(ModelBuilder modelBuilder) // This method is used to change the default behavior of EntityFrameworkCore 
        {
            modelBuilder.Entity<Category>().HasData(
              new Category { ID = 1, Name1 = "Action", DisplayOrder = 1 },
              new Category { ID = 2, Name1 = "Sc-fi", DisplayOrder = 2 },
              new Category { ID = 3, Name1 = "History", DisplayOrder = 3 },
              new Category { ID = 4, Name1 = "Horrer", DisplayOrder = 4 }

              ); // This is used to insert data in table
        }
    }
}

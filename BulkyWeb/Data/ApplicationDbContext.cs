using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext // DbContext is a class in EntityFrameworkCore
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // Constructor
        {

        }
        public DbSet<Category> Categories { get; set; } // Categories is table name in DATA BASEthat we have created
                                                        //  Category is CLASS name in Visual studio

    }   
 
}

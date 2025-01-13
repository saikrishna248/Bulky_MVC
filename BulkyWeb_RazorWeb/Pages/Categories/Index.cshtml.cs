using BulkyWeb_RazorWeb.Data;
using BulkyWeb_RazorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_RazorWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; //  This is used to access the database

        public List<Category> CategoriesList { get; set; } // This is used to get the data from the database
        public IndexModel(ApplicationDbContext db)  // Constructor
        {
            _db = db; 
        }
        public void OnGet()
        {
            CategoriesList = _db.categories.ToList(); // This is used to get the data from the database

        }
    }
}

using BulkyWeb_RazorWeb.Data;
using BulkyWeb_RazorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_RazorWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db; //  This is used to access the database
        [BindProperty] // On post to bind [if not binded] object reference error will occur
        public Category Categories { get; set; } // This is used to get the data from the database single record
        public CreateModel(ApplicationDbContext db)  // Constructor
        {
            _db = db;
        }
        public void OnGet()
        {
           // CategoriesList = _db.categories.ToList(); // This is used to get the data from the database
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.categories.Add(Categories); //  This is used to add the data in the table
                _db.SaveChanges(); // This is used to save the data in the database
                TempData["Success"] = "Created Successfully";
                return RedirectToPage("Index"); // This is used to redirect to the Index page and controller is CategoryController
            }
            return Page();
        }
    }
}

using BulkyWeb_RazorWeb.Data;
using BulkyWeb_RazorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_RazorWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db; //  This is used to access the database


        public Category? Categories { get; set; } // This is used to get the data from the database single record
        public DeleteModel(ApplicationDbContext db)  // Constructor
        {
            _db = db;
        }
        public void OnGet(int? ID)
        {
            if (ID != null && ID != 0)
            {
                Categories = _db.categories.Find(ID); // This is used to get the record from the table
            }
        }
        public IActionResult OnPost(int? ID)
        {
            Category? obj = _db.categories.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }
           
                _db.categories.Remove(obj); //  This is used to add the data in the table
                _db.SaveChanges(); // This is used to save the data in the database
                TempData["Success"] = "Data Deleted Successfully";
                return RedirectToPage("Index"); // This is used to redirect to the Index page and controller is CategoryController
            
           
        }
    }
}


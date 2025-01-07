using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context; //  This is used to access the database
        public CategoryController(ApplicationDbContext Db) // Constructor
        {
            _context = Db;
        }
        public IActionResult Index()    // This is used to display the data
        {
            List<Category> objCategoryList = _context.Categories.ToList();
            return View(objCategoryList);
           
        }
        public IActionResult Create()       // This is used to create the data
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Category obj)
        {
            //if(obj.Name1 == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name1", "Category Name and Display Order should not be same"); // This is used to show the error message
            //}
            //if(obj.Name1 != null && obj.Name1.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Test is invalid value"); //   This is used to show the error message and its not related to any field

            //}
            if (ModelState.IsValid)
            { 
            _context.Categories.Add(obj);        //  This is used to add the data in the table
            _context.SaveChanges();              // This is used to save the data in the database
            return  RedirectToAction("Index"); // This is used to redirect to the Index page and controller is CategoryController
            }
            return View();
        }
    }
}

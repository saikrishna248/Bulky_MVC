using Bulky.DataAccess.Data;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.EntityFrameworkCore;

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
            TempData["Success"] = "Data has been Created successfully"; // This is used to show the message after updating the data
            return RedirectToAction("Index"); // This is used to redirect to the Index page and controller is CategoryController
            }
            return View();
        }
        public IActionResult Edit(int? ID)       // This is used to create the data
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            Category? obj = _context.Categories.Find(ID);      // This is used to get the record from the table
          //  Category? obj1 = _context.Categories.FirstOrDefault(u=>u.ID ==ID);       // This is used to get the first record from the table
        //    Category? obj2 = _context.Categories.Where(u=>u.ID==ID).FirstOrDefault();// This is used to get the first record from the table
            if (obj == null) 
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);        //  This is used to update the data in the table
                _context.SaveChanges();              // This is used to save the data in the database
                TempData["Success"] = "Data has been updated successfully"; // This is used to show the message after updating the data
                return RedirectToAction("Index"); // This is used to redirect to the Index page and controller is CategoryController
            }
            return View();
        }

        public IActionResult Delete(int? ID)       // This is used to create the data
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            Category? obj = _context.Categories.Find(ID);      // This is used to get the record from the table
                                                               //  Category? obj1 = _context.Categories.FirstOrDefault(u=>u.ID ==ID);       // This is used to get the first record from the table
                                                               //    Category? obj2 = _context.Categories.Where(u=>u.ID==ID).FirstOrDefault();// This is used to get the first record from the table
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost , ActionName("Delete")]
        public IActionResult DeleteHere(int? ID)
        {
           
            Category? obj = _context.Categories.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);        //  This is used to delete the data in the table
            _context.SaveChanges();              // This is used to save the data in the database
            TempData["Success"] = "Data has been deleted successfully";
            return RedirectToAction("Index"); // This is used to redirect to the Index page and controller is CategoryController

          }
    }
}

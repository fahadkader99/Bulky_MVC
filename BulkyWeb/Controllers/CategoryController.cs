using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    // This class is used to retrieve data from DB table using Entity framework core.

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()        // Action method
        {
            // We are reading the DB & getting the categories as a list & saving it on a List
            List<Category> objCategoryList = _db.Categories.ToList();

            // whatever we pass in the controller return() > it will be displayed in UI
            return View(objCategoryList);   // passing the list obj to the view. Now capture list of models in the View > Index.html to display                       
        }

        public IActionResult Create()
        {
            // action method to invoke the new view - for Add new Category page
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
            {
            if (obj.Name == obj.DisplayOrder.ToString())                                                    // server side validation
            {
                ModelState.AddModelError("name", "Display Order can't exactly match the Name.");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")                                           // server side validation
            {
                ModelState.AddModelError("name", "Test is an invalid value");
            }

            // action method to invoke HTTPPost - for Add new Category page. Obj object will have to value to create category
            if (ModelState.IsValid)                                 // It will go to Category & check all the data annotaion validation 
            {
                _db.Categories.Add(obj);                            // Adding category obj on category table (keeping track of what has to add)
                _db.SaveChanges();                                  // to keep track of every changes & dding the category
                return RedirectToAction("Index", "Category");
            }

            return View();

            
        }




    }
}

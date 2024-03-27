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

        // Get method
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
                _db.Categories.Add(obj);                            // Adding category obj on category table (keeping track of what has to add) using entity framework core
                _db.SaveChanges();                                  // to keep track of every changes & dding the category into db table to save changes using entity core
                return RedirectToAction("Index", "Category");
            }

            return View();


        }

        // Get method
        public IActionResult Edit(int? id)                                                      // id will retrieve the category id from db
        {
            // action method to invoke the new view - for Edit new Category page
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // to get the category id from db (there are few ways, given below:)
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())                                                    // server side validation
            {
                ModelState.AddModelError("name", "Display Order can't exactly match the Name.");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")                                           // server side validation
            {
                ModelState.AddModelError("name", "Test is an invalid value");
            }

            // action method to invoke HTTPPost - for Edit new Category page. Obj object will have to value to create category
            if (ModelState.IsValid)                                 // It will go to Category & check all the data annotaion validation 
            {
                _db.Categories.Update(obj);                          // Updating category obj on category table (updating record on db using entity fram core)
                _db.SaveChanges();                                  // to keep track of every changes & dding the category
                return RedirectToAction("Index", "Category");
            }

            return View();


        }

        // Get method
        public IActionResult Delete(int? id)                                                      // id will retrieve the category id from db
        {
            // action method to invoke the new view - for Edit new Category page
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // to get the category id from db (there are few ways, given below:)
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }




    }
}

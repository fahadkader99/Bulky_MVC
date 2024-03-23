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




    }
}

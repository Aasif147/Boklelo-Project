using BookLelo.DartaAccess.Data;
using BookLelo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BookLelo.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            IEnumerable<Category> CategoryList = _context.Categories.ToList();
            return View(CategoryList);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Error", "Name and Display order cannot be same");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["success"] = "Category Added successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            if (Id == null && Id == 0)
                return NotFound();
            var Data = _context.Categories.Find(Id);
            if (Data != null)
                return View(Data);
            else
                return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Error", "Name and Display order cannot be same");
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFormDb = _context.Categories.Find(id);

            if (categoryFormDb == null)
            {
                return NotFound();
            }
            return View(categoryFormDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

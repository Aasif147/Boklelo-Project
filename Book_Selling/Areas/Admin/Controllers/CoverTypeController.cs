using BookLelo.DartaAccess.Data;
using BookLelo.DartaAccess.Services.Repository;
using BookLelo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Drawing;

namespace BookLelo.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly CoverTypeRepository _repo;

        public CoverTypeController(CoverTypeRepository repo)
        {
            _repo= repo;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            var data =_repo.GetAllProduct();
            return View(data);
            //IEnumerable<CoverType> CoverTypeList = _context.CoverType.ToList();
            //return View(CoverTypeList);


        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CoverType coverType)
        {
            _repo.Create(coverType);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var data= _repo.GetCoverType(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(CoverType coverType)
        {
            _repo.Edit(coverType);
            return RedirectToAction("Index");
          /*  if (Id == null && Id == 0)
                return NotFound();
            var Data = _repo.GetCoverType(ID);
             
            if (Data != null)
                return View(Data);
            else
                return View();*/

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CoverTypeFormDb = _repo.GetCoverType(id);

            if (CoverTypeFormDb == null)
            {
                return NotFound();
            }
            return View(CoverTypeFormDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(CoverType demovar)
        {
             _repo.Delete(demovar);
            TempData["success"] = "CoverType deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

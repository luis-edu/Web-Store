using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOwnStore.Repositories.Contracts;

namespace MyOwnStore.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class ProductController : Controller
    {
        private IProductRepository _pRepo;
        private ICategoryRepository _cat;
        public ProductController(IProductRepository pRepo, ICategoryRepository cat)
        {
            _pRepo = pRepo;
            _cat = cat;
        }
        public IActionResult Index(int? page, string search)
        {

            return View(_pRepo.GetAll(page, search));
        }
        public IActionResult Register()
        {
            ViewBag.Category = _cat.GetAll().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View();
        }
        [HttpPost]
        public IActionResult Register([FromForm] MyOwnStore.Models.Product product)
        {
            ViewBag.Category = _cat.GetAll().Select(a => new SelectListItem(a.Name, a.Id.ToString()));

            if (ModelState.IsValid)
            {
                _pRepo.Register(product);
                TempData["MSG_S"] = "asdas";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult Update(int id)
        {
            ViewBag.Category = _cat.GetAll().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View("Register", _pRepo.GetById(id));
        }
        [HttpPost]
        public IActionResult Update([FromForm] Models.Product product)
        {
            ViewBag.Category = _cat.GetAll().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            if (ModelState.IsValid)
            {
                _pRepo.Update(product);
                TempData["MSG_S"] = "1";
                return RedirectToAction("Index");
            }
            return View("Register", product);  
        }
    }
}
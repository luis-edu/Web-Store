using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOwnStore.Libraries.Filters;
using MyOwnStore.Libraries.Login;
using MyOwnStore.Models;
using MyOwnStore.Repositories.Contracts;

namespace MyOwnStore.Areas.Collaborator.Controllers
{   
    [Area("Collaborator")]
    // [CollaboratorAuthorization]
    public class CategoryController : Controller
    {
        private ICategoryRepository _cat;
        public CategoryController(ICategoryRepository cat)
        {
            _cat = cat;
        }
        public IActionResult Index(int? page, string search)
        {
            return View(_cat.GetAll(page, search));
        }
        [HttpPost]
        public IActionResult Register([FromForm]Models.Category category)
        {
            ViewBag.Category = _cat.GetAll().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            _cat.Register(category);
            return RedirectToAction("Index", "Category");
        }
        public IActionResult Register()
        {
            ViewBag.Category = _cat.GetAll().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View();
        }
        [HttpPost]
        public IActionResult Update([FromForm]Models.Category category, int id)
        {
            _cat.Update(category);
            ViewBag.Category = _cat.GetAll().Where(a => a.Id != id).Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            ViewBag.Category = _cat.GetAll().Where(a => a.Id != id).Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View("Register",_cat.GetById(id));
        }
        public IActionResult Delete(int id)
        {
            _cat.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
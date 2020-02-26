using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyOwnStore.Libraries.Filters;
using MyOwnStore.Libraries.Login;
using MyOwnStore.Repositories.Contracts;

namespace MyOwnStore.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class HomeController : Controller
    {
        private ICollaboratorRepository _cRepo;
        private LoginCollaborator _lCollaborator;
        public HomeController(ICollaboratorRepository cRepo, LoginCollaborator lCollaborator)
        {
            _cRepo = cRepo;
            _lCollaborator = lCollaborator;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Models.Collaborator collaborator)
        {
            Models.Collaborator temp = _cRepo.Login(collaborator.Email, collaborator.Password);
            if (temp != null)
            {
                _lCollaborator.LogIn(temp);

                return new RedirectResult(Url.Action(nameof(Panel)));
            }
            else
            {
                TempData["l_err"] = "1";
                return RedirectToAction(nameof(Login));
            }
        }

        //[CollaboratorAuthorization]
        public IActionResult Logout()
        {
            _lCollaborator.LogOut();
            return RedirectToAction("Login", "Home");
        }

        //[CollaboratorAuthorization]
        public IActionResult Panel()
        {
            return View();
        }   
    }
}
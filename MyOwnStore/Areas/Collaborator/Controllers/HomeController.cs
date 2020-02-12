using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyOwnStore.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] Models.Collaborator collaborator)
        {
            return View();
        }
        public IActionResult RecoveryPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecoveryPassword([FromForm] Models.Collaborator collaborator)
        {
            return View();
        }
        public IActionResult RegisterNewPassword([FromForm] Models.Collaborator collaborator)
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterNewPassword()
        {
            return View();
        }
    }
}
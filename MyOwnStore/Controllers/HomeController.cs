using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyOwnStore.Models;
using MyOwnStore.Repositories.Contracts;
using MyOwnStore.Libraries.Mail;
using Microsoft.AspNetCore.Http;
using MyOwnStore.Libraries.Login;
using MyOwnStore.Libraries.Filters;

namespace MyOwnStore.Controllers
{
    public class HomeController : Controller
    {
        private IClientRepository _cRepo;
        private INewsletterRepository _nRepo;
        private LoginClient _lClient;
        private MailSender _mSender;
        public HomeController(IClientRepository cRepo, INewsletterRepository nRepo, LoginClient lClient, MailSender mSender)
        {
            _cRepo = cRepo;
            _nRepo = nRepo;
            _lClient = lClient;
            _mSender = mSender;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] NewsletterMail newsletter)
        {
            if (ModelState.IsValid)
            {
                _nRepo.Register(newsletter);
                
                TempData["NEWS_E"] = "E";

                _mSender.SendNewsletter(newsletter);

                return (RedirectToAction(nameof(Index)));
            }
            else
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] Client data)
        {
            Client temp = _cRepo.Login(data.Email, data.Password);
            if (temp != null)
            {
                _lClient.LogIn(temp);

                return new RedirectResult(Url.Action(nameof(Panel)));
            }
            else
            {
                return new ContentResult() { Content = "Falha no login" };
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register([FromForm] Client data)
        {
            if (ModelState.IsValid)
            {
                _cRepo.Register(data);
                return (RedirectToAction(nameof(Register)));
            }
            else
            {
                return View();
            }
        }
        [ClientAuthorization]
        public IActionResult Panel()
        {
            Client obj = _lClient.GetClient();
            if (obj != null)
            {
                return new ContentResult()
                { Content = "Acesso Permitido!" + obj.Id +" Email "+obj.Email+" Nome: "+ obj.Name };
            }
            else
            {
                return new ContentResult()
                { Content = "Acesso Negado!" };
            }
        }
    }
}

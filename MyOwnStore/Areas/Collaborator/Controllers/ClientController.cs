using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyOwnStore.Libraries.Const;
using MyOwnStore.Libraries.Filters;
using MyOwnStore.Repositories.Contracts;

namespace MyOwnStore.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    //[CollaboratorAuthorization]
    public class ClientController : Controller
    {
        public IClientRepository _cRepo;
        public ClientController(IClientRepository cRepo)
        {
            _cRepo = cRepo;
        }
        public IActionResult Index(int? page, string search)
        {
            
            return View(_cRepo.GetAll(page, search));
        }
        [ValidateHttpReferer]
        public IActionResult ChangeStatus(int id)
        {
            var client =_cRepo.GetClientById(id);

            client.Status = (client.Status == ConstTypes.AllowedStatus) ? client.Status = ConstTypes.DenyStatus:client.Status = ConstTypes.AllowedStatus;

            _cRepo.Update(client);

            TempData["MSG_S"] = "1";

            return RedirectToAction("Index");
        }
    }
}
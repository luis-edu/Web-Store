using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyOwnStore.Libraries.Const;
using MyOwnStore.Libraries.Filters;
using MyOwnStore.Libraries.Login;
using MyOwnStore.Libraries.Mail;
using MyOwnStore.Libraries.Text;
using MyOwnStore.Repositories.Contracts;

namespace MyOwnStore.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    //[CollaboratorAuthorization]
    //[CollaboratorAcessLevel]
    public class CollaboratorController : Controller
    {
        private ICollaboratorRepository _cRepo;
        private MailSender _mSender;
        public CollaboratorController(ICollaboratorRepository cRepo, MailSender mSender)
        {
            _cRepo = cRepo;
            _mSender = mSender;
        }
        public IActionResult Index(int? page, string search)
        {
            return View(_cRepo.GetAllCollaborator(page, search));
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register([FromForm] MyOwnStore.Models.Collaborator collaborator)
        {
            /*
             * Gera uma senha automaticamente
             * Define a senha no banco de dados
             * Envia a senha por email
             */
            ModelState.Remove("Password");
            if (ModelState.IsValid)/* Verifica se o modelo é válido*/
            {
                try/*Tenta executar este bloco de código*/
                {
                    collaborator.Password = KeyGenerator.GetUniqueKey(8);/*Chama o método GetUniqueKey com tamanho de 8 caracteres para gerar uma senha automaticamente*/
                    collaborator.Type = ConstTypes.Normal;/*Define o tipo do colaborador para Normal, Onde ele tera acesso limitado no dashboard*/

                    _cRepo.Register(collaborator);/*Registra o colaborador no banco de dados*/

                    _mSender.SendPassword(collaborator.Email, collaborator.Password);/*Envia o Email com a senha do Colaborador*/

                    TempData["MSG_S"] = "1";/*Define a mensagem de sucesso para ser apresentada na pagina Index dos colaboradores*/
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    TempData["MSG_E"] = "1";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            return View("Register",_cRepo.GetCollaboratorById(id));
        }
        [HttpPost]
        public IActionResult Update([FromForm] MyOwnStore.Models.Collaborator collaborator)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                _cRepo.Update(collaborator);
                TempData["MSG_A"] = "1";
                return RedirectToAction("Index");
            }
            return View("Register", collaborator);
        }
         
        [ValidateHttpReferer]
        public IActionResult GeneratePassword(int id)
        {
            var collaborator = _cRepo.GetCollaboratorById(id);//Busca o colaborador
            collaborator.Password = KeyGenerator.GetUniqueKey(8);//Gera a nova senha de 8 Digitos   
            _cRepo.UpdatePassword(collaborator);//Atualiza o colaborador
            _mSender.SendPassword(collaborator.Email, collaborator.Password);//Envia a senha por email
            TempData["MSG_P"] = "1";/*Define a mensagem de sucesso para ser apresentada na pagina Index dos colaboradores*/
            return RedirectToAction("Index");
        }

        [ValidateHttpReferer]//Filtro para verificar a origem da ação
        public IActionResult Delete(int id)
        {
            _cRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
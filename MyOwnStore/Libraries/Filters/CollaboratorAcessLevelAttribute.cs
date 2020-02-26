using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyOwnStore.Libraries.Const;
using MyOwnStore.Libraries.Login;
using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Filters
{
    public class CollaboratorAcessLevelAttribute : Attribute, IAuthorizationFilter
    {
        private LoginCollaborator _lCollaborator;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _lCollaborator = (LoginCollaborator)context.HttpContext.RequestServices.GetService(typeof(LoginCollaborator));
            Models.Collaborator temp = _lCollaborator.GetClient();
            if (temp.Type == ConstTypes.Normal)
            {
                context.Result = new RedirectToActionResult("Panel", "Home", null);
            }
        }
    }
}

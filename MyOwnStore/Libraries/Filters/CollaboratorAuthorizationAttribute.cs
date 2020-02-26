using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyOwnStore.Libraries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Filters
{
    public class CollaboratorAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private LoginCollaborator _lCollaborator;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _lCollaborator = (LoginCollaborator)context.HttpContext.RequestServices.GetService(typeof(LoginCollaborator));
            Models.Collaborator temp = _lCollaborator.GetClient();
            if (temp == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}

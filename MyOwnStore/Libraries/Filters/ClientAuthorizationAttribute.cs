using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyOwnStore.Libraries.Login;
using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Filters
{
    public class ClientAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private LoginClient _lClient;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _lClient = (LoginClient)context.HttpContext.RequestServices.GetService(typeof(LoginClient));
            Client temp = _lClient.GetClient();
            if(temp == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado!"};
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Filters
{
    public class ValidateHttpReferer : Attribute, IActionFilter
    {
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Ação executada antes de passar pelo controlador
            string referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(referer))
            {
                context.Result = new ContentResult() { Content = "Você não pode fazer isso..." };
            }
            else
            {
                Uri uri = new Uri(referer);
                string hostReferer = uri.Host;
                string hostServer = context.HttpContext.Request.Host.Host;
                if(hostReferer != hostServer)
                {
                    context.Result = new ContentResult() { Content = "Qual é cara! Eu disse que você não pode" };
                }
            }
            
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Ação executada após passar pelo controlador
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class ActionLoginFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.Any(item => item is CustomAllownonymousAttribute))
                return;

            string id = context.HttpContext.Session.GetString("Id");

            if (id == null || id == Guid.Empty.ToString())
            {
                context.HttpContext.Response.Redirect("/Account/login");
            }
        }
    }
}

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

            string Id = context.HttpContext.Session.GetString("Id");

            if (Id == null || Id == Guid.Empty.ToString())
            {
                context.HttpContext.Response.Redirect("/AccountControllers/login");
            }
        }
    }
}

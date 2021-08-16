using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Utility
{
    public class ActionLoginFilterAttribute : ActionFilterAttribute
    {
        private readonly bool _isCheck=true;

        public  ActionLoginFilterAttribute(bool isCheck)
        {
            this._isCheck = isCheck;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string Id = context.HttpContext.Session.GetString("Id");
            if (_isCheck)
            {
                if (Id == null || Id == Guid.Empty.ToString())
                    context.HttpContext.Response.Redirect("/AccountControllers/login");
            }





        }
    }
}

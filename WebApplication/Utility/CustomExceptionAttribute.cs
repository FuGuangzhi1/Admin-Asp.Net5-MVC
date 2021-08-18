using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Utility
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionAttribute> _logger;

        public CustomExceptionAttribute(ILogger<CustomExceptionAttribute> logger)
        {
            this._logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var error = context.Exception.Message;
                _logger.LogError(message: error);
                context.Result = new JsonResult(new
                {
                    res = false,
                    msg = string.Format("错误：{0}", context.Exception.Message)
                }
                );
            }
        }
    }
}

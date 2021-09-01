using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
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
                context.Result = new JsonResult(new AjaxResult
                {
                    Success = false,
                    Message = string.Format("错误：{0} 请联系管理员，错误时间：{1}", context.Exception.Message,DateTime.Now)
                }
                );
            }
        }
    }
}

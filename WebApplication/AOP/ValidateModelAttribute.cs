using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace WebApplication.AOP
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> sb = new ();
                // 获取所有错误的Key
                List<string> Keys = context.ModelState.Keys.ToList();
                // 获取每一个key对应的ModelStateDictionary
                foreach (var key in Keys)
                {
                    var errors = context.ModelState[key].Errors.ToList();
                    // 将错误描述添加到sb中
                    foreach (var error in errors)
                    {
                        sb.Add(error.ErrorMessage);
                    }
                }
                var errorResult = string.Join(' ',sb.ToArray());
                if(sb.Count>0) 
                context.Result = new JsonResult(new AjaxResult
                {
                    Success = false,
                    Message = string.Format("错误：{0}", errorResult)
                });
            }
        }

    }
}

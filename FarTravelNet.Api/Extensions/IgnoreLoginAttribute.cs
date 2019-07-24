using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarTravelNet.Api
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/6/15 21:16:23
    /// 版 本：1.0
    /// 描 述：忽略登入校验
    /// </summary>
    public class IgnoreLoginAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}

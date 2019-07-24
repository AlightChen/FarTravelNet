using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FarTravelNet.Api
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/6/15 21:16:23
    /// 版 本：1.0
    /// 描 述：用户登录验证
    /// </summary>
    public class UserAuthorizeAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var loginUser = ServiceLocator.Resolve<IApiTokenService>().GetUserPayloadByToken();
            if (loginUser == null)
            {
                context.Result = new JsonResult(new ApiResult { Success = false, ErrorCode = 1000, Msg = "登录失效，请重新登录" });
                return;
            }
        }
    }
}

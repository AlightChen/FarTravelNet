using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarTravelNet.Api.Controllers
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/5/19 21:16:23
    /// 版 本：1.0
    /// 描 述：基础控制器
    /// </summary>
    [CustomRoute]
    public class BaseController : ControllerBase
    {

        #region 请求的返回

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public ApiResult Success(object o)
        {
            return new ApiResult
            {
                Success = true,
                Msg = "请求成功！",
                Data = o
            };
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public ApiResult Success()
        {
            return new ApiResult
            {
                Success = true,
                Msg = "请求成功！",
                Data = null
            };
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public ApiResult Success(string msg)
        {
            return new ApiResult
            {
                Success = true,
                Msg = msg,
                Data = null
            };
        }



        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg">返回的消息</param>
        /// <param name="data">返回的数据</param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public ApiResult Success(string msg, object data)
        {
            return new ApiResult
            {
                Success = true,
                Msg = msg,
                Data = data
            };
        }

        /// <summary>
        /// 返回错误
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public ApiResult Error()
        {
            return new ApiResult
            {
                Success = false,
                Msg = "请求失败！",
                Data = null
            };
        }

        /// <summary>
        /// 返回错误
        /// </summary>
        /// <param name="msg">错误提示</param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public ApiResult Error(string msg)
        {
            return new ApiResult
            {
                Success = false,
                Msg = msg,
                Data = null
            };
        }


        #endregion

        #region 用户相关操作

        /// <summary>
        /// 获取当前登入的用户ID以及名字
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public UserApiToken GetUser()
        {
            return ServiceLocator.Resolve<IApiTokenService>().GetUserPayloadByToken();
        }

        #endregion

        #region 日志相关

        /// <summary>
        /// 写入信息日志
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tags"></param>
        [ApiExplorerSettings(IgnoreApi = true)]
        public void WriteInfo(string str, params string[] tags)
        {
            if (tags.Length == 0)
                tags = new string[] { getMethodBaseName() };
            ExceptionlessHelper.Info(str, tags);
        }

        /// <summary>
        /// 写入跟踪日志
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tags"></param>
        [ApiExplorerSettings(IgnoreApi = true)]
        public void WriteTrace(string str, params string[] tags)
        {
            if (tags.Length == 0)
                tags = new string[] { getMethodBaseName() };
            ExceptionlessHelper.Trace(str, tags);
        }

        /// <summary>
        /// 写入警告日志
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tags"></param>
        [ApiExplorerSettings(IgnoreApi = true)]
        public void WriteWarn(string str, params string[] tags)
        {
            if (tags.Length == 0)
                tags = new string[] { getMethodBaseName() };
            ExceptionlessHelper.Warn(str, tags);
        }

        /// <summary>
        /// 写入调试日志
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tags"></param>
        [ApiExplorerSettings(IgnoreApi = true)]
        public void WriteDebug(string str, params string[] tags)
        {
            if (tags.Length == 0)
                tags = new string[] { getMethodBaseName() };
            ExceptionlessHelper.Debug(str, tags);
        }

        /// <summary>
        /// 写入异常日志（自定义异常）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tags"></param>
        [ApiExplorerSettings(IgnoreApi = true)]
        public void WriteError(string str, params string[] tags)
        {
            if (tags.Length == 0)
                tags = new string[] { getMethodBaseName() };
            ExceptionlessHelper.Error(str, tags);
        }


        #region 获取调用该方法的名字

        /// <summary>
        /// 获取调用该方法的名字
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public static string getMethodBaseName()
        {
            StackTrace trace = new StackTrace();
            MethodBase methodName = trace.GetFrame(2).GetMethod();
            return methodName.Name;
        }

        #endregion

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Base;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarTravelNet.Api.Controllers
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/7/24 10:40:23
    /// 版 本：1.0
    /// 描 述：传入表的实体生成_bll的基础控制器
    /// </summary>
    [CustomRoute]
    public class BasisController<T> : BaseController where T : class, new()
    {
        /// <summary>
        /// 基础方法
        /// </summary>
        protected BaseIBLL<T> _bll = BaseBLL<T>.Instance();

    }
}
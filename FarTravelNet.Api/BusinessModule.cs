using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarTravelNet.Api
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/5/12 23:03:39
    /// 版 本：1.0
    /// 描 述：AutoFac模块化注入,
    /// 将注册依赖注入的代码抽离到这边来，
    /// 以减少Startup文件的代码堆积
    /// </summary>
    public class BusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<HomeBusiness>().AsImplementedInterfaces();
        }
    }
}

using Microsoft.AspNetCore.Builder;
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
    /// 描 述：服务定位
    /// </summary>
    public class ServiceLocator
    {
        private static IServiceProvider _serviceProvider;

        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static object Resolve(Type t)
        {
            if (_serviceProvider == null)
                return null;

            return _serviceProvider.GetService(t);
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
    }
}

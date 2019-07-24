using Autofac;

namespace Base
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019-04-30 20:22:09
    /// 版 本：1.0
    /// 描 述：Autofac帮助类
    /// </summary>
    public class AutofacHelper
    {
        public static IContainer Container { get; set; }

        public static T GetService<T>()
        {
            return (T)Container?.Resolve(typeof(T));
        }
    }
}
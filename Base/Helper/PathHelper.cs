using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System.IO;

namespace Base
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019-01-30 23:21:09
    /// 版 本：1.0
    /// 描 述：路径帮助类
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// 获取Url
        /// </summary>
        /// <param name="virtualUrl">虚拟Url</param>
        /// <returns></returns>
        public static string GetUrl(string virtualUrl)
        {
            if (!virtualUrl.IsNullOrEmpty())
            {
                UrlHelper urlHelper = new UrlHelper(AutofacHelper.GetService<IActionContextAccessor>().ActionContext);

                return urlHelper.Content(virtualUrl);
            }
            else
                return null;
        }

        /// <summary>
        /// 获取绝对路径
        /// </summary>
        /// <param name="virtualPath">虚拟路径</param>
        /// <returns></returns>
        public static string GetAbsolutePath(string virtualPath)
        {
            string path = virtualPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            if (path[0] == '~')
                path = path.Remove(0, 2);
            string rootPath = AutofacHelper.GetService<IHostingEnvironment>().WebRootPath;

            return Path.Combine(rootPath, path);
        }
    }
}

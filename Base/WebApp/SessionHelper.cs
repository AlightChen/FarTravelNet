﻿namespace Base
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019-01-31 16:22:09
    /// 版 本：1.0
    /// 描 述：Session帮助类,自定义Session,解决原Session并发问题
    /// </summary>
    public class SessionHelper
    {
        #region 私有成员

        private static string CacheModuleName { get; } = "Session";
        private static string _sessionId { get => HttpContextCore.Current.Request.Cookies[SessionCookieName]; }
        private static string BuildCacheKey(string sessionKey)
        {
            return $"{GlobalSwitch.ProjectName}_{CacheModuleName}_{_sessionId}_{sessionKey}";
        }

        #endregion

        #region 外部成员

        /// <summary>
        /// 存放Session标志的Cookie名
        /// </summary>
        public static string SessionCookieName { get; } = "FarTravelNet.ASP.NETCore_Session_Id";

        /// <summary>
        /// 当前Session
        /// </summary>
        public static _Session Session { get; } = new _Session();

        /// <summary>
        /// 自定义_Session类
        /// </summary>
        public class _Session
        {
            public object this[string index]
            {
                get
                {
                    string cacheKey = BuildCacheKey(index);
                    return CacheHelper.Cache.GetCache(cacheKey);
                }
                set
                {
                    string cacheKey = BuildCacheKey(index);
                    if (value.IsNullOrEmpty())
                        CacheHelper.Cache.RemoveCache(cacheKey);
                    else
                        CacheHelper.Cache.SetCache(cacheKey, value);
                }
            }
        }

        #endregion
    }
}

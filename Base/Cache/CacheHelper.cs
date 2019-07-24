﻿using System;

namespace Base
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/4/1 16:03:36
    /// 版 本：1.0
    /// 描 述：缓存帮助类
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 静态构造函数，初始化缓存类型
        /// </summary>
        static CacheHelper()
        {
            SystemCache = new SystemCache();

            if (!GlobalSwitch.RedisConfig.IsNullOrEmpty())
            {
                try
                {
                    RedisCache = new RedisCache(GlobalSwitch.RedisConfig);
                }
                catch
                {

                }
            }

            switch (GlobalSwitch.CacheType)
            {
                case CacheType.SystemCache: Cache = SystemCache; break;
                case CacheType.RedisCache: Cache = RedisCache; break;
                default: throw new Exception("请指定缓存类型！");
            }
        }

        /// <summary>
        /// 默认缓存
        /// </summary>
        public static ICache Cache { get; }

        /// <summary>
        /// 系统缓存
        /// </summary>
        public static ICache SystemCache { get; }

        /// <summary>
        /// Redis缓存
        /// </summary>
        public static ICache RedisCache { get; }
    }
}

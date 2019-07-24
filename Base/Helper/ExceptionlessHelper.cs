using Exceptionless;
using Exceptionless.Logging;
using System;

namespace Base
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/7/7 11:11:26
    /// 版 本：1.0
    /// 描 述：Exceptionless的帮助类
    /// </summary>
    public static partial class ExceptionlessHelper
    {
        /// <summary>
        /// 写入跟踪日志
        /// </summary>
        public static void Trace(string message, params string[] tags)
        {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Trace).AddTags(tags).Submit();
        }

        /// <summary>
        /// 写入调试日志
        /// </summary>
        public static void Debug(string message, params string[] tags)
        {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Debug).AddTags(tags).Submit();
        }

        /// <summary>
        /// 写入信息日志
        /// </summary>
        public static void Info(string message, params string[] tags)
        {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Info).AddTags(tags).Submit();
        }

        /// <summary>
        /// 写入警告日志
        /// </summary>
        public static void Warn(string message, params string[] tags)
        {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Warn).AddTags(tags).Submit();
        }

        /// <summary>
        /// 写入异常日志
        /// </summary>
        public static void Error(string message, params string[] tags)
        {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Error).AddTags(tags).Submit();
        }

        /// <summary>
        /// 写入异常日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteException(this Exception ex)
        {
            ex.ToExceptionless().Submit();
        }
    }
}

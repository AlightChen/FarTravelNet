namespace Base
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/4/1 16:03:36
    /// 版 本：1.0
    /// 描 述：数据库帮助类工厂
    /// </summary>
    public class DbHelperFactory
    {
        static DbHelperFactory()
        {
            _container = new IocHelper();
            _container.RegisterType<DbHelper, SqlServerHelper>(DatabaseType.SqlServer.ToString());
            _container.RegisterType<DbHelper, MySqlHelper>(DatabaseType.MySql.ToString());
            _container.RegisterType<DbHelper, PostgreSqlHelper>(DatabaseType.PostgreSql.ToString());
        }

        private static IocHelper _container { get; }

        /// <summary>
        /// 获取指定的数据库帮助类
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="conStr">连接字符串</param>
        /// <returns></returns>
        public static DbHelper GetDbHelper(DatabaseType dbType, string conStr)
        {
            return _container.Resolve<DbHelper>(dbType.ToString(), conStr);
        }

        /// <summary>
        /// 获取指定的数据库帮助类
        /// </summary>
        /// <param name="dbType">数据库类型字符串</param>
        /// <param name="conStr">连接字符串</param>
        /// <returns></returns>
        public static DbHelper GetDbHelper(string dbTypeStr, string conStr)
        {
            DatabaseType dbType = DbProviderFactoryHelper.DbTypeStrToDbType(dbTypeStr);
            return GetDbHelper(dbType, conStr);
        }
    }
}

﻿using Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019-02-13 20:14:41
    /// 版 本：1.0
    /// 描 述：数据库操作类
    /// </summary>
    public class BaseDbContext
    {

        public SqlSugarClient Db;

        private DbType dbType;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseDbContext()
        {
            try
            {
                var connMain = ConfigHelper.GetConnectionString("BaseDb");
                dbType = (DbType)ConfigHelper.GetValue("DbType").ToInt();
                var connFrom = "";
                InitDataBase(string.IsNullOrEmpty(connFrom)
                    ? new List<string> { connMain.ToString() }
                    : new List<string> { connMain.ToString(), connFrom.ToString() });
            }
            catch (Exception ex)
            {
                throw new Exception("未配置数据库连接字符串");
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="listConnSettings">
        /// 连接字符串配置Key集合,配置多个连接则是读写分离 
        /// </param>
        public BaseDbContext(List<string> listConnSettings)
        {
            try
            {
                var listConn = new List<string>();
                foreach (var t in listConnSettings)
                {
                    listConn.Add(t);//数据库连接字串
                }
                InitDataBase(listConn);
            }
            catch
            {
                throw new Exception("未配置数据库连接字符串");
            }

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serverIp">服务器IP</param>
        /// <param name="user">用户名</param>
        /// <param name="pass">密码</param>
        /// <param name="dataBase">数据库</param>
        public BaseDbContext(string serverIp, string user, string pass, string dataBase)
        {
            InitDataBase(new List<string> { $"server={serverIp};user id={user};password={pass};persistsecurityinfo=True;database={dataBase}" });
        }
        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="listConn">连接字符串</param>
        private void InitDataBase(List<string> listConn)
        {
            var connStr = "";//主库
            var slaveConnectionConfigs = new List<SlaveConnectionConfig>();//从库集合
            for (var i = 0; i < listConn.Count; i++)
            {
                if (i == 0)
                {
                    connStr = listConn[i];//主数据库连接
                }
                else
                {
                    slaveConnectionConfigs.Add(new SlaveConnectionConfig()
                    {
                        HitRate = i * 2,
                        ConnectionString = listConn[i]
                    });
                }
            }
            //如果配置了 SlaveConnectionConfigs那就是主从模式,所有的写入删除更新都走主库，查询走从库，
            //事务内都走主库，HitRate表示权重 值越大执行的次数越高，如果想停掉哪个连接可以把HitRate设为0
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connStr,
                DbType = dbType,//(int)SysConfig.Params.DbType,//这边放配置文件写的数据库类型
                IsAutoCloseConnection = true,

                SlaveConnectionConfigs = slaveConnectionConfigs
            });
            Db.Ado.CommandTimeOut = 30000;//设置超时时间
            Db.Aop.OnLogExecuted = (sql, pars) => //SQL执行完事件
            {

            };
            Db.Aop.OnLogExecuting = (sql, pars) => //SQL执行前事件
            {

            };
            Db.Aop.OnError = (exp) =>//执行SQL 错误事件
            {
                throw new Exception(exp.Message);
            };
            Db.Aop.OnExecutingChangeSql = (sql, pars) => //SQL执行前 可以修改SQL
            {
                return new KeyValuePair<string, SugarParameter[]>(sql, pars);
            };
        }
    }
}

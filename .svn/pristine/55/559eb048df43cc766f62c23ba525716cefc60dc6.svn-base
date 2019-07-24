using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace DAL
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019-02-05 23:05:17
    /// 版 本：1.0
    /// 描 述：SqlSugar操作类型
    /// </summary>
    public class SugerHandler : ISugerHandler
    {
        #region 属性 
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private SqlSugarClient DbContext { get; set; }

        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static ISugerHandler Instance()
        {
            var db = new SugerHandler();
            db.Init();
            return db;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="listConnSettings">
        /// 连接字符串配置Key集合,配置多个连接则是读写分离 
        /// </param>
        /// <returns></returns>
        public static ISugerHandler Instance(List<string> listConnSettings)
        {
            var db = new SugerHandler();
            db.Init(listConnSettings);
            return db;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="serverIp">服务器IP</param>
        /// <param name="user">用户名</param>
        /// <param name="pass">密码</param>
        /// <param name="dataBase">数据库</param>
        /// <returns></returns>
        public static ISugerHandler Instance(string serverIp, string user, string pass, string dataBase)
        {
            var db = new SugerHandler();
            db.Init(serverIp, user, pass, dataBase);
            return db;
        }
        /// <summary>
        /// 初始化DB
        /// </summary>
        private void Init()
        {
            //把一个会话的数据库连接缓存起来，这边在来读取
            //var dbContext = CallContext.GetData("DBContext") as BaseDbContext;
            //if (dbContext == null)
            //{
            //    dbContext = new BaseDbContext();
            //    CallContext.SetData("DBContext", dbContext);
            //}
            //DbContext = dbContext.Db;
            DbContext = new BaseDbContext().Db;
        }

        /// <summary>
        /// 初始化DB
        /// </summary>
        /// <param name="listConnSettings">
        /// 连接字符串配置Key集合,配置多个连接则是读写分离 
        /// </param>
        private void Init(List<string> listConnSettings)
        {
            //var dbContext = CallContext.GetData("DBConnSettings") as BaseDbContext;
            //if (dbContext == null)
            //{
            //    dbContext = new BaseDbContext(listConnSettings);
            //    CallContext.SetData("DBConnSettings", dbContext);
            //}
            //DbContext = dbContext.Db;
        }

        /// <summary>
        /// 初始化DB
        /// </summary>
        /// <param name="serverIp">服务器IP</param>
        /// <param name="user">用户名</param>
        /// <param name="pass">密码</param>
        /// <param name="dataBase">数据库</param>
        private void Init(string serverIp, string user, string pass, string dataBase)
        {
            //var dbContext = CallContext.GetData("DBServer") as BaseDbContext;
            //if (dbContext == null)
            //{
            //    dbContext = new BaseDbContext(serverIp, user, pass, dataBase);
            //    CallContext.SetData("DBServer", dbContext);
            //}
            //DbContext = dbContext.Db;
        }
        #endregion

        #region 事务

        /// <summary>
        /// 初始化事务
        /// </summary>
        /// <param name="level"></param>
        public void BeginTran(System.Data.IsolationLevel level = System.Data.IsolationLevel.ReadCommitted)
        {
            DbContext.Ado.BeginTran(System.Data.IsolationLevel.Unspecified);
        }

        /// <summary>
        /// 完成事务
        /// </summary>
        public void CommitTran()
        {
            DbContext.Ado.CommitTran();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTran()
        {
            DbContext.Ado.RollbackTran();
        }
        #endregion

        #region 新增 
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="entity"> 实体对象 </param> 
        /// <param name="isLock">是否加锁</param>
        /// <returns>操作影响的行数</returns>
        public int Add<T>(T entity, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Insertable(entity).With(SqlWith.UpdLock).ExecuteCommand()
                    : DbContext.Insertable(entity).ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="entitys">泛型集合</param>
        /// <param name="isLock">是否加锁</param>
        /// <returns>操作影响的行数</returns>
        public int Add<T>(List<T> entitys, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Insertable(entitys).With(SqlWith.UpdLock).ExecuteCommand()
                    : DbContext.Insertable(entitys).ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="entity"> 实体对象 </param> 
        /// <param name="isLock">是否加锁</param>
        /// <returns>返回实体</returns>
        public T AddReturnEntity<T>(T entity, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Insertable(entity).With(SqlWith.UpdLock).ExecuteReturnEntity()
                    : DbContext.Insertable(entity).ExecuteReturnEntity();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 新增
        /// </summary> 
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="entity"> 实体对象 </param> 
        /// <param name="isLock">是否加锁</param>
        /// <returns>返回bool, 并将identity赋值到实体</returns>
        public bool AddReturnBool<T>(T entity, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Insertable(entity).With(SqlWith.UpdLock).ExecuteCommandIdentityIntoEntity()
                    : DbContext.Insertable(entity).ExecuteCommandIdentityIntoEntity();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="entitys">泛型集合</param>
        /// <param name="isLock">是否加锁</param>
        /// <returns>返回bool, 并将identity赋值到实体</returns>
        public bool AddReturnBool<T>(List<T> entitys, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Insertable(entitys).With(SqlWith.UpdLock).ExecuteCommandIdentityIntoEntity()
                    : DbContext.Insertable(entitys).ExecuteCommandIdentityIntoEntity();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region 修改 
        /// <summary>
        /// 修改数据源
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <returns>数据源</returns>
        public IUpdateable<T> Updateable<T>() where T : class, new()
        {
            return DbContext.Updateable<T>();
        }
        /// <summary>
        /// 修改（主键是更新条件）
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="entity"> 实体对象 </param> 
        /// <param name="isLock"> 是否加锁 </param> 
        /// <returns>操作影响的行数</returns>
        public int Update<T>(T entity, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Updateable(entity).With(SqlWith.UpdLock).ExecuteCommand()
                    : DbContext.Updateable(entity).ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="update"> 实体对象 </param> 
        /// <param name="where"> 条件 </param> 
        /// <param name="isLock"> 是否加锁 </param> 
        /// <returns>操作影响的行数</returns>
        public int Update<T>(Expression<Func<T, T>> update, Expression<Func<T, bool>> where, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Updateable<T>().UpdateColumns(update).Where(where).With(SqlWith.UpdLock).ExecuteCommand()
                    : DbContext.Updateable<T>().UpdateColumns(update).Where(where).ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 修改（主键是更新条件）
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="entitys"> 实体对象集合 </param> 
        /// <param name="isLock"> 是否加锁 </param> 
        /// <returns>操作影响的行数</returns>
        public int Update<T>(List<T> entitys, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Updateable(entitys).With(SqlWith.UpdLock).ExecuteCommand()
                    : DbContext.Updateable(entitys).ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region 删除


        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="entity"> 实体对象 </param> 
        /// <param name="isLock"> 是否加锁 </param> 
        /// <returns>操作影响的行数</returns>
        public int Delete<T>(T entity, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Deleteable(entity).With(SqlWith.UpdLock).ExecuteCommand()
                    : DbContext.Deleteable(entity).ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="where"> 条件 </param> 
        /// <param name="isLock"> 是否加锁 </param> 
        /// <returns>操作影响的行数</returns>
        public int Delete<T>(Expression<Func<T, bool>> where, bool isLock = false) where T : class, new()
        {
            try
            {
                var result = isLock ?
                    DbContext.Deleteable<T>().Where(where).With(SqlWith.UpdLock).ExecuteCommand()
                    : DbContext.Deleteable<T>().Where(where).ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                RollbackTran();
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询数据源
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <returns>数据源</returns>
        public ISugarQueryable<T> Queryable<T>() where T : class, new()
        {
            return DbContext.Queryable<T>();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns></returns>
        public T Query<T>(Expression<Func<T, bool>> whereLambda) where T : class, new()
        {
            return DbContext.Queryable<T>().With(SqlWith.NoLock).Where(whereLambda).First();
        }

        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        public List<T> QueryList<T>(Expression<Func<T, bool>> whereLambda) where T : class, new()
        {
            return DbContext.Queryable<T>().With(SqlWith.NoLock).Where(whereLambda).ToList();
        }
        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="sql">sql</param>
        /// <returns>实体</returns>
        public List<T> QueryList<T>(string sql) where T : class, new()
        {
            return DbContext.SqlQueryable<T>(sql).With(SqlWith.NoLock).ToList();
        }
        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        public DataTable QueryDataTable<T>(Expression<Func<T, bool>> whereLambda) where T : class, new()
        {
            return DbContext.Queryable<T>().With(SqlWith.NoLock).Where(whereLambda).ToDataTable();
        }
        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="sql">sql</param>
        /// <returns>实体</returns>
        public DataTable QueryDataTable<T>(string sql) where T : class, new()
        {
            return DbContext.SqlQueryable<T>(sql).With(SqlWith.NoLock).ToDataTable();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="query">查询条件</param>
        /// <param name="totalCount">总行数</param>
        /// <returns>实体</returns>
        public List<T> QueryPageList<T>(QueryDescriptor query, out int totalCount) where T : class, new()
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            var listDatas = DbContext.Queryable<T>();
            if (query.Conditions != null)
            {
                var conds = ParseCondition(query.Conditions);
                listDatas = listDatas.Where(conds);
            }

            if (query.OrderBys != null)
            {
                var orderBys = ParseOrderBy(query.OrderBys);
                listDatas = listDatas.OrderBy(orderBys);
            }

            totalCount = 0;
            var datas = listDatas.ToPageList(query.PageIndex, query.PageSize, ref totalCount);
            return datas;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="query">查询条件</param>
        /// <param name="totalCount">总行数</param>
        /// <returns>DataTable</returns>
        public DataTable QueryDataTablePageList<T>(QueryDescriptor query, out int totalCount) where T : class, new()
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            var listDatas = DbContext.Queryable<T>();
            if (query.Conditions != null)
            {
                var conds = ParseCondition(query.Conditions);
                listDatas = listDatas.Where(conds);
            }

            if (query.OrderBys != null)
            {
                var orderBys = ParseOrderBy(query.OrderBys);
                listDatas = listDatas.OrderBy(orderBys);
            }

            totalCount = 0;
            var datas = listDatas.ToDataTablePage(query.PageIndex, query.PageSize, ref totalCount);
            return datas;
        }

        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型)</typeparam>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>Json</returns>
        public string QueryJson<T>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda) where T : class, new()
        {
            return DbContext.Queryable<T>().With(SqlWith.NoLock).Where(whereLambda).ToJson();
        }
        /// <summary>
        /// 查询存储过程
        /// </summary> 
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        public DataTable QueryProcedure(string procedureName, List<SugarParameter> parameters)
        {
            var datas = DbContext.Ado.UseStoredProcedure().GetDataTable(procedureName, parameters);
            return datas;
        }

        /// <summary>
        /// 查询前多少条数据
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <param name="whereLambda">查询表达式</param>
        /// <param name="num">数量</param>
        /// <returns></returns>
        public List<T> Take<T>(Expression<Func<T, bool>> whereLambda, int num) where T : class, new()
        {
            var datas = DbContext.Queryable<T>().With(SqlWith.NoLock).Where(whereLambda).Take(num).ToList();
            return datas;
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <param name="whereLambda">查询表达式</param> 
        /// <returns></returns>
        public T First<T>(Expression<Func<T, bool>> whereLambda) where T : class, new()
        {
            var datas = DbContext.Queryable<T>().With(SqlWith.NoLock).Where(whereLambda).First();
            return datas;
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <param name="whereLambda">查询表达式</param> 
        /// <returns></returns>
        public bool IsExist<T>(Expression<Func<T, bool>> whereLambda) where T : class, new()
        {
            var datas = DbContext.Queryable<T>().Any(whereLambda);
            return datas;
        }
        /// <summary>
        /// 合计
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <param name="field">字段</param> 
        /// <returns></returns>
        public int Sum<T>(string field) where T : class, new()
        {
            var datas = DbContext.Queryable<T>().Sum<int>(field);
            return datas;
        }
        /// <summary>
        /// 最大值
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <param name="field">字段</param> 
        /// <returns></returns>
        public object Max<T>(string field) where T : class, new()
        {
            var datas = DbContext.Queryable<T>().Max<object>(field);
            return datas;
        }
        /// <summary>
        /// 最小值
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <param name="field">字段</param> 
        /// <returns></returns>
        public object Min<T>(string field) where T : class, new()
        {
            var datas = DbContext.Queryable<T>().Min<object>(field);
            return datas;
        }

        /// <summary>
        /// 平均值
        /// </summary>
        /// <typeparam name="T">泛型参数(集合成员的类型</typeparam>
        /// <param name="field">字段</param> 
        /// <returns></returns>
        public int Avg<T>(string field) where T : class, new()
        {
            var datas = DbContext.Queryable<T>().Avg<int>(field);
            return datas;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 查询条件转换
        /// </summary>
        /// <param name="contitons">查询条件</param>
        /// <returns></returns>
        private List<IConditionalModel> ParseCondition(List<ConditionalModel> contitons)
        {
            var conds = new List<IConditionalModel>();
            foreach (var con in contitons)
            {
                if (con.FieldName.Contains(","))
                {
                    conds.Add(ParseKeyOr(con));
                }
                else
                {
                    conds.Add(new ConditionalModel()
                    {
                        FieldName = con.FieldName,
                        ConditionalType = con.ConditionalType,
                        FieldValue = con.FieldValue
                    });
                }
            }

            return conds;
        }
        /// <summary>
        /// 转换Or条件
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        private ConditionalCollections ParseKeyOr(ConditionalModel condition)
        {
            var objectKeys = condition.FieldName.Split(',');
            var conditionalList = new List<KeyValuePair<WhereType, ConditionalModel>>();
            foreach (var objKey in objectKeys)
            {
                var cond = new KeyValuePair<WhereType, ConditionalModel>
                (WhereType.Or, new ConditionalModel()
                {
                    FieldName = objKey,
                    ConditionalType = condition.ConditionalType,
                    FieldValue = condition.FieldValue
                });
                conditionalList.Add(cond);
            }
            return new ConditionalCollections { ConditionalList = conditionalList };
        }


        /// <summary>
        /// 排序转换
        /// </summary>
        /// <param name="orderBys">排序</param>
        /// <returns></returns>
        private string ParseOrderBy(List<OrderByClause> orderBys)
        {
            var conds = "";
            foreach (var con in orderBys)
            {
                if (con.Order == OrderSequence.Asc)
                {
                    conds += $"{con.Sort} asc,";
                }
                else if (con.Order == OrderSequence.Desc)
                {
                    conds += $"{con.Sort} desc,";
                }
            }

            return conds.TrimEnd(',');
        }
        #endregion

        /// <summary>
        /// 结束
        /// </summary>
        public void Dispose()
        {
            RollbackTran();
            DbContext.Close();
        }
    }
}
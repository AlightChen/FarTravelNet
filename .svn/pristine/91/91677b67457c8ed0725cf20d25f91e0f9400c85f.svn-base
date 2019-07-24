using SqlSugar;
using System.Collections.Generic;

namespace DAL
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019-02-13 20:12:15
    /// 版 本：1.0
    /// 描 述：查询参数
    /// </summary>
    public class QueryDescriptor
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public List<OrderByClause> OrderBys { get; set; }
        /// <summary>
        /// 条件
        /// </summary>
        public List<ConditionalModel> Conditions { get; set; }
    }


    /// <summary>
    /// 排序类型
    /// </summary>
    public enum OrderSequence
    {
        Asc,
        Desc
    }

    /// <summary>
    /// 排序枚举
    /// </summary>
    public class OrderByClause
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 排序规则
        /// </summary>
        public OrderSequence Order { get; set; }
    }
}

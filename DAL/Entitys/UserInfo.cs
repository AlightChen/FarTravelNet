using System;
using SqlSugar;

namespace DAL.Entitys
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public UserInfo()
        {
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string ID { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string USERCODE { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string USERNAME { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PASSWORD { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HEADPORTRAIT { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATETIME { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UPDATETIME { get; set; }

        /// <summary>
        /// 最后登入时间
        /// </summary>
        public DateTime? LASRLOGINTIME { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool ENABLE { get; set; }

        /// <summary>
        /// 标记删除
        /// </summary>
        public bool UMDELETE { get; set; }
    }
}
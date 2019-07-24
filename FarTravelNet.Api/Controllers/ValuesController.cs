using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base;
using BLL;
using DAL.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace FarTravelNet.Api.Controllers
{
    /// <summary>
    /// 测试接口
    /// </summary>
    public class ValuesController : BasisController<UserInfo>
    {

        /// <summary>
        /// 获取所有的用户集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ApiResult> Get()
        {
            List<UserInfo> list = _bll.GetList();
            return Success(list);
        }

        /// <summary>
        /// 根据ID获取一条用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ApiResult> Get(string id)
        {
            UserInfo model = _bll.Get(x => x.ID == id);
            return Success(model);
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] UserInfo value)
        {

        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

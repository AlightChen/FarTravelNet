﻿using System;
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
    /// 创建人：落
    /// 日 期：2019/6/15 21:16:23
    /// 版 本：1.0
    /// 描 述：登录接口
    /// </summary>

    public class AccountController : BasisController<UserInfo>
    {

        #region 参数

        private readonly IApiTokenService _apiTokenService;

        #endregion

        #region 私有方法

        /// <summary>
        /// 构造注入服务
        /// </summary>
        /// <param name="apiTokenService"></param>
        public AccountController(IApiTokenService apiTokenService)
        {
            _apiTokenService = apiTokenService;
        }

        #endregion

        #region 外部接口

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ApiResult> Login(string userName, string userPwd)
        {
            //login...
            if (userName.IsEmpty() || userPwd.IsEmpty())
                return Error("账号或者密码不能为空");
            var user = _bll.Get(x => x.USERCODE == userName && x.ENABLE);
            if (userName != "123456" && userPwd != "123456")
                return Error("账号或者密码错误");
            var userId = 1;
            var token = _apiTokenService.ConvertLoginToken(userId, userName);
            //登录成功后返回token
            return Ok(new { status = 1, msg = "登录成功", data = token });
        }

        #endregion

    }
}

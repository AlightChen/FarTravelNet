using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Base;

namespace FarTravelNet.Web.Controllers
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/2/22 9:11:00
    /// 版 本：1.0
    /// 描 述：主控制器
    /// </summary>
    public class HomeController : BaseController
    {

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "你的IP是:" + GetUser().IP;

            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "你的IP是:" + GetUser().IP;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorView()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

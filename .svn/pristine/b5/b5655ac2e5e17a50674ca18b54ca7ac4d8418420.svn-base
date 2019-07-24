using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace FarTravelNet.Api.Controllers
{
    /// <summary>
    /// 用户中心接口
    /// </summary>
    [UserAuthorize]
    public class UserCenterController : BaseController
    {

        #region 外部接口

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Info()
        {
            var userPayload = ServiceLocator.Resolve<IApiTokenService>().GetUserPayloadByToken();
            return Ok(new { status = 1, data = userPayload });
        }
        [HttpGet]
        [CustomRoute(ApiVersions.v1,"info")]
        public IActionResult InfoV1()
        {
            var userPayload = ServiceLocator.Resolve<IApiTokenService>().GetUserPayloadByToken();
            return Ok(new { status = 1, data = userPayload });
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateInfo()
        {
            return Ok("success");
        }
        /// <summary>
        /// 生成头像
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerFileUpload(true)]
        public IActionResult UploadAvster()
        {
            var file = Request.Form.Files[0];
            if (file == null)
                return Ok(new { status = 0, msg = "请上传图片" });
            var upFileName = ContentDispositionHeaderValue
                   .Parse(file.ContentDisposition)
                   .FileName
                   .Trim('"');
            //大小，格式校验....
            var fileName = Guid.NewGuid() + Path.GetExtension(upFileName);
            var saveDir = @".\wwwroot\uploads\";
            var savePath = saveDir + fileName;
            var previewPath = "/uploads/" + fileName;

            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            using (FileStream fs = System.IO.File.Create(savePath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return Ok(new
            {
                status = 1,
                msg = "上传成功",
                data = new
                {
                    preview = previewPath,
                    value = previewPath
                }
            });
        }

        #endregion

    }
}

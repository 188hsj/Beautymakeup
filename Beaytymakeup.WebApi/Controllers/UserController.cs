using Beautymakeup.Common.Helper;
using Beautymakeup.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beautymakeup.WebApi.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// hello 请求
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Hello()
        {
            return Ok("Hello world");
        }
        [HttpPost]
        [Authorize(Roles = "System")]
        public IActionResult Users([FromBody] User user)
        {
            return Ok(user);
        }

        [HttpGet]
        public IActionResult Login(string role)
        {
            string jwtStr = string.Empty;
            bool success = false;

            if (role == null)
                return NotFound(new { success = success,jwtStr="login fail!!!"});

            var tokenModel = new TokenModel {Uid="hoke",Role = role };
            jwtStr = JwtHelper.IssuseJwt(tokenModel);
            success = true;
            return Ok(new { success=success,token = jwtStr });
        }
    }
}

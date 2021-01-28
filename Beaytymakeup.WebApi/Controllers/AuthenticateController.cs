using Beautymakeup.Common.Helper;
using Beautymakeup.Model;
using Beautymakeup.Model.DtoS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AuthenticateController : BaseController
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticateController(
            //UserManager<ApplicationUser> userManager,
            //SignInManager<ApplicationUser> signInManager
            )
        {
           // _userManager = userManager;
            //_signInManager = signInManager;
        }
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

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        //{
        //    string token = string.Empty;
        //    bool success = false;
        //    var loginResult = await _signInManager.PasswordSignInAsync
        //        (
        //        loginDto.Email,
        //        loginDto.Password,
        //        false,
        //        false
        //        );
        //    if (!loginResult.Succeeded)
        //        return BadRequest(new { success = success, token="", message = "登录失败，用户名或密码错误！" });

        //    var user =await _userManager.FindByNameAsync(loginDto.Email);
        //    var roleName = await _userManager.GetRolesAsync(user);

        //    var tokenModel = new TokenModel { Uid = user.Id.ToString(), Role = roleName };
        //    token = JwtHelper.IssuseJwt(tokenModel);
        //    success = true;
        //    return Ok(new { success = success, token = token , message ="登录成功！"});
        //}

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = registerDto.Email,
        //        Email = registerDto.Email
        //    };
        //    //hash密码，保存用户
        //    var result = await _userManager.CreateAsync(user, registerDto.Password);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beautymakeup.Model.DtoS
{
   public class LoginDto
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}

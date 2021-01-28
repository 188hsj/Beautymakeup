using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beautymakeup.Model.DtoS
{
    public class RegisterDto
    {
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password),ErrorMessage ="密码输入不一致！")]
        public string ComfirmPassword { get; set; }
    }
}

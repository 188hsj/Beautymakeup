using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Model.Entitys
{
   public class ApplicationUserRole: IdentityRole<Guid>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        public virtual ICollection<IdentityRoleClaim<Guid>> RoleClaims { get; set; }
    }
}

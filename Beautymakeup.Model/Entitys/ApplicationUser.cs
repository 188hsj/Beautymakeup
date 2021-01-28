using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Model.Entitys
{
  public class ApplicationUser: IdentityUser<Guid>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        = new List<ApplicationUserRole>();

        public virtual ICollection<IdentityUserClaim<Guid>> UserClaims { get; set; }

        public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; }

        public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; }
    }
}

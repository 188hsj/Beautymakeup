using Beautymakeup.Core.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Core.Entitys
{
    public class User : BaseEntity
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}

using Beautymakeup.Core.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Core.Entitys
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Remark { get; set; }
    }
}

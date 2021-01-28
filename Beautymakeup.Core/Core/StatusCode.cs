using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Beautymakeup.Core.Core
{
   public enum StatusCode
    {
        [Description("已删除")]
        Deleted = -1,
        [Description("生效")]
        Enable = 0,
        [Description("失效")]
        Disable = 1,
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Common
{
    /// <summary>
    /// 令牌
    /// </summary>
   public class TokenModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public IList<string> Role { get; set; }
    }
}

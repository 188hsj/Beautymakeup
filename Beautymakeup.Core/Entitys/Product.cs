using Beautymakeup.Core.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Core.Entitys
{
   public class Product: BaseEntity
    {
        public string ProductName { get; set; }

        public string ProductImgUrl { get; set; }
    }
}

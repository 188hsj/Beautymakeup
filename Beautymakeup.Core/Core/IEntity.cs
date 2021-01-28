using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Core.Core
{
   public interface IEntity
    {
    }

    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }

        public StatusCode StatusCode { get; set; }

        public long? Creator { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? Modifier { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}

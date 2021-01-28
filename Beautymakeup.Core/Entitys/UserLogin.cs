using Beautymakeup.Core.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Core.Entitys
{
    public class UserLogin : IEntity
    {
        public long UserId { get; set; }
        public string Account { get; set; }
        public string HashedPassword { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedTime { get; set; }
        public User User { get; set; }
    }
}

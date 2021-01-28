using Beautymakeup.Model.Entitys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Model.DataBase
{
   public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationUserRole,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}

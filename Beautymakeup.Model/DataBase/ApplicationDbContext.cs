using Beautymakeup.Common.Security;
using Beautymakeup.Core.Core;
using Beautymakeup.Core.Entitys;
using Beautymakeup.Model.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Model.DataBase
{
   public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Logrecord> Logrecords { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }


        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddDebug().AddConsole());
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogrecordMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1219490056771866625,
                    Name = "SuperAdmin",
                    DisplayName = "超级管理员",
                    Remark = "系统内置超级管理员",
                    Creator = 1219490056771866624,
                    CreateTime = DateTime.Now
                });

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1219490056771866624,
                    Account = "admin",
                    Name = "admin",
                    RoleId = 1219490056771866625,
                    StatusCode = StatusCode.Enable,
                    Creator = 1219490056771866624,
                    CreateTime = DateTime.Now
                });
            modelBuilder.Entity<UserLogin>().HasData(
               new UserLogin()
               {
                   UserId = 1219490056771866624,
                   Account = "admin",
                   HashedPassword = Crypto.HashPassword("admin"),//默认密码同账号名
                   IsLocked = false
               });
            base.OnModelCreating(modelBuilder);
        }
    }
}

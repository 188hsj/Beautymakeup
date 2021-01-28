using Beautymakeup.Common.Helper;
using Beautymakeup.Core.UnitOfWork;
using Beautymakeup.Model.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beautymakeup.WebApi.SetUp
{
    public static class UnitOfWorkServiceSetup
    {
        /// <summary>
        /// 在<see cref ="IServiceCollection"/>中注册给定上下文作为服务的工作单元。
        /// 同时注册了dbcontext
        /// </summary>
        /// <param name="services"></param>
        /// <remarks>此方法仅支持一个db上下文，如果多次调用，将抛出异常。</remarks>
        /// <returns></returns>
        public static IServiceCollection AddUnitOfWorkService(this IServiceCollection services)
        {
            //注册dbcontext
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(AppSettings.app(new string[] { "AppSettings", "ConnectionString" }));
            });
            //注册工作单元
            services.AddScoped<IUnitOfWork<ApplicationDbContext>, UnitOfWork<ApplicationDbContext>>();
            return services;
        }
    }
}

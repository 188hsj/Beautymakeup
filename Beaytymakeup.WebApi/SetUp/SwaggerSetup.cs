using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Beautymakeup.WebApi.SetUp
{
    public static class SwaggerSetUp
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var apiName = "Beautymakeup.WebApi";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{apiName} 接口文档-.NET CORE 3.1",
                    Description = $"{apiName} HTTP API V1"
                });
                c.OrderActionsBy(o => o.RelativePath);

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Beautymakeup.WebApi.xml");
                var xmlModelPath = Path.Combine(AppContext.BaseDirectory, "Beautymakeup.Model.xml");
                c.IncludeXmlComments(xmlPath, true);
                c.IncludeXmlComments(xmlModelPath,true);

                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description="JWT授权(数据将在请求头中进行传输)直接在下框中输入Bearer {Token}空格分开",
                    Name="Authorization",
                    In=ParameterLocation.Header,
                    Type=SecuritySchemeType.ApiKey
                });
            });
        }
    }
}

using Beautymakeup.Common.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beautymakeup.WebApi.SetUp
{
    public static class AuthorizationSetup
    {
        public static void AddAuthorrizationService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var symmetricKeyAsBase64 = AppSettings.app(new string[] { "JwtSetting", "SecretKey" });
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var issuer = AppSettings.app(new string[] { "JwtSetting", "Issuer" });
            var audience = AppSettings.app(new string[] { "JwtSetting", "Audience" });

            var tokenVaildationParmeters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30),
                RequireExpirationTime = true
            };
            //开启Bearer 认证
            services.AddAuthentication("Bearer")
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenVaildationParmeters;
                o.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired","true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

        }
    }
}

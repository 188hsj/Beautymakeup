using Beautymakeup.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Beautymakeup.Common.Helper
{
    public class JwtHelper
    {
        public static string IssuseJwt(TokenModel tokenModel)
        {
            //获取appsettings.json jwt配置
            string iss = AppSettings.app(new string[] { "JwtSetting", "Issuer" });
            string aud = AppSettings.app(new string[] { "JwtSetting", "Audience" });
            string secretKey = AppSettings.app(new string[] { "JwtSetting", "SecretKey" });

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                // 过期时间
                new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds()}"),
                new Claim(ClaimTypes.Expiration,DateTime.Now.AddSeconds(1000).ToString()),
                new Claim(JwtRegisteredClaimNames.Iss,iss),
                new Claim(JwtRegisteredClaimNames.Aud,aud)
            };
            //将一个用户的多个角色全部赋予
            claims.AddRange(tokenModel.Role.Split(',').Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken
                (
                issuer: iss,
                claims: claims,
                signingCredentials: creds
                );
            var jwtHandler = new JwtSecurityTokenHandler();
            var encodeJwt = jwtHandler.WriteToken(jwt);
            return encodeJwt;
        }

        /// <summary>
        /// 解析JwtToken获取用户id和角色
        /// </summary>
        /// <param name="jwtstr"></param>
        /// <returns></returns>
        public static TokenModel SerializerJwt(string jwtstr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.ReadJwtToken(jwtstr);
            object role;
            try
            {
                token.Payload.TryGetValue(ClaimTypes.Role, out role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModel
            {
                Uid = token.Id.ToString(),
                Role = token != null ? role.ToString() : ""
            };
            return tm;
        }
    }
}

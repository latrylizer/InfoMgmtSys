using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using System.Text;
namespace InfoMgmtSys.Security
{
    public class Tokens
    {
        private readonly IConfiguration? _configuration;

        public Tokens(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }
        public static string CreateToken()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string val = config.GetValue<string>("AppSettings:Token");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(val));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds );
           var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return jwt; 
        }
    }
}

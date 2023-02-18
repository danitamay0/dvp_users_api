using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using users_api.Data;
using users_api.Models;

namespace users_api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController
    {
        public IConfiguration _configuration;
        private readonly DoubleVPartnersDbContext dbContext;

        public AuthController(IConfiguration configuration, DoubleVPartnersDbContext dbContext)
        {
            _configuration = configuration;
            this.dbContext = dbContext;

        }

        [HttpPost]
        [Route("login")]
        public async Task<dynamic> IniciarSesion(AddUserRequest data)
        {
           

            string user = data.user;
            string password = data.password;

            var userDB = await dbContext.Users.Where(x => x.user == user && x.password == password).FirstOrDefaultAsync();
  
            var e = true;
            if (userDB == null || user == null || password == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               // new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", userDB.id),
                new Claim("user", userDB.user)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
           
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            /*DateTime centuryBegin = new DateTime(1970, 1, 1);
            var exp = new TimeSpan(DateTime.Now.AddDays(90).Ticks - centuryBegin.Ticks).TotalSeconds;
            */
          
            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    claims : claims,
                    signingCredentials: singIn
                );
           
            return new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}

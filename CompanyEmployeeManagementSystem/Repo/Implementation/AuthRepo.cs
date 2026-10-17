using CompanyEmployeeManagementSystem.Data;
using CompanyEmployeeManagementSystem.DTOs;
using CompanyEmployeeManagementSystem.Models;
using CompanyEmployeeManagementSystem.Repo.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CompanyEmployeeManagementSystem.Repo.Implementation
{
    public class AuthRepo:IAuthRepo
    {
        private readonly App_Database_Context _db;
        private readonly IConfiguration _configuration;

        public AuthRepo(App_Database_Context db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<string> Login(AuthLoginDTO dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x=>x.Email == dto.Email);
            
            if (user == null)
                return null;
            if (user.Password == dto.Password)
               return GeneratToken(user);

            return null;
        }

        private string GeneratToken(User user)
        {
            var clims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var SignCrad = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var JWTToken = new JwtSecurityToken
            (
                issuer: _configuration["JWT:Isseur"],
                audience: _configuration["JWT:Audiance"],
                expires:DateTime.Now.AddHours(Convert.ToDouble(_configuration["JWT:ExpireInHours"])),
                claims: clims,
                signingCredentials: SignCrad
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWTToken);
            return token;
        }
    }
}

using CompanyEmployeeManagementSystem.DTOs;
using CompanyEmployeeManagementSystem.Repo.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public AuthController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginDTO dto)
        {
            var token = await _unitofwork.AuthCustom.Login(dto);
            if(token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}

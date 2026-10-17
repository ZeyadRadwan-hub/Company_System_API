using AutoMapper;
using CompanyEmployeeManagementSystem.DTOs;
using CompanyEmployeeManagementSystem.Models;
using CompanyEmployeeManagementSystem.Repo.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeProjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] EmployeeProjectCreateDTO dto)
        {
            var x = _mapper.Map<EmployeeProject>(dto);
            await _unitOfWork.EmployeeProjectGeneric.AddObject(x);
            await _unitOfWork.SaveAsync();
            var respone = _mapper.Map<EmployeeProjectResponeDTO>(x);
            return Ok(respone);
        }

        [HttpGet("{EmployeeId:int}")]
        public async Task<List<EmployeeProjectResponeDTO>> Get(int EmployeeId)
        {
            var x = await _unitOfWork.EmployeeProjectCustom.GetByEmployee(EmployeeId);
            var map = _mapper.Map<List<EmployeeProjectResponeDTO>>(x);
            return map;
        }

    }
}

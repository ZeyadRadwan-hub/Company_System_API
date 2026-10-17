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
    public class ProjectController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ProjectCreateDTO dto)
        {
            var x = _mapper.Map<Project>(dto);
            await _unitOfWork.ProjectGeneric.AddObject(x);
            await _unitOfWork.SaveAsync();
            var respone = _mapper.Map<ProjectResponeDTO>(x);
            return Ok(respone);
        }

        [HttpGet("Get-All")]
        public async Task<List<ProjectResponeDTO>> GetAll()
        {
            var x = await _unitOfWork.ProjectGeneric.GetAll();
            var map = _mapper.Map<List<ProjectResponeDTO>>(x);
            return map;
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _unitOfWork.ProjectGeneric.Get(id);
            var map = _mapper.Map<ProjectResponeDTO>(x);
            return Ok(map);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, ProjectUpdateDTO dto)
        {
            var get = await _unitOfWork.ProjectGeneric.Get(id);
            var x = _mapper.Map(dto, get);
            await _unitOfWork.SaveAsync();
            var respone = _mapper.Map<ProjectResponeDTO>(x);
            return Ok(respone);
        }

    }
}

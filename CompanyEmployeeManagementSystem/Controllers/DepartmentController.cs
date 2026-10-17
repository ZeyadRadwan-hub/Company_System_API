using AutoMapper;
using CompanyEmployeeManagementSystem.DTOs;
using CompanyEmployeeManagementSystem.Models;
using CompanyEmployeeManagementSystem.Repo.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanyEmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateDTO dto)
        {
            var x = _mapper.Map<Department>(dto);
            await _unitOfWork.DepartmentGeneric.AddObject(x);
            await _unitOfWork.SaveAsync();
            var respone = _mapper.Map<DepartmentResponeDTO>(x);
            return Ok(respone);
        }

        [HttpGet("Get-All")]
        public async Task<List<DepartmentResponeDTO>> GetAll()
        {
            var x = await _unitOfWork.DepartmentGeneric.GetAll();
            var map = _mapper.Map<List<DepartmentResponeDTO>>(x);
            return map;
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _unitOfWork.DepartmentGeneric.Get(id);
            var map = _mapper.Map<DepartmentResponeDTO>(x);
            return Ok(map);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, DepartmentUpdateDTO dto)
        {
            var get =await _unitOfWork.DepartmentGeneric.Get(id);
            var x = _mapper.Map(dto, get);
           await _unitOfWork.SaveAsync();
            var respone = _mapper.Map<DepartmentResponeDTO>(x);
            return Ok(respone);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
             _unitOfWork.DepartmentGeneric.DeleteObject(id);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

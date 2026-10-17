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
    public class EmployeeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDTO dto)
        {
            var x = _mapper.Map<Employee>(dto);
            await _unitOfWork.EmployeeGeneric.AddObject(x);
            await _unitOfWork.SaveAsync();
            var respone = _mapper.Map<EmployeeResponeDTO>(x);
            return Ok(respone);
        }

        [HttpGet("Get-All")]
        public async Task<List<EmployeeResponeDTO>> GetAll()
        {
            var x = await _unitOfWork.EmployeeGeneric.GetAll();
            var map = _mapper.Map<List<EmployeeResponeDTO>>(x);
            return map;
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _unitOfWork.EmployeeGeneric.Get(id);
            var map = _mapper.Map<EmployeeResponeDTO>(x);
            return Ok(map);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EmployeeUpdateDTO dto)
        {
            var get = await _unitOfWork.EmployeeGeneric.Get(id);
            var x = _mapper.Map(dto, get);
            await _unitOfWork.SaveAsync();
            var respone = _mapper.Map<EmployeeResponeDTO>(x);
            return Ok(respone);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.EmployeeGeneric.DeleteObject(id);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("SearchByName/{Name:alpha}")]
        public async Task<List<EmployeeResponeDTO>> SearchName(string Name)
        {
            var x = await _unitOfWork.EmployeeCustom.SearchByName(Name);
            var map = _mapper.Map<List<EmployeeResponeDTO>>(x);
            return map;
        }

        [HttpGet("SearchByDepartmentId/{id:int}")]
        public async Task<List<EmployeeResponeDTO>> SearchId(int id)
        {
            var x = await _unitOfWork.EmployeeCustom.SearchByDepartmentId(id);
            var map = _mapper.Map<List<EmployeeResponeDTO>>(x);
            return map;
        }
    }
}

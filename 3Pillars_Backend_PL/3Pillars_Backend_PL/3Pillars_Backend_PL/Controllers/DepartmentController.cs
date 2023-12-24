using _3Pillars_Backend_BLL.Specifications.Interface;
using _3Pillars_Backend_BLL.Services.Interface;
using _3Pillars_Backend_DAL.Entities;
using _3Pillars_Backend_PL.DTOs;
using _3Pillars_Backend_PL.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3Pillars_Backend_Repository.Repository.Interface;

namespace _3Pillars_Backend_PL.Controllers
{
    public class DepartmentController : BaseApiController
    {
        private readonly IGenericRepository<Department> _departmentRepo;
        private readonly IMapper _mapper;

        // Promots Dependency Injection
        public DepartmentController(IGenericRepository<Department> departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        [HttpGet] // Default Index action after ControllerName 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<DepartmentDTO>>> GetDepartments()
        {
            // GetAll Departments with Function GetAll In IGenericRepository
            var departments = await _departmentRepo.GetAllAsync();
            // Return 404 With Message "Resources Not Found" if department equal null
            if (departments == null) return NotFound(new ApiResponse(404));
            // Use AutoMapper between Department and DepartmentDTO 
            var dataToReturn = _mapper.Map<IReadOnlyList<Department>, IReadOnlyList<DepartmentDTO>>(departments);
            // Return Ok With Object 'dataToReturn'
            return Ok(dataToReturn);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartmentDTO>> GetDepartmentById(int id)
        {
            // Get Department with Function GetById In IGenericRepository
            var department = await _departmentRepo.GetByIdAsync(id);

            if (department == null) return NotFound(new ApiResponse(404));

            var dataToReturn = _mapper.Map<Department, DepartmentDTO>(department);

            return Ok(dataToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentDTO departmentDto)
        {

            if (ModelState.IsValid)
            {
                // Using AutoMapper between DepartmentDTO and Department 
                var Department = _mapper.Map<DepartmentDTO, Department>(departmentDto);

                // Using Add Function in Department Repository 
                var result = await _departmentRepo.Add(Department);

                if (result <= 0) return null;

                return Ok(Department);
            }

            return BadRequest(new ApiResponse(400, "Bad Request"));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTO departmentDto)
        {

            if (ModelState.IsValid)
            {
                var Department = _mapper.Map<DepartmentDTO, Department>(departmentDto);

                var result = await _departmentRepo.Update(Department);

                if (result <= 0) return null;

                return Ok(Department);
            }

            return BadRequest(new ApiResponse(400, "Bad Request"));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(DepartmentDTO departmentDto)
        {

            if (ModelState.IsValid)
            {
                var Department = _mapper.Map<DepartmentDTO, Department>(departmentDto);

                var result = await _departmentRepo.Delete(Department);

                if (result <= 0) return null;

                return Ok(Department);
            }

            return BadRequest(new ApiResponse(400, "Bad Request"));

        }



    }
}

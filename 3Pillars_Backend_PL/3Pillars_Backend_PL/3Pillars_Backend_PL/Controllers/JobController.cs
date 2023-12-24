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
    public class JobController : BaseApiController
    {
        private readonly IGenericRepository<Job> _jobRepo;
        private readonly IMapper _mapper;

        public JobController(IGenericRepository<Job> JobRepo, IMapper mapper)
        {
            _jobRepo = JobRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<JobDTO>>> GetJobs()
        {
            var jobs = await _jobRepo.GetAllAsync();

            if (jobs == null) return NotFound(new ApiResponse(404));

            var dataToReturn = _mapper.Map<IReadOnlyList<Job>, IReadOnlyList<JobDTO>>(jobs);

            return Ok(dataToReturn);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JobDTO>> GetJobById(int id)
        {
            var job = await _jobRepo.GetByIdAsync(id);

            if (job == null) return NotFound(new ApiResponse(404));

            var dataToReturn = _mapper.Map<Job, JobDTO>(job);

            return Ok(dataToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> CreateJob(JobDTO jobDto)
        {

            if (ModelState.IsValid)
            {
                var job = _mapper.Map<JobDTO, Job>(jobDto);

                var result = await _jobRepo.Add(job);

                if (result <= 0) return null;

                return Ok(job);
            }

            return BadRequest(new ApiResponse(400, "Bad Request"));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateJob(JobDTO jobDto)
        {

            if (ModelState.IsValid)
            {
                var job = _mapper.Map<JobDTO, Job>(jobDto);

                var result = await _jobRepo.Update(job);

                if (result <= 0) return null;

                return Ok(job);
            }

            return BadRequest(new ApiResponse(400, "Bad Request"));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJob(JobDTO jobDto)
        {

            if (ModelState.IsValid)
            {
                var job = _mapper.Map<JobDTO, Job>(jobDto);

                var result = await _jobRepo.Delete(job);

                if (result <= 0) return null;

                return Ok(job);
            }

            return BadRequest(new ApiResponse(400, "Bad Request "));

        }
    }
}


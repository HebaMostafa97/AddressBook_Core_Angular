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
using _3Pillars_Backend_BLL.Specifications.Class;
using _3Pillars_Backend_PL.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using _3Pillars_Backend_DAL.Entities.Identity;

namespace _3Pillars_Backend_PL.Controllers
{
    public class AddressBookController : BaseApiController
    {
        // References 
        private readonly IGenericRepository<AddressBook> _addressBookRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<User> _userManager;

        // Parameter Constructor
        public AddressBookController(IGenericRepository<AddressBook> addressBookRepo, IMapper mapper , IWebHostEnvironment webHostEnvironment , UserManager<User> userManager)
        {
            _addressBookRepo = addressBookRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<AddressBookDTO>>> GetaddressesBook()
        {
            // use this constructor to include 'Departments' and 'Jobs' with AddressBook 
            var spec = new AddressBookSpecification();

            var addressesBooks = await _addressBookRepo.GetAllWithSpecAsync(spec);

            if (addressesBooks == null) return NotFound(new ApiResponse(404));

            var dataToReturn = _mapper.Map<IReadOnlyList<AddressBook>, IReadOnlyList<AddressBookDTO>>(addressesBooks);

            return Ok(dataToReturn);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressBookDTO>> GetAddressBookById(int id)
        {
            var spec = new AddressBookSpecification(id);

            var addressBook = await _addressBookRepo.GetByIdWithSpecAsync(spec);

            if (addressBook == null) return NotFound(new ApiResponse(404));

            var dataToReturn = _mapper.Map<AddressBook, AddressBookDTO>(addressBook);

            return Ok(dataToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAddressBook([FromForm] AddressBookDTO addressBookDto)
        {
            if (CheckEmailExist(addressBookDto.Email).Result.Value)
                return BadRequest(new ApiResponse(409));

            if (ModelState.IsValid)
            {
                addressBookDto.PhotoUrl = FileUploader.UploadFile(addressBookDto.Photo, _webHostEnvironment);

                var addressBook = _mapper.Map<AddressBookDTO, AddressBook>(addressBookDto);
               
                var result = await _addressBookRepo.Add(addressBook);

                if (result <= 0) return null;

                return Ok(addressBook);
            }
            return BadRequest(new ApiResponse(400, "Bad Request"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddressBook([FromForm] AddressBookDTO addressBookDto)
        {

            if (ModelState.IsValid)
            {
                int index = addressBookDto.PhotoUrl.IndexOf('/', "https://".Length);

                addressBookDto.PhotoUrl = addressBookDto.PhotoUrl.Substring(index + 1);

                var addressBook = _mapper.Map<AddressBookDTO, AddressBook>(addressBookDto);

                var result = await _addressBookRepo.Update(addressBook);

                if (result <= 0) return null;

                return Ok(addressBook);
            }

            return BadRequest(new ApiResponse(400, "Bad Request"));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddressBook([FromForm] AddressBookDTO addressBookDto)
        {

            if (ModelState.IsValid)
            {
                int index = addressBookDto.PhotoUrl.IndexOf('/', "https://".Length);

                addressBookDto.PhotoUrl = addressBookDto.PhotoUrl.Substring(index + 1);

                FileUploader.DeleteFile(addressBookDto.PhotoUrl, _webHostEnvironment);

                var addressBook = _mapper.Map<AddressBookDTO, AddressBook>(addressBookDto);

                var result = await _addressBookRepo.Delete(addressBook);

                if (result <= 0) return null;

                return Ok(addressBook);
            }

            return BadRequest(new ApiResponse(400, "Bad Request "));

        }

        [HttpGet("emailExist")]
        public async Task<ActionResult<bool>> CheckEmailExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}

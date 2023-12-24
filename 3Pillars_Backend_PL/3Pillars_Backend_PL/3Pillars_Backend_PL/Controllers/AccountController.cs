using _3Pillars_Backend_BLL.Services.Interface;
using _3Pillars_Backend_DAL.Entities.Identity;
using _3Pillars_Backend_PL.DTOs;
using _3Pillars_Backend_PL.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _3Pillars_Backend_PL.Controllers
{
    public class AccountController : BaseApiController
    {
        // Take Reference From (UserManager,SignInManager,ITokenService,IMapper)
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email); // Get User By Function FindByEmailAsync with Email
            if (user == null) return Unauthorized(new ApiResponse(401));   // if no user return Unauthorized with status code 401
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);// Check Function with UserPassword In BD and Password which in body with Login
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));
            // if result is success return Ok with status code 200 and return DisplayName , Email , Token which return from Function CreateToken from UserDTO
            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
        {
            if (CheckEmailExist(registerDto.Email).Result.Value)
                return BadRequest(new  ApiResponse(409,"Email is already exist"));

            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = registerDto.Email,
                    UserName = registerDto.Email.Split("@")[0],
                    DisplayName = registerDto.DisplayName,
                    PhoneNumber = registerDto.PhoneNumber,
                };
                var result = await _userManager.CreateAsync(user, registerDto.Password); //create User with function CreateAsync with (DisplayName ,Email,UserName ,PhoneNumber and Password)
                if (!result.Succeeded) return BadRequest(new ApiResponse(400));
                return Ok(new UserDTO()
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user, _userManager)
                });
            }

            return BadRequest(new ApiResponse(400, "Bad Request"));

        }

        [HttpGet("emailExist")]
        public async Task<ActionResult<bool>> CheckEmailExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

    }
}

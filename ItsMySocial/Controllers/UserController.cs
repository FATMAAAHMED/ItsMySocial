using AutoMapper;
using Dtos;
using ItsMySocialContext;
using ItsMySocialDomain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItsMySocial.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly socialDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(socialDbContext context,
            UserManager<User> userManager,
            IConfiguration configuration
            , SignInManager<User> signInManager,
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult>Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<User>(registerDto);
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (!result.Succeeded)
                {
                    if (result.Errors.Any(e => e.Code == "DublicateUserName"))
                    {
                        return BadRequest("email is already in use");
                    }
                    return BadRequest("error");
                }
                else
                    await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) 
            {
                return Problem($"somethoing went wrong in the {nameof(Register)}", statusCode: 500);

            }
        }
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody]LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user =await _userManager.FindByNameAsync(loginDto.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var token = new JwtSecurityToken(
                    signingCredentials : new SigningCredentials
                    (
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                        , SecurityAlgorithms.HmacSha256
                        )
                    , expires: DateTime.Now.AddDays(5)

                    );
                 return Ok (token);
            }
            return Unauthorized();

        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();

            return Ok();
        }


    }
}

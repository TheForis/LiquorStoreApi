using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace LiquorStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult UserLogIn(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    return BadRequest("Email and password required!");
                }
                else
                {
                    var result = _userService.LogInUser(email, password);
                    if (result is null) 
                    {
                        return StatusCode(StatusCodes.Status408RequestTimeout, "Error occured, please try again!");
                    }
                    else 
                    {
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser (CreateUserDto userDto)
        {
            try
            {
                return Ok("COngrats!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

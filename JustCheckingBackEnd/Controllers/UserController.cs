using JustCheckingDatabase.Services.Interfaces;
using JustCheckingDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using JustCheckingDatabase.Entities;

namespace JustCheckingAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        //[HttpGet]
        //public IActionResult GetUsers()
        //{
        //    return Ok(_userService.GetUsers());
        //}

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.PostUser(user);
        }

    }

}

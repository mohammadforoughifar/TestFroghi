using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auh_angular_netcore.DtoModels;
using Auh_angular_netcore.Entities;
using Auh_angular_netcore.ir.DTo;
using Auh_angular_netcore.ir.ViewModel;
using Auh_angular_netcore.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace Auh_angular_netcore.ir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


       // [AllowAnonymous]
        //[HttpPost("login")]
        //public User Login([FromBody] UserDto user)
        //{
        //    var User = _userService.Authenticate(user.Username, user.Password);

        //    return User;
        //}


       // [Authorize(Policy = "GetAllUser")]
        [HttpGet("all")]
        public IEnumerable<User> GetAllUser()
        {
            return _userService.GetAll();
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            CreateToken token= new  CreateToken();
            var log =  _userService.Login(login);
            if (log !=null)
            {
                log.Token= token.GenerateJwtToken(log);
              _userService.UpdateUser(log);
                
                return Ok(log);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetUserById")]
        public  User GetUserById(int id)
        {
            return  _userService.GetUserById(id);
        }


    }
}

using BLL;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransaltorApi.Helpers;
using TransaltorApi.Helpers.Services;

namespace TransaltorApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private BLL.TranslationBLL _BLL;

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            _BLL = new BLL.TranslationBLL();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);


            if (!user)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var users = await _userService.GetAll();
        //    return Ok(users);
        //}
    }
}

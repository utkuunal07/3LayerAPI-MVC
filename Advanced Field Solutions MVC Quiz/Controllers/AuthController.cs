using BLL;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransaltorApi.Controllers;
using TransaltorApi.Helpers.Services;

namespace Advanced_Field_Solutions_MVC_Quiz.Controllers
{
    public class AuthController : Controller
    {
        private  static IUserService _userService;

        private UsersController apiController = new UsersController(_userService);

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(string username, string password)
        {
            if (!String.IsNullOrEmpty(username))
            {
                IActionResult  auth=apiController.Authenticate(new AuthenticateModel
                {
                    Username = username,
                    Password = password
                
                });
                OkObjectResult okResult = auth as OkObjectResult;
                if (okResult != null && okResult.StatusCode==200)
                {
                    return View("~/Views/Home/Index.cshtml");

                }
                else
                {
                    ViewBag.Result = "Wrong username or password, check the T_ACCOUNTS table";
                }

            }


            return View();
        }
    }
}

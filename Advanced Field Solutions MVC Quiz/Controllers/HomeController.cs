using Advanced_Field_Solutions_MVC_Quiz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using TransaltorApi.Controllers;
using BLL.DbConnection;
using System.Configuration;

namespace Advanced_Field_Solutions_MVC_Quiz.Controllers
{
    public class HomeController : Controller
    {
        private TranslatorController apiController = new TranslatorController();
        private string conStr = DbConnectionString.GetConnString(ConfigurationManager.AppSettings["dbName"]);

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> TranslateText(string leetinput, string translation)
        {


            ViewBag.Translation = await apiController.TranslateText(leetinput, translation);
            ViewBag.Input = leetinput;
            ViewBag.Translator = translation;

            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
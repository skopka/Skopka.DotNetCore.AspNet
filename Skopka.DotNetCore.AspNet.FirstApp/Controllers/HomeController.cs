using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skopka.DotNetCore.AspNet.FirstApp.Models;
using System;
using System.Diagnostics;

namespace Skopka.DotNetCore.AspNet.FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HelloWorld()
        {
            SetHelloWorldGetViewBag();
            return View();
        }

        [HttpPost]
        public IActionResult HelloWorld(HelloWorldModel helloWorldModel)
        {
            SetHelloWorldPostViewBag(helloWorldModel);

            return View();
        }

        private void SetHelloWorldGetViewBag()
        {

            SetGreetingPhrase("Мир");
            SetDateTime();
        }

        private void SetHelloWorldPostViewBag(HelloWorldModel helloWorldModel = null)
        {
            if (helloWorldModel is null)
            {
                SetHelloWorldGetViewBag();
            }
            else
            {
                SetGreetingPhrase(ModelState.IsValid ? helloWorldModel.Name : "Незнакомец");
                SetDateTime();
            }

        }

        private void SetGreetingPhrase(string userName)
        {
            ViewBag.GreetingPhrase = GenerateGreetingPhrase(userName);
        }

        private void SetDateTime()
        {
            DateTime now = DateTime.Now;

            ViewBag.DateNow = now.ToLongDateString();
            ViewBag.TimeNow = now.ToLongTimeString();
        }

        private string GenerateGreetingPhrase(string userName) => $"Привет, {userName}!";

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

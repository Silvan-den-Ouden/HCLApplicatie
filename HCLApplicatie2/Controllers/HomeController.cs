using System.Diagnostics;
//using BusinessLayer;
using BusinessLayer.Collections;
using Microsoft.AspNetCore.Mvc;
using HCLApplicatie2.ViewModels;


namespace HCLApplicatie2.Controllers
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

        public IActionResult Schema()
        {
            return View();
        }

        public IActionResult Wedstrijden()
        {   
            return View();
        }
        public IActionResult Verslagen()
        {
            return View();
        }
        public IActionResult Galerij()
        {
            return View();
        }

        public IActionResult Privacy()
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
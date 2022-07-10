using CoreApp.Models;
using CoreService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDemoService _demoService;

        public HomeController(ILogger<HomeController> logger, IDemoService demoService)
        {
            _logger = logger;
            _demoService = demoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Render records of employee
        [HttpGet]
        public IActionResult Records()
        {
            var model = _demoService.GetStaticRecords();
            return View(model);
        }

        // Find records and render.
        [HttpPost]
        public IActionResult Records(string Name)
        {
            var records = _demoService.GetStaticRecords();
            var model = _demoService.FindRecordByName(records, Name);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details()
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

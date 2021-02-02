using MangoCrudWebApi.Core;
using MangoCrudWebApi.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MangoCrudWebApi.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoryService _CategoryService;


        public HomeController(ILogger<HomeController> logger)
        {
            IMongoDbSettings settings = new MongoDbSettings
            {
                Database = "DbDemoCategory",
                ConnectionString = "mongodb://localhost:27017",
                Collection = "Category"
            };
            this._CategoryService = new CategoryService(settings);
            _logger = logger;
        }

        public IActionResult Index()
        {

            var AllCategory = _CategoryService.GetAll();


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

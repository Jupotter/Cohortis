using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cohortis.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Cohortis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Welcome to Cohortis";

            var serverInfo = new ServerInfoViewModel()
            {
                Name = Environment.MachineName,
                Software = Environment.OSVersion.ToString(),
            };

            return View(serverInfo);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}

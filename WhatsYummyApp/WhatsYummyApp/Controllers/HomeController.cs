using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WhatsYummyApp.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult Index(string username = "username")
		{
			ViewData["Username"] = username;
			return View();
		}

		public IActionResult About(string name)
		{
			ViewData["Username"] = "Hello " + name;

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";
			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
    }
}

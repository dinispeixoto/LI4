using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhatsYummy.Models;
using Microsoft.EntityFrameworkCore;

namespace WhatsYummyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WhatsYummyContext _context;

        public HomeController(WhatsYummyContext context)
        {
            _context = context;
        }

        public IActionResult Index(string username = "username")
		{
			ViewData["Username"] = username;
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

        [HttpPost]
		public IActionResult About(string search_input)
		{
			ViewData["search_input"] = search_input;
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
        
        public IActionResult Search(string search)
        {
            string[] tags = search.Split(' ');
            List<Produto> prods = new List<Produto>();
            bool encontrou;
            foreach (var prod in _context.Produto)
            {
                encontrou = false;
                foreach (var tag in tags)
                {
                    if (encontrou) break;
                    foreach (var prodTag in prod.Tags)
                    {
                        if (tag.Equals(prodTag)) prods.Add(prod); encontrou = true; break;
                    }
                }
            }
            return View( _context.Produto.ToList());
        }
    }
}

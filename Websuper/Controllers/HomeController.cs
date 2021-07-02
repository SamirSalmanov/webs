using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Websuper.Data;
using Websuper.Models;
using Websuper.ViewModel;

namespace Websuper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel()
            {
                Sliders = _context.Sliders.Where(x => x.IsActive == true).ToList(),
                Services = _context.Services.Where(x => x.IsActive == true).ToList(),
                Galleries = _context.Galleries.Where(x => x.IsActive == true).Take(8).ToList(),
                Blogs = _context.Blogs.Where(x => x.IsActive == true).Take(3).ToList(),
                ConsultNow = _context.ConsultNows.Where(x => x.IsActive == true).FirstOrDefault(),
                OneBlog = _context.OneBlogs.Where(x => x.IsActive == true).FirstOrDefault(),
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            HomeViewModel vm = new HomeViewModel()
            {
                OneBlog = _context.OneBlogs.Where(x => x.IsActive == true).FirstOrDefault()
            };
            return View(vm);
        }
        public IActionResult Works()
        {
            HomeViewModel vm = new HomeViewModel()
            {
                Galleries = _context.Galleries.Where(x => x.IsActive == true).ToList()
            };
            return View(vm);
        }
        public IActionResult WhyWe()
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

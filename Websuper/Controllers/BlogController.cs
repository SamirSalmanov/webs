using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Websuper.Data;
using Websuper.ViewModel;

namespace Websuper.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly ApplicationDbContext _context;


        public BlogController(ILogger<BlogController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
                HomeViewModel vm = new HomeViewModel()
                {
                    Blog = _context.Blogs.Where(x=>x.ID == id).FirstOrDefault()
                };
      
            return View(vm);
        }
    }
}

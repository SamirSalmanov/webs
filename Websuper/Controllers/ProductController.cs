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
    
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductController(ILogger<ProductController> logger, ApplicationDbContext context)
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
                Gallery = _context.Galleries.FirstOrDefault(x => x.ID == id)
            };
            return View(vm);
        }
    }
}
    
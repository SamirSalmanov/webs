using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Websuper.Data;
using Websuper.Models;

namespace Websuper.Areas.admin.Controllers
{
    [Area("admin")]
    public class GalleriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public GalleriesController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: admin/Galleries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galleries.ToListAsync());
        }

        // GET: admin/Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: admin/Galleries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,ID,IsActive,IsDeleted,ModifiedOn")] Gallery gallery, IFormFile PhotoURL)
        {
            if (ModelState.IsValid)
            {
                string path = "/uploads/" + Guid.NewGuid() + PhotoURL.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    Path.Combine(Directory.GetCurrentDirectory(), "uploads", path);
                    await PhotoURL.CopyToAsync(fileStream);
                }
                gallery.PhotoURL = path;
                _context.Add(gallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gallery);
        }

        // GET: admin/Galleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(gallery);
        }

        // POST: admin/Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,ID,IsActive,IsDeleted,ModifiedOn")] Gallery gallery, IFormFile NewImg)
        {
            if (id != gallery.ID)
            {
                return NotFound();
            }
            if (NewImg != null)
            {
                string path = "/uploads/" + Guid.NewGuid() + NewImg.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    Path.Combine(Directory.GetCurrentDirectory(), "uploads", path);
                    await NewImg.CopyToAsync(fileStream);
                }
                gallery.PhotoURL = path;

            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryExists(gallery.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gallery);
        }

        // GET: admin/Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: admin/Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
            return _context.Galleries.Any(e => e.ID == id);
        }
    }
}

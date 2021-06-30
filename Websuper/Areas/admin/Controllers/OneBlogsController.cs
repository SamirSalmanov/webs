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
    public class OneBlogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public OneBlogsController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: admin/OneBlogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.OneBlogs.ToListAsync());
        }

        // GET: admin/OneBlogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneBlog = await _context.OneBlogs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oneBlog == null)
            {
                return NotFound();
            }

            return View(oneBlog);
        }

        // GET: admin/OneBlogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/OneBlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Description,ID,IsActive,IsDeleted,ModifiedOn")] OneBlog oneBlog, IFormFile PhotoURL)
        {
            if (ModelState.IsValid)
            {
                string path = "/uploads/" + Guid.NewGuid() + PhotoURL.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    Path.Combine(Directory.GetCurrentDirectory(), "uploads", path);
                    await PhotoURL.CopyToAsync(fileStream);
                }
                oneBlog.PhotoURL = path;
                _context.Add(oneBlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oneBlog);
        }

        // GET: admin/OneBlogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneBlog = await _context.OneBlogs.FindAsync(id);
            if (oneBlog == null)
            {
                return NotFound();
            }
            return View(oneBlog);
        }

        // POST: admin/OneBlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Description,ID,IsActive,IsDeleted,ModifiedOn")] OneBlog oneBlog)
        {
            if (id != oneBlog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oneBlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OneBlogExists(oneBlog.ID))
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
            return View(oneBlog);
        }

        // GET: admin/OneBlogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneBlog = await _context.OneBlogs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oneBlog == null)
            {
                return NotFound();
            }

            return View(oneBlog);
        }

        // POST: admin/OneBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oneBlog = await _context.OneBlogs.FindAsync(id);
            _context.OneBlogs.Remove(oneBlog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OneBlogExists(int id)
        {
            return _context.OneBlogs.Any(e => e.ID == id);
        }
    }
}

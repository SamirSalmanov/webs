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
    public class AdditionaliesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public AdditionaliesController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: admin/Additionalies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Additionaly.ToListAsync());
        }

        // GET: admin/Additionalies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionaly = await _context.Additionaly
                .FirstOrDefaultAsync(m => m.ID == id);
            if (additionaly == null)
            {
                return NotFound();
            }

            return View(additionaly);
        }

        // GET: admin/Additionalies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Additionalies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Icon,Title,Description,ID,IsActive,IsDeleted,ModifiedOn")] Additionaly additionaly, IFormFile Icon)
        {
            if (ModelState.IsValid)
            {
                string path = "/uploads/" + Guid.NewGuid() + Icon.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    Path.Combine(Directory.GetCurrentDirectory(), "uploads", path);
                    await Icon.CopyToAsync(fileStream);
                }
                additionaly.Icon = path;
                _context.Add(additionaly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(additionaly);
        }

        // GET: admin/Additionalies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionaly = await _context.Additionaly.FindAsync(id);
            if (additionaly == null)
            {
                return NotFound();
            }
            return View(additionaly);
        }

        // POST: admin/Additionalies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Icon,Title,Description,ID,IsActive,IsDeleted,ModifiedOn")] Additionaly additionaly)
        {
            if (id != additionaly.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(additionaly);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdditionalyExists(additionaly.ID))
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
            return View(additionaly);
        }

        // GET: admin/Additionalies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionaly = await _context.Additionaly
                .FirstOrDefaultAsync(m => m.ID == id);
            if (additionaly == null)
            {
                return NotFound();
            }

            return View(additionaly);
        }

        // POST: admin/Additionalies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var additionaly = await _context.Additionaly.FindAsync(id);
            _context.Additionaly.Remove(additionaly);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdditionalyExists(int id)
        {
            return _context.Additionaly.Any(e => e.ID == id);
        }
    }
}

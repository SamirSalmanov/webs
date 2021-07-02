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
    public class CountDownsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public CountDownsController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: admin/CountDowns
        public async Task<IActionResult> Index()
        {
            return View(await _context.CountDowns.ToListAsync());
        }

        // GET: admin/CountDowns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countDown = await _context.CountDowns
                .FirstOrDefaultAsync(m => m.ID == id);
            if (countDown == null)
            {
                return NotFound();
            }

            return View(countDown);
        }

        // GET: admin/CountDowns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/CountDowns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Icon,Counter,ID,IsActive,IsDeleted,ModifiedOn")] CountDown countDown)
        {
            if (ModelState.IsValid)
            {

                _context.Add(countDown);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countDown);
        }

        // GET: admin/CountDowns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countDown = await _context.CountDowns.FindAsync(id);
            if (countDown == null)
            {
                return NotFound();
            }
            return View(countDown);
        }

        // POST: admin/CountDowns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Icon,Counter,ID,IsActive,IsDeleted,ModifiedOn")] CountDown countDown)
        {
            if (id != countDown.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countDown);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountDownExists(countDown.ID))
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
            return View(countDown);
        }

        // GET: admin/CountDowns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countDown = await _context.CountDowns
                .FirstOrDefaultAsync(m => m.ID == id);
            if (countDown == null)
            {
                return NotFound();
            }

            return View(countDown);
        }

        // POST: admin/CountDowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countDown = await _context.CountDowns.FindAsync(id);
            _context.CountDowns.Remove(countDown);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountDownExists(int id)
        {
            return _context.CountDowns.Any(e => e.ID == id);
        }
    }
}

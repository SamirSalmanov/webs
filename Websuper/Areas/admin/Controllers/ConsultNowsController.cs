using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Websuper.Data;
using Websuper.Models;

namespace Websuper.Areas.admin.Controllers
{
    [Area("admin")]
    public class ConsultNowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultNowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: admin/ConsultNows
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsultNows.ToListAsync());
        }

        // GET: admin/ConsultNows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultNow = await _context.ConsultNows
                .FirstOrDefaultAsync(m => m.ID == id);
            if (consultNow == null)
            {
                return NotFound();
            }

            return View(consultNow);
        }

        // GET: admin/ConsultNows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/ConsultNows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,ID,IsActive,IsDeleted,ModifiedOn")] ConsultNow consultNow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultNow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultNow);
        }

        // GET: admin/ConsultNows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultNow = await _context.ConsultNows.FindAsync(id);
            if (consultNow == null)
            {
                return NotFound();
            }
            return View(consultNow);
        }

        // POST: admin/ConsultNows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,ID,IsActive,IsDeleted,ModifiedOn")] ConsultNow consultNow)
        {
            if (id != consultNow.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultNow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultNowExists(consultNow.ID))
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
            return View(consultNow);
        }

        // GET: admin/ConsultNows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultNow = await _context.ConsultNows
                .FirstOrDefaultAsync(m => m.ID == id);
            if (consultNow == null)
            {
                return NotFound();
            }

            return View(consultNow);
        }

        // POST: admin/ConsultNows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultNow = await _context.ConsultNows.FindAsync(id);
            _context.ConsultNows.Remove(consultNow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultNowExists(int id)
        {
            return _context.ConsultNows.Any(e => e.ID == id);
        }
    }
}

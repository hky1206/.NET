using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhienBansController : Controller
    {
        private readonly DoanmonhocContext _context;

        public PhienBansController(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: PhienBans
        public async Task<IActionResult> Index()
        {
              return _context.PhienBans != null ? 
                          View(await _context.PhienBans.ToListAsync()) :
                          Problem("Entity set 'DoanmonhocContext.PhienBans'  is null.");
        }

        // GET: PhienBans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhienBans == null)
            {
                return NotFound();
            }

            var phienBan = await _context.PhienBans
                .FirstOrDefaultAsync(m => m.IdPhienban == id);
            if (phienBan == null)
            {
                return NotFound();
            }

            return View(phienBan);
        }

        // GET: PhienBans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhienBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhienban,TenPhienBan")] PhienBan phienBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phienBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phienBan);
        }

        // GET: PhienBans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhienBans == null)
            {
                return NotFound();
            }

            var phienBan = await _context.PhienBans.FindAsync(id);
            if (phienBan == null)
            {
                return NotFound();
            }
            return View(phienBan);
        }

        // POST: PhienBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhienban,TenPhienBan")] PhienBan phienBan)
        {
            if (id != phienBan.IdPhienban)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phienBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhienBanExists(phienBan.IdPhienban))
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
            return View(phienBan);
        }

        // GET: PhienBans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhienBans == null)
            {
                return NotFound();
            }

            var phienBan = await _context.PhienBans
                .FirstOrDefaultAsync(m => m.IdPhienban == id);
            if (phienBan == null)
            {
                return NotFound();
            }

            return View(phienBan);
        }

        // POST: PhienBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhienBans == null)
            {
                return Problem("Entity set 'DoanmonhocContext.PhienBans'  is null.");
            }
            var phienBan = await _context.PhienBans.FindAsync(id);
            if (phienBan != null)
            {
                _context.PhienBans.Remove(phienBan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhienBanExists(int id)
        {
          return (_context.PhienBans?.Any(e => e.IdPhienban == id)).GetValueOrDefault();
        }
    }
}

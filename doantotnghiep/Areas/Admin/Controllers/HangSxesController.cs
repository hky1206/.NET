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
    public class HangSxesController : Controller
    {
        private readonly DoanmonhocContext _context;

        public HangSxesController(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: HangSxes
        public async Task<IActionResult> Index()
        {
              return _context.HangSxes != null ? 
                          View(await _context.HangSxes.ToListAsync()) :
                          Problem("Entity set 'DoanmonhocContext.HangSxes'  is null.");
        }

        // GET: HangSxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HangSxes == null)
            {
                return NotFound();
            }

            var hangSx = await _context.HangSxes
                .FirstOrDefaultAsync(m => m.IdHangsx == id);
            if (hangSx == null)
            {
                return NotFound();
            }

            return View(hangSx);
        }

        // GET: HangSxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HangSxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHangsx,Tenhangsanxuat")] HangSx hangSx)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangSx);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangSx);
        }

        // GET: HangSxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HangSxes == null)
            {
                return NotFound();
            }

            var hangSx = await _context.HangSxes.FindAsync(id);
            if (hangSx == null)
            {
                return NotFound();
            }
            return View(hangSx);
        }

        // POST: HangSxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHangsx,Tenhangsanxuat")] HangSx hangSx)
        {
            if (id != hangSx.IdHangsx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangSx);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangSxExists(hangSx.IdHangsx))
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
            return View(hangSx);
        }

        // GET: HangSxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HangSxes == null)
            {
                return NotFound();
            }

            var hangSx = await _context.HangSxes
                .FirstOrDefaultAsync(m => m.IdHangsx == id);
            if (hangSx == null)
            {
                return NotFound();
            }

            return View(hangSx);
        }

        // POST: HangSxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HangSxes == null)
            {
                return Problem("Entity set 'DoanmonhocContext.HangSxes'  is null.");
            }
            var hangSx = await _context.HangSxes.FindAsync(id);
            if (hangSx != null)
            {
                _context.HangSxes.Remove(hangSx);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangSxExists(int id)
        {
          return (_context.HangSxes?.Any(e => e.IdHangsx == id)).GetValueOrDefault();
        }
    }
}

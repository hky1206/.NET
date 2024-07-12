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
    public class DonViTinhsController : Controller
    {
        private readonly DoanmonhocContext _context;

        public DonViTinhsController(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: DonViTinhs
        public async Task<IActionResult> Index()
        {
              return _context.DonViTinhs != null ? 
                          View(await _context.DonViTinhs.ToListAsync()) :
                          Problem("Entity set 'DoanmonhocContext.DonViTinhs'  is null.");
        }

        // GET: DonViTinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DonViTinhs == null)
            {
                return NotFound();
            }

            var donViTinh = await _context.DonViTinhs
                .FirstOrDefaultAsync(m => m.IdDvt == id);
            if (donViTinh == null)
            {
                return NotFound();
            }

            return View(donViTinh);
        }

        // GET: DonViTinhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonViTinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDvt,TenDvt")] DonViTinh donViTinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donViTinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donViTinh);
        }

        // GET: DonViTinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DonViTinhs == null)
            {
                return NotFound();
            }

            var donViTinh = await _context.DonViTinhs.FindAsync(id);
            if (donViTinh == null)
            {
                return NotFound();
            }
            return View(donViTinh);
        }

        // POST: DonViTinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDvt,TenDvt")] DonViTinh donViTinh)
        {
            if (id != donViTinh.IdDvt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donViTinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonViTinhExists(donViTinh.IdDvt))
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
            return View(donViTinh);
        }

        // GET: DonViTinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DonViTinhs == null)
            {
                return NotFound();
            }

            var donViTinh = await _context.DonViTinhs
                .FirstOrDefaultAsync(m => m.IdDvt == id);
            if (donViTinh == null)
            {
                return NotFound();
            }

            return View(donViTinh);
        }

        // POST: DonViTinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DonViTinhs == null)
            {
                return Problem("Entity set 'DoanmonhocContext.DonViTinhs'  is null.");
            }
            var donViTinh = await _context.DonViTinhs.FindAsync(id);
            if (donViTinh != null)
            {
                _context.DonViTinhs.Remove(donViTinh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonViTinhExists(int id)
        {
          return (_context.DonViTinhs?.Any(e => e.IdDvt == id)).GetValueOrDefault();
        }
    }
}

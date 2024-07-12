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
    public class ThoiGianBaoHanhsController : Controller
    {
        private readonly DoanmonhocContext _context;

        public ThoiGianBaoHanhsController(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: ThoiGianBaoHanhs
        public async Task<IActionResult> Index()
        {
              return _context.ThoiGianBaoHanhs != null ? 
                          View(await _context.ThoiGianBaoHanhs.ToListAsync()) :
                          Problem("Entity set 'DoanmonhocContext.ThoiGianBaoHanhs'  is null.");
        }

        // GET: ThoiGianBaoHanhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ThoiGianBaoHanhs == null)
            {
                return NotFound();
            }

            var thoiGianBaoHanh = await _context.ThoiGianBaoHanhs
                .FirstOrDefaultAsync(m => m.IdTgbh == id);
            if (thoiGianBaoHanh == null)
            {
                return NotFound();
            }

            return View(thoiGianBaoHanh);
        }

        // GET: ThoiGianBaoHanhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThoiGianBaoHanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTgbh,ThoiGian")] ThoiGianBaoHanh thoiGianBaoHanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thoiGianBaoHanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thoiGianBaoHanh);
        }

        // GET: ThoiGianBaoHanhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ThoiGianBaoHanhs == null)
            {
                return NotFound();
            }

            var thoiGianBaoHanh = await _context.ThoiGianBaoHanhs.FindAsync(id);
            if (thoiGianBaoHanh == null)
            {
                return NotFound();
            }
            return View(thoiGianBaoHanh);
        }

        // POST: ThoiGianBaoHanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTgbh,ThoiGian")] ThoiGianBaoHanh thoiGianBaoHanh)
        {
            if (id != thoiGianBaoHanh.IdTgbh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thoiGianBaoHanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThoiGianBaoHanhExists(thoiGianBaoHanh.IdTgbh))
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
            return View(thoiGianBaoHanh);
        }

        // GET: ThoiGianBaoHanhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ThoiGianBaoHanhs == null)
            {
                return NotFound();
            }

            var thoiGianBaoHanh = await _context.ThoiGianBaoHanhs
                .FirstOrDefaultAsync(m => m.IdTgbh == id);
            if (thoiGianBaoHanh == null)
            {
                return NotFound();
            }

            return View(thoiGianBaoHanh);
        }

        // POST: ThoiGianBaoHanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ThoiGianBaoHanhs == null)
            {
                return Problem("Entity set 'DoanmonhocContext.ThoiGianBaoHanhs'  is null.");
            }
            var thoiGianBaoHanh = await _context.ThoiGianBaoHanhs.FindAsync(id);
            if (thoiGianBaoHanh != null)
            {
                _context.ThoiGianBaoHanhs.Remove(thoiGianBaoHanh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThoiGianBaoHanhExists(int id)
        {
          return (_context.ThoiGianBaoHanhs?.Any(e => e.IdTgbh == id)).GetValueOrDefault();
        }
    }
}

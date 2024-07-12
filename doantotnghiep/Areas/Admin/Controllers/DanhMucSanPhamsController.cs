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
    public class DanhMucSanPhamsController : Controller
    {
        private readonly DoanmonhocContext _context;

        public DanhMucSanPhamsController(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: DanhMucSanPhams
        public async Task<IActionResult> Index()
        {
              return _context.DanhMucSanPhams != null ? 
                          View(await _context.DanhMucSanPhams.ToListAsync()) :
                          Problem("Entity set 'DoanmonhocContext.DanhMucSanPhams'  is null.");
        }

        // GET: DanhMucSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DanhMucSanPhams == null)
            {
                return NotFound();
            }

            var danhMucSanPham = await _context.DanhMucSanPhams
                .FirstOrDefaultAsync(m => m.IdDanhmuc == id);
            if (danhMucSanPham == null)
            {
                return NotFound();
            }

            return View(danhMucSanPham);
        }

        // GET: DanhMucSanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanhMucSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhmuc,Tendanhmuc")] DanhMucSanPham danhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucSanPham);
        }

        // GET: DanhMucSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DanhMucSanPhams == null)
            {
                return NotFound();
            }

            var danhMucSanPham = await _context.DanhMucSanPhams.FindAsync(id);
            if (danhMucSanPham == null)
            {
                return NotFound();
            }
            return View(danhMucSanPham);
        }

        // POST: DanhMucSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhmuc,Tendanhmuc")] DanhMucSanPham danhMucSanPham)
        {
            if (id != danhMucSanPham.IdDanhmuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucSanPhamExists(danhMucSanPham.IdDanhmuc))
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
            return View(danhMucSanPham);
        }

        // GET: DanhMucSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DanhMucSanPhams == null)
            {
                return NotFound();
            }

            var danhMucSanPham = await _context.DanhMucSanPhams
                .FirstOrDefaultAsync(m => m.IdDanhmuc == id);
            if (danhMucSanPham == null)
            {
                return NotFound();
            }

            return View(danhMucSanPham);
        }

        // POST: DanhMucSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DanhMucSanPhams == null)
            {
                return Problem("Entity set 'DoanmonhocContext.DanhMucSanPhams'  is null.");
            }
            var danhMucSanPham = await _context.DanhMucSanPhams.FindAsync(id);
            if (danhMucSanPham != null)
            {
                _context.DanhMucSanPhams.Remove(danhMucSanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucSanPhamExists(int id)
        {
          return (_context.DanhMucSanPhams?.Any(e => e.IdDanhmuc == id)).GetValueOrDefault();
        }
    }
}

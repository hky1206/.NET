using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Arenas.Admin.Controllers
{
    [Area("Admin")]
    public class ChiTietPhieuNhapsController : Controller
    {
        private readonly DoanmonhocContext _context;

        public ChiTietPhieuNhapsController(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: ChiTietPhieuNhaps
        public async Task<IActionResult> Index()
        {
            var doanmonhocContext = _context.ChiTietPhieuNhaps.Include(c => c.IdPhieunhapNavigation).Include(c => c.MaSpNavigation);
            return View(await doanmonhocContext.ToListAsync());
        }

        // GET: ChiTietPhieuNhaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChiTietPhieuNhaps == null)
            {
                return NotFound();
            }

            var chiTietPhieuNhap = await _context.ChiTietPhieuNhaps
                .Include(c => c.IdPhieunhapNavigation)
                .Include(c => c.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.IdChitietphieunhap == id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            return View(chiTietPhieuNhap);
        }

        // GET: ChiTietPhieuNhaps/Create
        public IActionResult Create()
        {
            ViewData["IdPhieunhap"] = new SelectList(_context.PhieuNhaps, "IdPhieunhap", "IdPhieunhap");

            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp");

            return View();
        }

        // POST: ChiTietPhieuNhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChitietphieunhap,IdPhieunhap,MaSp,SoLuong,DonGia,ThanhTien,ThueNhap")] ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietPhieuNhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPhieunhap"] = new SelectList(_context.PhieuNhaps, "IdPhieunhap", "IdPhieunhap", chiTietPhieuNhap.IdPhieunhap);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietPhieuNhap.MaSp);
            return View(chiTietPhieuNhap);
        }

        // GET: ChiTietPhieuNhaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChiTietPhieuNhaps == null)
            {
                return NotFound();
            }

            var chiTietPhieuNhap = await _context.ChiTietPhieuNhaps.FindAsync(id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }
            ViewData["IdPhieunhap"] = new SelectList(_context.PhieuNhaps, "IdPhieunhap", "IdPhieunhap", chiTietPhieuNhap.IdPhieunhap);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietPhieuNhap.MaSp);
            return View(chiTietPhieuNhap);
        }

        // POST: ChiTietPhieuNhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChitietphieunhap,IdPhieunhap,MaSp,SoLuong,DonGia,ThanhTien,ThueNhap")] ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (id != chiTietPhieuNhap.IdChitietphieunhap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietPhieuNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietPhieuNhapExists(chiTietPhieuNhap.IdChitietphieunhap))
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
            ViewData["IdPhieunhap"] = new SelectList(_context.PhieuNhaps, "IdPhieunhap", "IdPhieunhap", chiTietPhieuNhap.IdPhieunhap);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietPhieuNhap.MaSp);
            return View(chiTietPhieuNhap);
        }

        // GET: ChiTietPhieuNhaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChiTietPhieuNhaps == null)
            {
                return NotFound();
            }

            var chiTietPhieuNhap = await _context.ChiTietPhieuNhaps
                .Include(c => c.IdPhieunhapNavigation)
                .Include(c => c.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.IdChitietphieunhap == id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            return View(chiTietPhieuNhap);
        }

        // POST: ChiTietPhieuNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChiTietPhieuNhaps == null)
            {
                return Problem("Entity set 'DoanmonhocContext.ChiTietPhieuNhaps'  is null.");
            }
            var chiTietPhieuNhap = await _context.ChiTietPhieuNhaps.FindAsync(id);
            if (chiTietPhieuNhap != null)
            {
                _context.ChiTietPhieuNhaps.Remove(chiTietPhieuNhap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietPhieuNhapExists(int id)
        {
          return (_context.ChiTietPhieuNhaps?.Any(e => e.IdChitietphieunhap == id)).GetValueOrDefault();
        }
    }
}

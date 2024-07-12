
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TonKhoesController : Controller
    {
        private readonly DoanmonhocContext _context;

        public TonKhoesController(DoanmonhocContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<TonKho> getTonKho()
        {
            var tonKhos = _context.ChiTietPhieuNhaps
         .GroupBy(c => c.MaSp)
         .Select(g => new TonKho
         {
             MaSp = g.Key,
             SoLuongTon = g.Sum(c => c.SoLuong),
             GiaNhap = g.Max(c => c.DonGia),
             MaSpNavigation = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == g.Key)
         });

            return Ok(tonKhos);
        }

        // GET: TonKhoes
        public async Task<IActionResult> Index()
        {
            var tonKhos = await _context.ChiTietPhieuNhaps
         .GroupBy(c => c.MaSp)
         .Select(g => new TonKho
         {
             MaSp = g.Key,
             SoLuongTon = g.Sum(c => c.SoLuong),
             GiaNhap = g.Max(c => c.DonGia),
             MaSpNavigation = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == g.Key)
         })
         .ToListAsync();

            return View(tonKhos);
        }

        // GET: TonKhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TonKhos == null)
            {
                return NotFound();
            }

            var tonKho = await _context.TonKhos
                .Include(t => t.IdChitietphieunhapNavigation)
                .FirstOrDefaultAsync(m => m.IdTonkho == id);
            if (tonKho == null)
            {
                return NotFound();
            }

            return View(tonKho);
        }

        // GET: TonKhoes/Create
        public IActionResult Create()
        {
            ViewData["IdChitietphieunhap"] = new SelectList(_context.ChiTietPhieuNhaps, "IdChitietphieunhap", "IdChitietphieunhap");
            return View();
        }

        // POST: TonKhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTonkho,IdChitietphieunhap,SoLuongTon,GiaNhap,MaSp")] TonKho tonKho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tonKho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChitietphieunhap"] = new SelectList(_context.ChiTietPhieuNhaps, "IdChitietphieunhap", "IdChitietphieunhap", tonKho.IdChitietphieunhap);
            return View(tonKho);
        }

        // GET: TonKhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TonKhos == null)
            {
                return NotFound();
            }

            var tonKho = await _context.TonKhos.FindAsync(id);
            if (tonKho == null)
            {
                return NotFound();
            }
            ViewData["IdChitietphieunhap"] = new SelectList(_context.ChiTietPhieuNhaps, "IdChitietphieunhap", "IdChitietphieunhap", tonKho.IdChitietphieunhap);
            return View(tonKho);
        }

        // POST: TonKhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTonkho,IdChitietphieunhap,SoLuongTon,GiaNhap,MaSp")] TonKho tonKho)
        {
            if (id != tonKho.IdTonkho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tonKho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TonKhoExists(tonKho.IdTonkho))
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
            ViewData["IdChitietphieunhap"] = new SelectList(_context.ChiTietPhieuNhaps, "IdChitietphieunhap", "IdChitietphieunhap", tonKho.IdChitietphieunhap);
            return View(tonKho);
        }

        // GET: TonKhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TonKhos == null)
            {
                return NotFound();
            }

            var tonKho = await _context.TonKhos
                .Include(t => t.IdChitietphieunhapNavigation)
                .FirstOrDefaultAsync(m => m.IdTonkho == id);
            if (tonKho == null)
            {
                return NotFound();
            }

            return View(tonKho);
        }

        // POST: TonKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TonKhos == null)
            {
                return Problem("Entity set 'DoanmonhocContext.TonKhos'  is null.");
            }
            var tonKho = await _context.TonKhos.FindAsync(id);
            if (tonKho != null)
            {
                _context.TonKhos.Remove(tonKho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TonKhoExists(int id)
        {
          return (_context.TonKhos?.Any(e => e.IdTonkho == id)).GetValueOrDefault();
        }
    }
}

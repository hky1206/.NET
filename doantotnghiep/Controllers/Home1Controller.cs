using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Home1Controller : Controller
    {
        private readonly DoanmonhocContext _context;

        public Home1Controller(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: Home1
        public async Task<IActionResult> Index()
        {
            var phuTungId = 1; // ID của danh mục "Phụ tùng"
            var danhMucPhuTung = _context.DanhMucSanPhams.FirstOrDefault(dm => dm.IdDanhmuc == phuTungId);
            ViewBag.CategoryName = danhMucPhuTung != null ? danhMucPhuTung.Tendanhmuc : "Phụ tùng";
            var sanPhams = await _context.SanPhams.ToListAsync();
            return View(sanPhams);


        }

        // GET: Home1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Home1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenSp,IdDvt,IdDanhmuc,IdHangsx,IdPhienban,IdThoigianbaohanh,ImageUrl")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanPham);
        }

        // GET: Home1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham);
        }

        // POST: Home1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSp,TenSp,IdDvt,IdDanhmuc,IdHangsx,IdPhienban,IdThoigianbaohanh,ImageUrl")] SanPham sanPham)
        {
            if (id != sanPham.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.MaSp))
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
            return View(sanPham);
        }

        private bool SanPhamExists(long maSp)
        {
            throw new NotImplementedException();
        }

        // GET: Home1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Home1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.MaSp == id);
        }
        // GET: Home1/ProductsByCategory/5
        public async Task<IActionResult> ProductsByCategory(int id)
        {
            var sanPhams = await _context.SanPhams
                .Where(sp => sp.IdDanhmuc == id)
                .ToListAsync();
            return View("Index", sanPhams);
        }

        // Phương thức để lấy danh sách danh mục sản phẩm
        public async Task<IActionResult> GetDanhMucPartial()
        {
            var danhMucs = await _context.DanhMucSanPhams.ToListAsync();
            return PartialView("_DanhMucPartial", danhMucs);
        }

    }
}

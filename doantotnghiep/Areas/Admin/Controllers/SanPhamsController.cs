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
    public class SanPhamsController : Controller
    {
        private readonly DoanmonhocContext _context;

        public SanPhamsController(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var doanmonhocContext = _context.SanPhams.Include(s => s.IdDanhmucNavigation).Include(s => s.IdDvtNavigation).Include(s => s.IdHangsxNavigation).Include(s => s.IdPhienbanNavigation).Include(s => s.IdThoigianbaohanhNavigation);
            return View(await doanmonhocContext.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.IdDanhmucNavigation)
                .Include(s => s.IdDvtNavigation)
                .Include(s => s.IdHangsxNavigation)
                .Include(s => s.IdPhienbanNavigation)
                .Include(s => s.IdThoigianbaohanhNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            // Replace 'yourDataSource' with your actual data source
            ViewBag.IdDanhmuc = new SelectList(_context.DanhMucSanPhams, "IdDanhmuc", "Tendanhmuc");
            ViewBag.IdDvt = new SelectList(_context.DonViTinhs, "IdDvt", "TenDvt");
            ViewBag.IdHangsx = new SelectList(_context.HangSxes, "IdHangsx", "Tenhangsanxuat");
            ViewBag.IdPhienban = new SelectList(_context.PhienBans, "IdPhienban", "TenPhienBan");
            ViewBag.IdTgbh = new SelectList(_context.ThoiGianBaoHanhs, "IdTgbh", "ThoiGian");
            // Initialize the view model with a list of one product
            var viewModel = new List<SanPham> { new SanPham() };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<SanPham> sanPhams, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                int lastMaSp = await _context.SanPhams.MaxAsync(s => s.MaSp);
                // Loop through the list of products and add them to the database
                string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }
                for (int i = 0; i < sanPhams.Count; i++)
                {
                    var sanPham = sanPhams[i];
                    var file = files[i];

                    if (file != null && file.Length > 0)
                    {
                        var filePath = Path.Combine("wwwroot/images", file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        sanPham.Imageurl = $"/{file.FileName}";
                    }

                    sanPham.MaSp = lastMaSp + 1;
                    _context.Add(sanPham);
                    lastMaSp++;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If the model state is not valid, repopulate the dropdowns and return the view
            ViewBag.IdDanhmuc = new SelectList(_context.DanhMucSanPhams, "IdDanhmuc", "Tendanhmuc");
            ViewBag.IdDvt = new SelectList(_context.DonViTinhs, "IdDvt", "TenDvt");
            ViewBag.IdHangsx = new SelectList(_context.HangSxes, "IdHangsx", "Tenhangsanxuat");
            ViewBag.IdPhienban = new SelectList(_context.PhienBans, "IdPhienban", "TenPhienBan");
            ViewBag.IdTgbh = new SelectList(_context.ThoiGianBaoHanhs, "IdThoigianbaohanh", "ThoiGian");
            return View(sanPhams);
        }


        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["IdDanhmuc"] = new SelectList(_context.DanhMucSanPhams, "IdDanhmuc", "Tendanhmuc", sanPham.IdDanhmuc);
            ViewData["IdDvt"] = new SelectList(_context.DonViTinhs, "IdDvt", "TenDvt", sanPham.IdDvt);
            ViewData["IdHangsx"] = new SelectList(_context.HangSxes, "IdHangsx", "Tenhangsanxuat", sanPham.IdHangsx);
            ViewData["IdPhienban"] = new SelectList(_context.PhienBans, "IdPhienban", "TenPhienBan", sanPham.IdPhienban);
            ViewData["IdTgbh"] = new SelectList(_context.ThoiGianBaoHanhs, "IdTgbh", "ThoiGian", sanPham.IdThoigianbaohanh);

            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSp,TenSp,IdDvt,IdDanhmuc,IdHangsx,IdPhienban,IdTgbh,Imageurl,Gia")] SanPham sanPham, IFormFile file)
        {
            if (id != sanPham.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot/images", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    sanPham.Imageurl = $"/images/{file.FileName}";
                }

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
            ViewData["IdDanhmuc"] = new SelectList(_context.DanhMucSanPhams, "IdDanhmuc", "IdDanhmuc", sanPham.IdDanhmuc);
            ViewData["IdDvt"] = new SelectList(_context.DonViTinhs, "IdDvt", "IdDvt", sanPham.IdDvt);
            ViewData["IdHangsx"] = new SelectList(_context.HangSxes, "IdHangsx", "IdHangsx", sanPham.IdHangsx);
            ViewData["IdPhienban"] = new SelectList(_context.PhienBans, "IdPhienban", "IdPhienban", sanPham.IdPhienban);
            ViewData["IdTgbh"] = new SelectList(_context.ThoiGianBaoHanhs, "IdThoigianbaohanh", "IdTgbh", sanPham.IdThoigianbaohanh);

            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.IdDanhmucNavigation)
                .Include(s => s.IdDvtNavigation)
                .Include(s => s.IdHangsxNavigation)
                .Include(s => s.IdPhienbanNavigation)
                .Include(s => s.IdThoigianbaohanhNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SanPhams == null)
            {
                return Problem("Entity set 'DoanmonhocContext.SanPhams'  is null.");
            }
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
          return (_context.SanPhams?.Any(e => e.MaSp == id)).GetValueOrDefault();
        }
    }
}

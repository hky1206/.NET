using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhieuNhapsController : Controller
    {
        private readonly DoanmonhocContext _context;
        public PhieuNhapsController(DoanmonhocContext context)
        {
            _context = context;
            
        }

        // GET: PhieuNhaps
        public async Task<IActionResult> Index()
        {
            var doanmonhocContext = _context.PhieuNhaps
                .Include(p => p.MaNccNavigation)
                .Include(p => p.IdNguoidungNavigation);

            // Chuyển dữ liệu thành danh sách và xử lý các giá trị null trước khi truyền vào view
            var phieuNhaps = await doanmonhocContext.ToListAsync();
            return View(phieuNhaps);
        }


        // GET: PhieuNhaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhieuNhaps == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhaps
                .Include(p => p.MaNccNavigation)
                .Include(p => p.IdNguoidungNavigation)
                .FirstOrDefaultAsync(m => m.IdPhieunhap == id);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            // Lấy toàn bộ chi tiết phiếu xuất có cùng IdPhieuxuat
            var chiTietPhieuNhap = await _context.ChiTietPhieuNhaps
                                .Include(ct => ct.MaSpNavigation)
                .Where(ct => ct.IdPhieunhap == id)
                .ToListAsync();

            // Thêm chi tiết phiếu xuất vào ViewData
            ViewData["ChiTietPhieuNhap"] = chiTietPhieuNhap;

            return View(phieuNhap);
        }

        // GET: PhieuNhaps/Create
        public IActionResult Create(int id)
        {
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "TenNcc");

            ViewData["MaNv"] = new SelectList(_context.NguoiDungs, "IdNguoidung", "Hoten");

            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "TenSp");

            DaTa2 daTa2 = new DaTa2();

            daTa2.chiTietPhieuNhaps.Add(new ChiTietPhieuNhap() { IdChitietphieunhap = 1 });

            var sanPhamList = _context.SanPhams.Select(sp => new SelectListItem { Value = sp.MaSp.ToString(), Text = sp.TenSp }).ToList();

            // Đưa danh sách sản phẩm vào ViewBag hoặc ViewData

            ViewData["SanPhamList"] = sanPhamList;
            return View("Create", daTa2);
        }

        // POST: PhieuNhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DaTa2 daTa2)
        {
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", daTa2.PhieuNhap.MaNcc);

            ViewData["MaNv"] = new SelectList(_context.NguoiDungs, "IdNguoidung", "IdNguoidung", daTa2.PhieuNhap.IdNguoidung);


            var maSpList = await _context.SanPhams.Select(sp => sp.MaSp).ToListAsync();

            ViewData["MaSp"] = new SelectList(maSpList);
            
            if (daTa2.PhieuNhap.IdPhieunhap == 0)
            {
                // Trường hợp IdPhieuxuat chưa được khởi tạo, thực hiện thêm mới
                _context.Add(daTa2.PhieuNhap);

                // Lưu thay đổi để có được IdPhieuxuat mới tạo
                await _context.SaveChangesAsync();

                // Sử dụng IdPhieuxuat mới để thiết lập cho ChiTietPhieuXuat
                foreach (var chiTiet in daTa2.chiTietPhieuNhaps)
                {
                    chiTiet.IdPhieunhap = daTa2.PhieuNhap.IdPhieunhap;

                    _context.Add(chiTiet);
                }

                // Lưu thêm ChiTietPhieuXuat
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Trường hợp IdPhieuxuat đã được khởi tạo, có thể xử lý theo ý của bạn
                // ...

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PhieuNhaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhieuNhaps == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhaps.FindAsync(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", phieuNhap.MaNcc);
            ViewData["MaNv"] = new SelectList(_context.NguoiDungs, "MaNv", "MaNv", phieuNhap.IdNguoidung);
            return View(phieuNhap);
        }

        // POST: PhieuNhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhieunhap,MaPN,MaNv,NgayNhap,MaNcc,SoPhieuNhap")] PhieuNhap phieuNhap)
        {
            if (id != phieuNhap.IdPhieunhap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuNhapExists(phieuNhap.IdPhieunhap))
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
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", phieuNhap.MaNcc);
            ViewData["MaNv"] = new SelectList(_context.NguoiDungs, "MaNv", "MaNv", phieuNhap.IdNguoidung);
            return View(phieuNhap);
        }

        // GET: PhieuNhaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhieuNhaps == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhaps
                .Include(p => p.MaNccNavigation)
                .Include(p => p.IdNguoidungNavigation)
                .FirstOrDefaultAsync(m => m.IdPhieunhap == id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            return View(phieuNhap);
        }

        // POST: PhieuNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhieuNhaps == null)
            {
                return Problem("Entity set 'DoanmonhocContext.PhieuNhaps'  is null.");
            }
            var phieuNhap = await _context.PhieuNhaps.FindAsync(id);
            if (phieuNhap != null)
            {
                _context.PhieuNhaps.Remove(phieuNhap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuNhapExists(int id)
        {
          return (_context.PhieuNhaps?.Any(e => e.IdPhieunhap == id)).GetValueOrDefault();
        }
    }
}

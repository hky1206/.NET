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
    public class PhieuXuatsController : Controller
    {
        private readonly DoanmonhocContext _context;

        public PhieuXuatsController(DoanmonhocContext context)
        {
            _context = context;
        }

        // GET: PhieuXuats
        public async Task<IActionResult> Index()
        {
            var doanmonhocContext = _context.PhieuXuats.Include(p => p.IdKhuyenmaiNavigation).Include(p => p.MaKhNavigation).Include(p => p.IdNguoidungNavigation);
            return View(await doanmonhocContext.ToListAsync());
        }

        // GET: PhieuXuats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhieuXuats == null)
            {
                return NotFound();
            }

            var phieuXuat = await _context.PhieuXuats
                .Include(p => p.IdKhuyenmaiNavigation)
                .Include(p => p.MaKhNavigation)
                .Include(p => p.IdNguoidungNavigation)
                .FirstOrDefaultAsync(m => m.IdPhieuxuat == id);

            if (phieuXuat == null)
            {
                return NotFound();
            }

            // Lấy toàn bộ chi tiết phiếu xuất có cùng IdPhieuxuat
            var chiTietPhieuXuat = await _context.ChiTietPhieuXuats
                .Include(ct => ct.MaSpNavigation)
                .Where(ct => ct.IdPhieuxuat == id)
                .ToListAsync();

            // Thêm chi tiết phiếu xuất vào ViewData
            ViewData["ChiTietPhieuXuat"] = chiTietPhieuXuat;

            return View(phieuXuat);
        }

        // GET: PhieuXuats/Create
        public IActionResult Create(int id)
        {
            ViewData["IdKhuyenmai"] = new SelectList(_context.KhuyenMais, "IdKhuyenmai", "TenKhuyenMai");
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "TenKh");
            ViewData["IdNguoidung"] = new SelectList(_context.NguoiDungs, "IdNguoidung", "Hoten");
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "TenSp");
            DaTa daTa = new DaTa();
            daTa.chiTietPhieuXuats.Add(new ChiTietPhieuXuat() { IdChitietphieuxuat = 1 });
            // Truy vấn để lấy danh sách sản phẩm từ bảng SanPham
            var sanPhamList = _context.SanPhams.Select(sp => new SelectListItem { Value = sp.MaSp.ToString(), Text = sp.TenSp }).ToList();

            // Đưa danh sách sản phẩm vào ViewBag hoặc ViewData
            ViewData["SanPhamList"] = sanPhamList;

           
            return View("Create", daTa);

        }

        // POST: PhieuXuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: PhieuXuats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DaTa daTa)
        {
            ViewData["IdKhuyenmai"] = new SelectList(_context.KhuyenMais, "IdKhuyenmai", "IdKhuyenmai", daTa.PhieuXuat.IdKhuyenmai);
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh", daTa.PhieuXuat.MaKh);
            ViewData["IdNguoidung"] = new SelectList(_context.NguoiDungs, "IdNguoidung", "IdNguoidung", daTa.PhieuXuat.IdNguoidungNavigation);

            var maSpList = await _context.SanPhams.Select(sp => sp.MaSp).ToListAsync();
            ViewData["MaSp"] = new SelectList(maSpList);

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (daTa.PhieuXuat.IdPhieuxuat == 0)
                    {
                        _context.Add(daTa.PhieuXuat);
                        await _context.SaveChangesAsync();

                        foreach (var chiTiet in daTa.chiTietPhieuXuats)
                        {
                            chiTiet.IdPhieuxuat = daTa.PhieuXuat.IdPhieuxuat;

                            var tonKho = await _context.TonKhos.FirstOrDefaultAsync(tk => tk.MaSp == chiTiet.MaSp);
                            if (tonKho != null)
                            {
                                if (tonKho.SoLuongTon < chiTiet.Soluong)
                                {
                                    ModelState.AddModelError("", "Số lượng tồn kho không đủ để xuất.");
                                    await transaction.RollbackAsync();
                                    return View(daTa);
                                }

                                tonKho.SoLuongTon -= chiTiet.Soluong;
                                _context.Update(tonKho);

                                _context.Add(chiTiet); // Di chuyển phần này vào trong điều kiện
                            }
                            else
                            {
                                ModelState.AddModelError("", "Không tìm thấy sản phẩm trong tồn kho.");
                                await transaction.RollbackAsync();
                                return View(daTa);
                            }
                        }

                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Xử lý trường hợp khác (nếu cần)
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError("", "Có lỗi xảy ra khi xuất hàng: " + ex.Message);
                    return View(daTa);
                }
            }
        }






        // POST: PhieuXuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhieuxuat,SoPhieuXuat,MaNv,NgayXuat,MaKh,IdKhuyenmai")] PhieuXuat phieuXuat)
        {
            if (id != phieuXuat.IdPhieuxuat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuXuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuXuatExists(phieuXuat.IdPhieuxuat))
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
            ViewData["IdKhuyenmai"] = new SelectList(_context.KhuyenMais, "IdKhuyenmai", "IdKhuyenmai", phieuXuat.IdKhuyenmai);
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh", phieuXuat.MaKh);
            ViewData["IdNguoidung"] = new SelectList(_context.NguoiDungs, "IdNguoidung", "IdNguoidung", phieuXuat.IdNguoidungNavigation);
            return View(phieuXuat);
        }

        // GET: PhieuXuats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhieuXuats == null)
            {
                return NotFound();
            }

            var phieuXuat = await _context.PhieuXuats
                .Include(p => p.IdKhuyenmaiNavigation)
                .Include(p => p.MaKhNavigation)
                .Include(p => p.IdNguoidungNavigation)
                .FirstOrDefaultAsync(m => m.IdPhieuxuat == id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            return View(phieuXuat);
        }

        // POST: PhieuXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhieuXuats == null)
            {
                return Problem("Entity set 'DoanmonhocContext.PhieuXuats'  is null.");
            }
            var phieuXuat = await _context.PhieuXuats.FindAsync(id);
            if (phieuXuat != null)
            {
                _context.PhieuXuats.Remove(phieuXuat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuXuatExists(int id)
        {
          return (_context.PhieuXuats?.Any(e => e.IdPhieuxuat == id)).GetValueOrDefault();
        }
    }
}

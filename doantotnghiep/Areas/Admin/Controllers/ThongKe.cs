using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKe : Controller
    {
        private readonly DoanmonhocContext _context;

        public ThongKe(DoanmonhocContext context)
        {
            _context = context;
        }

        public IActionResult ThongKeSanPhamNhapXuatTuNgayDenNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var data = _context.ChiTietPhieuXuats
                .Where(ct => ct.IdPhieuxuatNavigation.NgayXuat.Date >= ngayBatDau.Date && ct.IdPhieuxuatNavigation.NgayXuat.Date <= ngayKetThuc.Date)
                .Include(ct => ct.IdPhieuxuatNavigation)
                    .ThenInclude(px => px.ChiTietPhieuXuats)
                    .Include(ct => ct.MaSpNavigation)
                .ToList();

            return PartialView("ThongKeSanPhamNhapXuatTuNgayDenNgay", data);
        }



        public IActionResult ChonNgay()
        {
            return View(new DateTimeRangeViewModel());
        }
    }
}

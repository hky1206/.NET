using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeNhap : Controller
    {
        private readonly DoanmonhocContext _context;
        public ThongKeNhap(DoanmonhocContext context)
        {
_context = context;
        }
        public ActionResult ThongKeSanPhamNhap(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var data = _context.ChiTietPhieuNhaps
                .Where(ct => ct.IdPhieunhapNavigation.NgayNhap.Date >= ngayBatDau.Date && ct.IdPhieunhapNavigation.NgayNhap.Date <= ngayKetThuc.Date)
                .Include(ct => ct.IdPhieunhapNavigation)
                    .ThenInclude(pn => pn.ChiTietPhieuNhaps)
                    .Include(ct => ct.MaSpNavigation)
                .ToList();
            return PartialView("ThongKeSanPhamNhap", data);
        }
        public IActionResult ChonNgayNhap()
        {
            return View(new DateTimeRangeViewModel());
        }
    }
}

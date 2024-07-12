using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2   .Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    //[Area("Admin")]
    public class HomeController : Controller
    {
        
        private readonly DoanmonhocContext _context;
        public HomeController(DoanmonhocContext context)
        {
            _context = context ;
                
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

//        [HttpPost]
//        public async Task<IActionResult> Login(NhanVien nhanVien, string returnUrl)
//        {
//            var flag = false;
//            if (ModelState.IsValid)
//            {
//                var taikhoanForm = nhanVien.TenDangNhap;
//                var matkhauForm = nhanVien.MatKhau;
//                var taikhoanCheck = _context.NguoiDungs.SingleOrDefault(x => x.IdDangnhapNavigation.TenDangnhap.Equals(taikhoanForm) && x.IdDangnhapNavigation.MatKhau.Equals(matkhauForm));
//                var us = _context.NguoiDungs.Where(x => x.IdDangnhapNavigation.TenDangnhap == taikhoanForm && x.IdDangnhapNavigation.MatKhau == matkhauForm).ToList();

//                if (us.Count > 0)
//                {
//                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

//                    if (nhanVien.TenDangNhap == "admin" && nhanVien.MatKhau == "admin")
//                    {
//                        identity.AddClaim(new Claim(ClaimTypes.Name, nhanVien.TenDangNhap));
//                        identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
//                    }
//                    else
//                    {
//                        identity.AddClaim(new Claim(ClaimTypes.Name, nhanVien.TenDangNhap));
//                        identity.AddClaim(new Claim(ClaimTypes.Role, us.First().));
//                    }

//                    var principal = new ClaimsPrincipal(identity);

//                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
//                    {
//                        IsPersistent = true, // Sử dụng 'true' nếu bạn muốn xác thực lâu dài
//                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20) // Điều chỉnh thời gian hết hạn theo nhu cầu của bạn
//                    });

//                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
//                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
//                    {
//                        return Redirect(returnUrl);
//                    }
//                    else
//                    {
//                        HttpContext.Session.SetString("Quyen", us.FirstOrDefault(x => x.MaNv == us.First().MaNv).ToString());
//                        return Redirect("~/Home/Index");
//                    }
//                }
//                else
//                {
//                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
//                }
//            }

//            return View();
//        }
    }
}
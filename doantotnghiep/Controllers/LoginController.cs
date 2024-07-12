using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        private readonly DoanmonhocContext _context;

        public LoginController(DoanmonhocContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            var user = _context.Logins.FirstOrDefault(u => u.TenDangnhap == model.TenDangnhap && u.MatKhau == model.MatKhau);
            if (user != null)
            {
                // Đăng nhập thành công, thực hiện hành động tiếp theo, chẳng hạn chuyển hướng đến trang chính
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }
            return View("/");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Login model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem người dùng đã tồn tại chưa
                var existingUser = _context.Logins.FirstOrDefault(u => u.TenDangnhap == model.TenDangnhap);
                if (existingUser == null)
                {
                    // Thêm người dùng mới vào cơ sở dữ liệu
                    _context.Logins.Add(model);
                    _context.SaveChanges();
                    // Đăng nhập người dùng ngay sau khi đăng ký thành công (tùy chọn)
                    // Chuyển hướng đến trang chính hoặc trang đăng nhập
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username already exists.");
                }
            }
            return View(model);
        }
    }
}
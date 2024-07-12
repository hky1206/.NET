using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private readonly DoanmonhocContext _context;
        public OrderController(DoanmonhocContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            return _context.Orders != null ?
                          View(await _context.Orders.ToListAsync()) :
                          Problem("Entity set 'DoanmonhocContext.DonViTinhs'  is null.");
        }

        // GET: Order/Details/5
        public async Task<ActionResult> Detail(int id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Lấy toàn bộ chi tiết phiếu xuất có cùng IdPhieuxuat
            var orderdetail = await _context.OrderDetail
                .Include(ct => ct.Id)
                .Where(ct => ct.Id == id)
                .ToListAsync();

            // Thêm chi tiết phiếu xuất vào ViewData
            ViewData["OrderDetail"] = orderdetail;

            return View(orderdetail);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ViewModel;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
	public class CartController : Controller
	{
		private readonly DoanmonhocContext _context;
		public CartController(DoanmonhocContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemViewModel cartItemViewModel = new()
			{
				CartItems = cartItems,
				GrandTotal = cartItems.Sum(x => x.Quantity * x.Price),
			};

			return View(cartItemViewModel);
		}

		public async Task<IActionResult> Add(int id)
		{
			SanPham sanPham = await _context.SanPhams.FindAsync(id);
			if (sanPham == null)
			{
				// Xử lý khi sản phẩm không tìm thấy
				return NotFound();
			}

			List<CartItemModel> carts = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemModel cartItem = carts.Where(c => c.ProductId == id).FirstOrDefault();

			if (cartItem == null)
			{
				carts.Add(new CartItemModel(sanPham));
			}
			else
			{
				cartItem.Quantity += 1;
			}

			HttpContext.Session.SetJson("Cart", carts);

			// Kiểm tra và xử lý trường hợp Referer header bị null
			string referer = Request.Headers["Referer"].ToString();
			if (string.IsNullOrEmpty(referer))
			{
				return RedirectToAction("Index");
			}
			TempData["success"] = "Đã thêm sản phẩm vào giỏ hàng";
			return Redirect(referer);
		}
		public async Task<IActionResult> Decrease(int Id)
		{
			List<CartItemModel> carts = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
			CartItemModel cartItem = carts.Where(c => c.ProductId==Id).FirstOrDefault();
			if(cartItem.Quantity > 1)
			{
				--cartItem.Quantity;
			}	
			else
			{
				carts.RemoveAll(p =>p.ProductId == Id);
			}
			if(carts.Count ==0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", carts);
			}
			

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Increase(int Id)
		{
			List<CartItemModel> carts = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
			CartItemModel cartItem = carts.Where(c => c.ProductId == Id).FirstOrDefault();
			if (cartItem.Quantity >= 1)
			{
				++cartItem.Quantity;
			}
			else
			{
				carts.RemoveAll(p => p.ProductId == Id);
			}
			if (carts.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", carts);
			}

            TempData["success"] = "Đã xoá số lượng sản phẩm trong giỏ hàng";
            return RedirectToAction("Index");
		}
		public async Task<IActionResult> Remove(int Id)
		{
			List<CartItemModel> carts = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
			carts.RemoveAll(p =>p.ProductId == Id);
			if(carts.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", carts);
			}
            TempData["success"] = "Đã xoá sản phẩm khỏi giỏ hàng";
            return RedirectToAction("Index");
		}
		public async Task<IActionResult> Clear() {
			HttpContext.Session.Remove("Cart");
            TempData["success"] = "Đã xoá toàn bộ giỏ hàng";
            return RedirectToAction("Index");
		}

	}
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.Models.ViewModel;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
	public class CheckoutController : Controller
	{
		private readonly DoanmonhocContext _context;

		private readonly OrderRepository _orderRepository;

		public CheckoutController(DoanmonhocContext context, OrderRepository orderRepository)
		{
			_context = context;
			_orderRepository = orderRepository;
		}
        // GET: /Checkout/CheckoutCash
        public IActionResult CheckoutCash()
        {
            // Khởi tạo model với giá trị mặc định cho TotalAmount
            var model = new CheckoutViewmodel
            {
                TotalAmount = 0 // Giá trị mặc định
            };
            return View(model);
        }


        // POST: /Checkout/CheckoutCash
        [HttpPost]
        public IActionResult CheckoutCash(CheckoutViewmodel checkoutViewModel)
        {
            if (checkoutViewModel == null)
            {
                ModelState.AddModelError("", "Model không hợp lệ");
                return View(checkoutViewModel);
            }

            if (ModelState.IsValid)
            {
                var cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
                if (cartItems == null || !cartItems.Any())
                {
                    ModelState.AddModelError("", "Giỏ hàng của bạn đang trống");
                    return View(checkoutViewModel);
                }

                //// Tính tổng số tiền từ danh sách cartItems
                //decimal totalAmount = cartItems.Sum(item => item.Price * item.Quantity);

                // Tạo đơn hàng
                var order = new OrderModel
                {
                    OrderCode = GenerateOrderCode(),
                    UserName = checkoutViewModel.FullName,
                    CreateTime = DateTime.Now,
                    Status = 1, // Trạng thái đơn hàng mới
                    Address = checkoutViewModel.Address,
                    Total = (int)totalAmount
                };

                // Lưu thông tin đơn hàng vào cơ sở dữ liệu
                _context.Orders.Add(order);
                _context.SaveChanges(); // Lưu đơn hàng vào cơ sở dữ liệu trước

                // Tạo các chi tiết đơn hàng và lưu vào cơ sở dữ liệu
                foreach (var item in cartItems)
                {
                    var orderDetails = new OrderDetails
                    {
                        OrderCode = order.OrderCode, // Sử dụng mã đơn hàng mới tạo
                        ProductId = item.ProductId,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        UserName = order.UserName, // Thêm UserName từ OrderModel
                        OrderModelId = order.Id // Sử dụng Id của OrderModel đã lưu
                    };

                    // Lưu chi tiết đơn hàng vào cơ sở dữ liệu
                    _context.OrderDetail.Add(orderDetails);
                }

                _context.SaveChanges(); // Lưu các chi tiết đơn hàng vào cơ sở dữ liệu
                checkoutViewModel.TotalAmount = totalAmount;

                // Xóa giỏ hàng sau khi đặt hàng thành công
                HttpContext.Session.Remove("Cart");

                // Redirect hoặc trả về view kết quả thanh toán
                return RedirectToAction("PaymentSuccess");
            }

            // Nếu dữ liệu không hợp lệ, hiển thị lại form
            return View(checkoutViewModel);
        }




        private string GenerateOrderCode()
{
    // Thực hiện logic để tạo mã đơn hàng ở đây
    // Ví dụ: có thể sử dụng ngày giờ hiện tại và một chuỗi ngẫu nhiên để tạo mã đơn hàng
    string orderCode = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999);
    return orderCode;
}

	}

}

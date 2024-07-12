using WebApplication2.Models;

namespace WebApplication2.Repository
{
	public interface IOrderRepository
	{
		void Create(OrderModel order);
		// Các phương thức khác cần thiết cho việc quản lý đơn hàng
	}

	public class OrderRepository : IOrderRepository
	{
		private readonly DoanmonhocContext _context;

		public OrderRepository(DoanmonhocContext context)
		{
			_context = context;
		}

		public void Create(OrderModel order)
		{
			_context.Orders.Add(order);
			_context.SaveChanges();
		}

		// Cài đặt các phương thức khác của IOrderRepository nếu cần
	}
}

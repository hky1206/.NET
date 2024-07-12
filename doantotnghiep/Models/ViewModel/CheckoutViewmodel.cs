namespace WebApplication2.Models.ViewModel
{
	public class CheckoutViewmodel
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

        public decimal TotalAmount { get; set; } = 0;
        // Thêm thông tin địa chỉ giao hàng
        public string Address { get; set; }
	}
}

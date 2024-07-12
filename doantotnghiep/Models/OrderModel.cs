namespace WebApplication2.Models
{
	public class OrderModel
	{
		public int Id { get; set; }
		public string OrderCode { get; set; }
		public string UserName { get; set; }
		public DateTime CreateTime { get; set; }
		public int Status { get; set; }
		public string Address { get; set; }

        public int Total { get; set; }



        public ICollection<OrderDetails> OrderDetails { get; set; }


	}
}

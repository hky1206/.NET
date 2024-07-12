using System.Drawing;

namespace WebApplication2.Models
{
    public class CartItemModel
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total
        {
            get
            {
                return Price * Quantity;
            }

        }
        public string Image { get; set; }

        public CartItemModel()
        {

        }
        public CartItemModel(SanPham sanPham)
        {
            ProductId = sanPham.MaSp;
            ProductName = sanPham.TenSp;
            Price = (decimal)sanPham.Gia;
            Quantity = 1;
            Image = sanPham.Imageurl;
        }
    }
}


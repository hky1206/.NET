namespace WebApplication2.Models
{
    public class DaTa2
    {
        public PhieuNhap PhieuNhap { get; set; }
        public List<ChiTietPhieuNhap> chiTietPhieuNhaps { get; set; }
        public DaTa2()
        {
            chiTietPhieuNhaps = new List<ChiTietPhieuNhap>();
        }
    }
}

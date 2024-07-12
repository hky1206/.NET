namespace WebApplication2.Models
{
    public class DaTa
    {
            public PhieuXuat PhieuXuat { get; set; }
            public List<ChiTietPhieuXuat> chiTietPhieuXuats { get; set; }
            public List<SanPham> SanPhams { get; set; }
        public DaTa()
        {
            chiTietPhieuXuats = new List<ChiTietPhieuXuat>();
        }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class PhieuXuat
{
    public int IdPhieuxuat { get; set; }

    public int SoPhieuXuat { get; set; }

    public int? IdNguoidung { get; set; }

    public DateTime NgayXuat { get; set; }

    public int? MaKh { get; set; }

    public int? IdKhuyenmai { get; set; }

    public int? TongTien { get; set; }

    public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; } = new List<ChiTietPhieuXuat>();

    public virtual KhuyenMai? IdKhuyenmaiNavigation { get; set; }

    public virtual NguoiDung? IdNguoidungNavigation { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class PhieuNhap
{
    public int IdPhieunhap { get; set; }

    public string? MaPN { get; set; }

    public int IdNguoidung { get; set; }

    public DateTime NgayNhap { get; set; }

    public int? MaNcc { get; set; }

    public int? SoPhieuNhap { get; set; }

    public int? TongTien { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual NguoiDung IdNguoidungNavigation { get; set; } = null!;

    public virtual NhaCungCap? MaNccNavigation { get; set; }
}

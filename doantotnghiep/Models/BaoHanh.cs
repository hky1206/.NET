using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class BaoHanh
{
    public int IdBaohanh { get; set; }

    public int? IdHoadon { get; set; }

    public int? IdSanpham { get; set; }

    public string? TenKhachHang { get; set; }

    public DateTime? NgayMua { get; set; }

    public int? ThoiHanBaoHanh { get; set; }

    public DateTime? NgayHetHan { get; set; }

    public virtual HoaDon? IdHoadonNavigation { get; set; }

    public virtual SanPham? IdSanphamNavigation { get; set; }
}

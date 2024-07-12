using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class ChiTietHoaDon
{
    public int IdChitiethoadon { get; set; }

    public int? IdHoadon { get; set; }

    public int? IdSanpham { get; set; }

    public int? SoLuong { get; set; }

    public decimal? Dongia { get; set; }

    public virtual HoaDon? IdHoadonNavigation { get; set; }

    public virtual SanPham? IdSanphamNavigation { get; set; }
}

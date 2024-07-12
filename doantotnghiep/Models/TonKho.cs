using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TonKho
{
    public int IdTonkho { get; set; }

    public int? IdChitietphieunhap { get; set; }

    public int? SoLuongTon { get; set; }

    public int? GiaNhap { get; set; }

    public int? MaSp { get; set; }

    public int? IdChitietphieuxuat { get; set; }

    public virtual ChiTietPhieuNhap? IdChitietphieunhapNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}

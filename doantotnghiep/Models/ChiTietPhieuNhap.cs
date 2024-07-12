using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class ChiTietPhieuNhap
{
    public int IdChitietphieunhap { get; set; }

    public int? IdPhieunhap { get; set; }

    public int? MaSp { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public int? ThanhTien { get; set; }

    public int? ThueNhap { get; set; }

    public virtual PhieuNhap? IdPhieunhapNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }

    public virtual ICollection<TonKho> TonKhos { get; set; } = new List<TonKho>();
}

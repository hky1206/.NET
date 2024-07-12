using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class ChiTietPhieuXuat
{
    public int IdChitietphieuxuat { get; set; }

    public int? IdPhieuxuat { get; set; }

    public int? MaSp { get; set; }

    public int? Soluong { get; set; }

    public int? DonGia { get; set; }

    public int? ThanhTien { get; set; }

    public int? ThueXuat { get; set; }

    public virtual PhieuXuat? IdPhieuxuatNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}

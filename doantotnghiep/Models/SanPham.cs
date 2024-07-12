using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public string TenSp { get; set; } = null!;

    public int? IdDvt { get; set; }

    public int? IdDanhmuc { get; set; }

    public int? IdHangsx { get; set; }

    public int? IdPhienban { get; set; }

    public int? IdThoigianbaohanh { get; set; }

    public string? Imageurl { get; set; }

    public int? Gia { get; set; }

    public virtual ICollection<BaoHanh> BaoHanhs { get; set; } = new List<BaoHanh>();

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; } = new List<ChiTietPhieuXuat>();

    public virtual DanhMucSanPham? IdDanhmucNavigation { get; set; }

    public virtual DonViTinh? IdDvtNavigation { get; set; }

    public virtual HangSx? IdHangsxNavigation { get; set; }

    public virtual PhienBan? IdPhienbanNavigation { get; set; }

    public virtual ThoiGianBaoHanh? IdThoigianbaohanhNavigation { get; set; }

    public virtual ICollection<TonKho> TonKhos { get; set; } = new List<TonKho>();
}

using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class NguoiDung
{
    public int IdNguoidung { get; set; }

    public string? Hoten { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public int? IdDangnhap { get; set; }

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual Login? IdDangnhapNavigation { get; set; }

    public virtual NguoiDungPhanQuyen? NguoiDungPhanQuyen { get; set; }

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();

    public virtual ICollection<PhieuXuat> PhieuXuats { get; set; } = new List<PhieuXuat>();
}

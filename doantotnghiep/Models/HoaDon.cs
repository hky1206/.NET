using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class HoaDon
{
    public int IdHoadon { get; set; }

    public int? IdNguoidung { get; set; }

    public DateTime? NgayMua { get; set; }

    public decimal? TongTien { get; set; }

    public string? Trangthai { get; set; }

    public virtual ICollection<BaoHanh> BaoHanhs { get; set; } = new List<BaoHanh>();

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual NguoiDung? IdNguoidungNavigation { get; set; }

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}

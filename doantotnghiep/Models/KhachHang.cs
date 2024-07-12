using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string? TenKh { get; set; }

    public string? DiaChi { get; set; }

    public int? Sodienthoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<PhieuXuat> PhieuXuats { get; set; } = new List<PhieuXuat>();
}

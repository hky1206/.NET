using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class KhuyenMai
{
    public int IdKhuyenmai { get; set; }

    public string? TenKhuyenMai { get; set; }

    public double? TiLe { get; set; }

    public virtual ICollection<PhieuXuat> PhieuXuats { get; set; } = new List<PhieuXuat>();
}

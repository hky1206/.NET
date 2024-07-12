using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class DanhMucSanPham
{
    public int IdDanhmuc { get; set; }

    public string? Tendanhmuc { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

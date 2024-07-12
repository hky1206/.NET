using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class ThoiGianBaoHanh
{
    public int IdTgbh { get; set; }

    public string? ThoiGian { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

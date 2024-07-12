using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class DonViTinh
{
    public int IdDvt { get; set; }

    public string? TenDvt { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

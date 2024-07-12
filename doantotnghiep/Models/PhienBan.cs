using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class PhienBan
{
    public int IdPhienban { get; set; }

    public string? TenPhienBan { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

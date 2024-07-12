using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class HangSx
{
    public int IdHangsx { get; set; }

    public string? Tenhangsanxuat { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

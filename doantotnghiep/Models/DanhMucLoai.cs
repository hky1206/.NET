using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class DanhMucLoai
{
    public int IdDanhmucloai { get; set; }

    public string? Tendanhmucloai { get; set; }

    public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; } = new List<DanhMucSanPham>();
}

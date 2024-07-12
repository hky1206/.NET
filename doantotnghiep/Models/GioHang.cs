using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class GioHang
{
    public int IdGiohang { get; set; }

    public int? IdNguoidung { get; set; }

    public int? IdSanpham { get; set; }

    public int? SoLuong { get; set; }

    public virtual NguoiDung? IdNguoidungNavigation { get; set; }
}

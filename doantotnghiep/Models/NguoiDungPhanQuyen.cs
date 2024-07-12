using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class NguoiDungPhanQuyen
{
    public int IdNguoidung { get; set; }

    public int IdPhanquyen { get; set; }

    public virtual NguoiDung IdNguoidungNavigation { get; set; } = null!;

    public virtual PhanQuyen IdPhanquyenNavigation { get; set; } = null!;
}

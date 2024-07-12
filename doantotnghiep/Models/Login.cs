using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Login
{
    public int IdDangnhap { get; set; }

    public string? TenDangnhap { get; set; }

    public string? MatKhau { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? Quyen { get; set; }

    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}

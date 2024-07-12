using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class PhanQuyen
{
    public int IdPhanquyen { get; set; }

    public string? TenQuyen { get; set; }

    public virtual ICollection<NguoiDungPhanQuyen> NguoiDungPhanQuyens { get; set; } = new List<NguoiDungPhanQuyen>();
}

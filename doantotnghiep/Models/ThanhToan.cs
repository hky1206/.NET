using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class ThanhToan
{
    public int IdThanhtoan { get; set; }

    public int? IdHoadon { get; set; }

    public string? PhuongThuc { get; set; }

    public DateTime? NgayMua { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThai { get; set; }

    public string? TransactionId { get; set; }

    public virtual HoaDon? IdHoadonNavigation { get; set; }
}

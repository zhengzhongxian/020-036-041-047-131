using System;
using System.Collections.Generic;

namespace NET_Midterm2025.Models;

public partial class Nhanvien
{
    public int MaNhanVien { get; set; }

    public string? HoTenNhanVien { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public int? MaBangCap { get; set; }

    public virtual Bangcap? MaBangCapNavigation { get; set; }

    public virtual ICollection<Phieuthutien> Phieuthutiens { get; set; } = new List<Phieuthutien>();
}

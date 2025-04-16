using System;
using System.Collections.Generic;

namespace NET_Midterm2025.Models;

public partial class Nhaxuatban
{
    public string MaNxb { get; set; } = null!;

    public string TenNxb { get; set; } = null!;

    public int NamThanhLap { get; set; }

    public string DiaChi { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}

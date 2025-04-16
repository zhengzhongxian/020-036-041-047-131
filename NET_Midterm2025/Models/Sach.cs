using System;
using System.Collections.Generic;

namespace NET_Midterm2025.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public string TenSach { get; set; } = null!;

    public string? AnhBia { get; set; }

    public string? Isbn { get; set; }

    public string? TacGia { get; set; }

    public int? NamXuatBan { get; set; }

    public string? MaNxb { get; set; }

    public double TriGia { get; set; }

    public DateTime NgayNhap { get; set; }

    public virtual Nhaxuatban? MaNxbNavigation { get; set; }

    public virtual ICollection<Phieumuonsach> MaPhieuMuons { get; set; } = new List<Phieumuonsach>();
}

using System;
using System.Collections.Generic;

namespace NET_Midterm2025.Models;

public partial class Phieuthutien
{
    public int MaPhieuThuTien { get; set; }

    public double? SoTienNo { get; set; }

    public double? SoTienThu { get; set; }

    public int? MaDocGia { get; set; }

    public int? MaNhanVien { get; set; }

    public virtual Docgium? MaDocGiaNavigation { get; set; }

    public virtual Nhanvien? MaNhanVienNavigation { get; set; }
}

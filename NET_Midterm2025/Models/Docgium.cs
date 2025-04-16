using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET_Midterm2025.Models;

[Table("DOCGIA")]
public partial class Docgium
{
    public int MaDocGia { get; set; }

    public string? HoTenDocGia { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public DateTime? NgayLapThe { get; set; }

    public DateTime? NgayHetHan { get; set; }

    public double? TienNo { get; set; }

    public virtual ICollection<Phieumuonsach> Phieumuonsaches { get; set; } = new List<Phieumuonsach>();

    public virtual ICollection<Phieuthutien> Phieuthutiens { get; set; } = new List<Phieuthutien>();
}

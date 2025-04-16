using System;
using System.Collections.Generic;

namespace NET_Midterm2025.Models;

public partial class Phieumuonsach
{
    public int MaPhieuMuon { get; set; }

    public DateTime NgayMuon { get; set; }

    public int? MaDocGia { get; set; }

    public virtual Docgium? MaDocGiaNavigation { get; set; }

    public virtual ICollection<Sach> MaSaches { get; set; } = new List<Sach>();
}

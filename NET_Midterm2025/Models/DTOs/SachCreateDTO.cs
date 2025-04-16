using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace NET_Midterm2025.Models.DTOs
{
    public class SachCreateDTO
    {
        [Display(Name = "Tên sách")]
        public string TenSach { get; set; } = null!;
        [Display(Name = "Ảnh bìa sách")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string AnhBia { get; set; }
        [Display(Name = "ISBN")]
        public string? Isbn { get; set; }
        [Display(Name = "Tác giả")]
        public string? TacGia { get; set; }
        [Display(Name = "Năm xuất bản")]
        public int? NamXuatBan { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public string? MaNxb { get; set; }
        [Display(Name = "Giá trị")]
        public double TriGia { get; set; }
        [Display(Name = "Ngày nhập")]
        public DateTime NgayNhap = DateTime.UtcNow;
    }
}

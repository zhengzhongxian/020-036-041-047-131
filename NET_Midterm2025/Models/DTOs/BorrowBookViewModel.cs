using System.ComponentModel.DataAnnotations;

namespace NET_Midterm2025.Models.DTOs
{
    public class BorrowBookViewModel
    {
        [Required]
        [Display(Name = "Reader ID")]
        public int MaDocGia { get; set; }

        [Display(Name = "Reader Name")]
        public string HoTenDocGia { get; set; }

        [Required]
        [Display(Name = "Borrow Date")]
        [DataType(DataType.Date)]
        public DateTime NgayMuon { get; set; } = DateTime.Today;

        [Required]
        [Display(Name = "Books to Borrow")]
        public List<int> SelectedBookIds { get; set; } = new List<int>();

        // Available books for selection
        public List<Sach> AvailableBooks { get; set; } = new List<Sach>();
    }
}

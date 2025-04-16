using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_Midterm2025.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Midterm2025.Controllers
{
    public class PhieuMuonController : Controller
    {
        private readonly ThuVienContext _context;

        public PhieuMuonController(ThuVienContext context)
        {
            _context = context;
        }

        // GET: PhieuMuon/ChiTiet/1 (với 1 là MaPhieuMuon kiểu int)
        [Route("phieu-muon/{id:int}")] // Ràng buộc id phải là số nguyên
        public async Task<IActionResult> ChiTiet(int id)
        {
            var phieuMuon = await _context.Phieumuonsaches
                .Include(p => p.MaDocGiaNavigation)
                .Include(p => p.MaSaches)
                    .ThenInclude(s => s.MaNxbNavigation)
                .FirstOrDefaultAsync(p => p.MaPhieuMuon == id);

            if (phieuMuon == null)
            {
                return NotFound();
            }

            // Tạo ViewModel để truyền dữ liệu
            var viewModel = new ChiTietPhieuMuonViewModel
            {
                PhieuMuon = phieuMuon,
                SachMuonList = phieuMuon.MaSaches.Select(s => new SachMuonInfo
                {
                    MaSach = s.MaSach,
                    TenSach = s.TenSach,
                    AnhBia = s.AnhBia,
                    NhaXuatBan = s.MaNxbNavigation != null ? s.MaNxbNavigation.TenNxb : "Không xác định"
                }).ToList()
            };

            return View(viewModel);
        }
    }

    public class ChiTietPhieuMuonViewModel
    {
        public Phieumuonsach PhieuMuon { get; set; }
        public List<SachMuonInfo> SachMuonList { get; set; }
    }

    public class SachMuonInfo
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string AnhBia { get; set; }
        public string NhaXuatBan { get; set; }
    }
}
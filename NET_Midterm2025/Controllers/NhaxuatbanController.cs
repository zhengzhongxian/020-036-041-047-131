using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_Midterm2025.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Midterm2025.Controllers
{
    public class NhaxuatbanController : Controller
    {
        private readonly ThuVienContext _context;

        public NhaxuatbanController(ThuVienContext context)
        {
            _context = context;
        }

        [Route("nha-xuat-ban/thong-ke")]
        public async Task<IActionResult> ThongKeNXB()
        {
            var nxbList = await _context.Nhaxuatbans
                .Select(n => new NxbViewModel
                {
                    MaNxb = n.MaNxb,
                    TenNxb = n.TenNxb,
                    SoLuongSach = _context.Saches.Count(s => s.MaNxb == n.MaNxb)
                })
                .ToListAsync();

            return View("Index", nxbList); // Sử dụng lại view Index
        }
    }

    public class NxbViewModel
    {
        public string MaNxb { get; set; }
        public string TenNxb { get; set; }
        public int SoLuongSach { get; set; }
    }
}
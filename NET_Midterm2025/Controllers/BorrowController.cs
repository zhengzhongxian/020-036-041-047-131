using Microsoft.AspNetCore.Mvc;
using NET_Midterm2025.Models.DTOs;
using NET_Midterm2025.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace NET_Midterm2025.Controllers
{
    public class BorrowController : Controller
    {
        private readonly ThuVienContext _context;
        private readonly ILogger<BorrowController> _logger;
        public BorrowController(ThuVienContext context, ILogger<BorrowController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Borrow/Index/{readerId}
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Reader ID is null");
                return NotFound();
            }

            var reader = await _context.Docgia.FindAsync(id);

            if (reader == null)
            {
                _logger.LogWarning("Reader with ID {id} not found", id);
                return NotFound();
            }

            _logger.LogInformation("Reader found: {reader}", reader);

            var model = new BorrowBookViewModel
            {
                MaDocGia = reader.MaDocGia,
                HoTenDocGia = reader.HoTenDocGia,
                AvailableBooks = await _context.Saches.ToListAsync()
            };

            return View(model);
        }

        // POST: Borrow/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create new borrowing ticket
                var phieuMuon = new Phieumuonsach
                {
                    MaDocGia = model.MaDocGia,
                    NgayMuon = model.NgayMuon,
                };

                // Add selected books
                foreach (var bookId in model.SelectedBookIds)
                {
                    var book = await _context.Saches.FindAsync(bookId);
                    if (book != null)
                    {
                        phieuMuon.MaSaches.Add(book);
                    }
                }

                _context.Add(phieuMuon);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Reader", new { id = model.MaDocGia });
            }

            // If we got this far, something failed; redisplay form
            model.AvailableBooks = await _context.Saches.ToListAsync();
            return View("Index", model);
        }
    }
}

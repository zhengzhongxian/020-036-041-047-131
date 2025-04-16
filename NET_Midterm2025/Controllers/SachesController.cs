using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET_Midterm2025.Models;
using NET_Midterm2025.Models.DTOs;

namespace NET_Midterm2025.Controllers
{
    public class SachesController : Controller
    {
        private readonly ThuVienContext _context;

        public SachesController(ThuVienContext context)
        {
            _context = context;
        }

        // GET: Saches
        public async Task<IActionResult> Index()
        {
            var thuVienContext = _context.Saches.Include(s => s.MaNxbNavigation);
            return View(await thuVienContext.ToListAsync());
        }

        // GET: Saches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .Include(s => s.MaNxbNavigation)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: Saches/Create
        public IActionResult Create()
        {
            ViewData["MaNxb"] = new SelectList(_context.Nhaxuatbans, "MaNxb", "MaNxb");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SachCreateDTO sach)
        {
            if (ModelState.IsValid)
            {
                var newSach = new Sach
                {
                    TenSach = sach.TenSach,
                    AnhBia = sach.AnhBia,
                    Isbn = sach.Isbn,
                    TacGia = sach.TacGia,
                    NamXuatBan = sach.NamXuatBan,
                    MaNxb = sach.MaNxb,
                    TriGia = sach.TriGia,
                    NgayNhap = sach.NgayNhap
                };
                _context.Add(newSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNxb"] = new SelectList(_context.Nhaxuatbans, "MaNxb", "MaNxb", sach.MaNxb);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["MaNxb"] = new SelectList(_context.Nhaxuatbans, "MaNxb", "MaNxb", sach.MaNxb);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSach,TenSach,AnhBia,Isbn,TacGia,NamXuatBan,MaNxb,TriGia,NgayNhap")] Sach sach)
        {
            if (id != sach.MaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sach.NgayNhap = DateTime.UtcNow;
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.MaSach))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNxb"] = new SelectList(_context.Nhaxuatbans, "MaNxb", "MaNxb", sach.MaNxb);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .Include(s => s.MaNxbNavigation)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sach = await _context.Saches.FindAsync(id);
            if (sach != null)
            {
                _context.Saches.Remove(sach);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(int id)
        {
            return _context.Saches.Any(e => e.MaSach == id);
        }
    }
}

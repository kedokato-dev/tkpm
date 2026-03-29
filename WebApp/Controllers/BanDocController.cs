using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data; // DbContext
using WebApp.Models; // NguoiDung model

namespace WebApp.Controllers
{
    public class BanDocController : Controller
    {
        private readonly QuanLyThuVienContext _context;

        public BanDocController(QuanLyThuVienContext context)
        {
            _context = context;
        }

        // GET: /BanDoc
        public async Task<IActionResult> Index()
        {
            var banDoc = await _context.NguoiDungs.ToListAsync();
            return View(banDoc);
        }

        // GET: /BanDoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /BanDoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                nguoiDung.NgayTao = DateTime.Now;
                _context.Add(nguoiDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDung);
        }

        // GET: /BanDoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung == null) return NotFound();

            return View(nguoiDung);
        }

        // POST: /BanDoc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NguoiDung nguoiDung)
        {
            if (id != nguoiDung.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    nguoiDung.NgayThayDoi = DateTime.Now;
                    _context.Update(nguoiDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.NguoiDungs.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDung);
        }

        // GET: /BanDoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(m => m.Id == id);

            if (nguoiDung == null) return NotFound();

            return View(nguoiDung);
        }

        // POST: /BanDoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung != null)
            {
                _context.NguoiDungs.Remove(nguoiDung);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
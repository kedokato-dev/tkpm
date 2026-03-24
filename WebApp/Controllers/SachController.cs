using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers;

public class SachController : Controller
{
    private readonly QuanLyThuVienContext _context;

    public SachController(QuanLyThuVienContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? search, int? theloaiId, string? trangThai)
    {
        var query = _context.Saches
            .Include(s => s.Theloai)
            .Include(s => s.Nhaxuatban)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(s => s.TieuDe.Contains(search) || (s.MaIsbn != null && s.MaIsbn.Contains(search)));
        }

        if (theloaiId.HasValue)
        {
            query = query.Where(s => s.TheloaiId == theloaiId.Value);
        }

        if (!string.IsNullOrWhiteSpace(trangThai))
        {
            query = query.Where(s => s.TrangThai == trangThai);
        }

        ViewBag.Search = search;
        ViewBag.TheloaiId = theloaiId;
        ViewBag.TrangThai = trangThai;
        ViewBag.TheLoais = await _context.TheLoais.OrderBy(t => t.Ten).ToListAsync();

        var saches = await query.OrderByDescending(s => s.NgayTao).ToListAsync();
        return View(saches);
    }

    public async Task<IActionResult> Details(int id)
    {
        var sach = await _context.Saches
            .Include(s => s.Theloai)
            .Include(s => s.Nhaxuatban)
            .Include(s => s.SachTacgia).ThenInclude(st => st.TacGia)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (sach == null)
            return NotFound();

        return View(sach);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateDropdowns();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Sach sach)
    {
        ModelState.Remove("Theloai");
        ModelState.Remove("Nhaxuatban");

        if (ModelState.IsValid)
        {
            sach.TrangThai = sach.TrangThai ?? "Hoạt động";
            _context.Saches.Add(sach);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Thêm sách thành công!";
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropdowns(sach.TheloaiId, sach.NhaxuatbanId);
        return View(sach);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var sach = await _context.Saches.FindAsync(id);
        if (sach == null)
            return NotFound();

        await PopulateDropdowns(sach.TheloaiId, sach.NhaxuatbanId);
        return View(sach);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Sach sach)
    {
        if (id != sach.Id)
            return NotFound();

        ModelState.Remove("Theloai");
        ModelState.Remove("Nhaxuatban");

        if (ModelState.IsValid)
        {
            var existing = await _context.Saches.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.TieuDe = sach.TieuDe;
            existing.MaIsbn = sach.MaIsbn;
            existing.Slug = sach.Slug;
            existing.BanMem = sach.BanMem;
            existing.NamXuatBan = sach.NamXuatBan;
            existing.PhienBan = sach.PhienBan;
            existing.GiaTien = sach.GiaTien;
            existing.SoTrang = sach.SoTrang;
            existing.NgonNgu = sach.NgonNgu;
            existing.MoTa = sach.MoTa;
            existing.HinhAnh = sach.HinhAnh;
            existing.SoLuongNhap = sach.SoLuongNhap;
            existing.SoLuongTon = sach.SoLuongTon;
            existing.SoLuongChoMuon = sach.SoLuongChoMuon;
            existing.TrangThai = sach.TrangThai;
            existing.TheloaiId = sach.TheloaiId;
            existing.NhaxuatbanId = sach.NhaxuatbanId;

            await _context.SaveChangesAsync();
            TempData["Success"] = "Cập nhật sách thành công!";
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropdowns(sach.TheloaiId, sach.NhaxuatbanId);
        return View(sach);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var sach = await _context.Saches
            .Include(s => s.Theloai)
            .Include(s => s.Nhaxuatban)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (sach == null)
            return NotFound();

        return View(sach);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var sach = await _context.Saches.FindAsync(id);
        if (sach != null)
        {
            _context.Saches.Remove(sach);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Xóa sách thành công!";
        }
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateDropdowns(int? theloaiId = null, int? nhaxuatbanId = null)
    {
        ViewBag.TheLoais = new SelectList(
            await _context.TheLoais.OrderBy(t => t.Ten).ToListAsync(),
            "Id", "Ten", theloaiId);
        ViewBag.NhaXuatBans = new SelectList(
            await _context.NhaXuatBans.OrderBy(n => n.Ten).ToListAsync(),
            "Id", "Ten", nhaxuatbanId);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Core.Entities;
using Library.Core.Interfaces;

namespace WebApp.Controllers;

public class SachController : Controller
{
    private readonly ISachService _sachService;

    public SachController(ISachService sachService)
    {
        _sachService = sachService;
    }

    public async Task<IActionResult> Index(string? search, int? theloaiId, string? trangThai)
    {
        var saches = await _sachService.GetAllAsync(search, theloaiId, trangThai);

        ViewBag.Search = search;
        ViewBag.TheloaiId = theloaiId;
        ViewBag.TrangThai = trangThai;
        ViewBag.TheLoais = await _sachService.GetTheLoaisAsync();

        return View(saches);
    }

    public async Task<IActionResult> Details(int id)
    {
        var sach = await _sachService.GetByIdWithDetailsAsync(id);
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
            await _sachService.CreateAsync(sach);
            TempData["Success"] = "Thêm sách thành công!";
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropdowns(sach.TheloaiId, sach.NhaxuatbanId);
        return View(sach);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var sach = await _sachService.GetByIdAsync(id);
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
            var updated = await _sachService.UpdateAsync(id, sach);
            if (!updated)
                return NotFound();

            TempData["Success"] = "Cập nhật sách thành công!";
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropdowns(sach.TheloaiId, sach.NhaxuatbanId);
        return View(sach);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var sach = await _sachService.GetByIdWithDetailsAsync(id);
        if (sach == null)
            return NotFound();

        return View(sach);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _sachService.DeleteAsync(id);
        TempData["Success"] = "Xóa sách thành công!";
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateDropdowns(int? theloaiId = null, int? nhaxuatbanId = null)
    {
        ViewBag.TheLoais = new SelectList(
            await _sachService.GetTheLoaisAsync(),
            "Id", "Ten", theloaiId);
        ViewBag.NhaXuatBans = new SelectList(
            await _sachService.GetNhaXuatBansAsync(),
            "Id", "Ten", nhaxuatbanId);
    }
}

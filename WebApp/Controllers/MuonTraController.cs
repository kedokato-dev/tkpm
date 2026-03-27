using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MuonTraController : Controller
    {
        private readonly QuanLyThuVienContext _context;

        public MuonTraController(QuanLyThuVienContext context)
        {
            _context = context;
        }

        // Danh sách phiếu mượn
        public async Task<IActionResult> Index()
        {
            var muonTraList = await _context.MuonTra
                .Include(m => m.NguoiDung)
                .Include(m => m.DangKyCapBiet)
                    .ThenInclude(d => d.Sach)
                .OrderByDescending(m => m.NgayTao)
                .ToListAsync();

            return View(muonTraList);
        }

        // Form thêm mới phiếu mượn
        public async Task<IActionResult> Create()
        {
            // Lấy danh sách người dùng
            var nguoiDungList = await _context.NguoiDung
                .Where(n => n.TrangThai == "Hoạt động")
                .ToListAsync();

            // Lấy danh sách sách đang có sẵn
            var sachList = await _context.DangKyCapBiet
                .Include(d => d.Sach)
                .Where(d => d.TinhTrang == "Có sẵn") // Sách có sẵn để mượn
                .ToListAsync();

            ViewBag.NguoiDung = nguoiDungList;
            ViewBag.Sach = sachList;

            return View();
        }

        // Lưu phiếu mượn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MuonTra muonTra)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra người dùng có tồn tại không
                var nguoiDung = await _context.NguoiDung.FindAsync(muonTra.NguoiDungId);
                if (nguoiDung == null)
                {
                    ModelState.AddModelError("", "Người dùng không tồn tại");
                }

                // Kiểm tra sách có tồn tại không
                var dangKyCapBiet = await _context.DangKyCapBiet.FindAsync(muonTra.DangKyCapBietId);
                if (dangKyCapBiet == null)
                {
                    ModelState.AddModelError("", "Sách không tồn tại");
                }

                if (ModelState.IsValid)
                {
                    muonTra.NgayTao = DateTime.Now;
                    muonTra.TrangThai = "Đang mượn";
                    muonTra.Loai = "Mượn";

                    _context.MuonTra.Add(muonTra);

                    // Cập nhật trạng thái sách
                    if (dangKyCapBiet != null)
                    {
                        dangKyCapBiet.TinhTrang = "Đã mượn";
                        dangKyCapBiet.NgayChoMuon = DateTime.Now;
                        _context.DangKyCapBiet.Update(dangKyCapBiet);
                    }

                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Tạo phiếu mượn thành công!";
                    return RedirectToAction(nameof(Index));
                }
            }

            // Nếu có lỗi, load lại dữ liệu
            var nguoiDungList = await _context.NguoiDung.ToListAsync();
            var sachList = await _context.DangKyCapBiet.Include(d => d.Sach).ToListAsync();

            ViewBag.NguoiDung = nguoiDungList;
            ViewBag.Sach = sachList;

            return View(muonTra);
        }

        // Chi tiết phiếu mượn
        public async Task<IActionResult> Details(int id)
        {
            var muonTra = await _context.MuonTra
                .Include(m => m.NguoiDung)
                .Include(m => m.DangKyCapBiet)
                    .ThenInclude(d => d.Sach)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (muonTra == null)
            {
                return NotFound();
            }

            return View(muonTra);
        }

        // Form chỉnh sửa phiếu mượn
        public async Task<IActionResult> Edit(int id)
        {
            var muonTra = await _context.MuonTra.FindAsync(id);

            if (muonTra == null)
            {
                return NotFound();
            }

            var nguoiDungList = await _context.NguoiDung.ToListAsync();
            var sachList = await _context.DangKyCapBiet.Include(d => d.Sach).ToListAsync();

            ViewBag.NguoiDung = nguoiDungList;
            ViewBag.Sach = sachList;

            return View(muonTra);
        }

        // Lưu chỉnh sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MuonTra muonTra)
        {
            if (id != muonTra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.MuonTra.Update(muonTra);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Cập nhật phiếu mượn thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

            var nguoiDungList = await _context.NguoiDung.ToListAsync();
            var sachList = await _context.DangKyCapBiet.Include(d => d.Sach).ToListAsync();

            ViewBag.NguoiDung = nguoiDungList;
            ViewBag.Sach = sachList;

            return View(muonTra);
        }

        // Trả sách
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TraSach(int id, int? tienPhat)
        {
            var muonTra = await _context.MuonTra
                .Include(m => m.DangKyCapBiet)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (muonTra == null)
            {
                return NotFound();
            }

            muonTra.NgayTra = DateTime.Now;
            muonTra.TrangThai = "Đã trả";
            muonTra.TienPhat = tienPhat ?? 0;

            // Cập nhật trạng thái sách
            if (muonTra.DangKyCapBiet != null)
            {
                muonTra.DangKyCapBiet.TinhTrang = "Có sẵn";
                muonTra.DangKyCapBiet.NgayNhanSach = DateTime.Now;
                _context.DangKyCapBiet.Update(muonTra.DangKyCapBiet);
            }

            _context.MuonTra.Update(muonTra);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Ghi nhận trả sách thành công!";
            return RedirectToAction(nameof(Index));
        }

        // Xóa phiếu mượn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var muonTra = await _context.MuonTra.FindAsync(id);

            if (muonTra != null)
            {
                _context.MuonTra.Remove(muonTra);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Xóa phiếu mượn thành công!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
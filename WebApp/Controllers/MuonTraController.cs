// using Microsoft.AspNetCore.Mvc;
// using WebApp.Models;

// namespace WebApp.Controllers
// {
//     public class MuonTraController : Controller
//     {
//         // Mảng lưu trữ tạm thời các phiếu mượn (trong bộ nhớ)
//         private static List<dynamic> muonTraList = new List<dynamic>();

//         public IActionResult Create()
//         {
//             return View();
//         }

//         // API để lưu phiếu mượn vào mảng
//         [HttpPost]
//         [Route("api/muontra/save")]
//         public IActionResult SavePhieu([FromBody] PhieuMuonModel phieu)
//         {
//             if (phieu == null || string.IsNullOrWhiteSpace(phieu.NguoiMuon) ||
//                 string.IsNullOrWhiteSpace(phieu.SachMuon) || string.IsNullOrWhiteSpace(phieu.HanTra))
//             {
//                 return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
//             }

//             try
//             {
//                 // Thêm phiếu vào mảng
//                 var phieuMoi = new
//                 {
//                     Id = muonTraList.Count + 1,
//                     NguoiMuon = phieu.NguoiMuon,
//                     SachMuon = phieu.SachMuon,
//                     HanTra = phieu.HanTra,
//                     GhiChu = phieu.GhiChu,
//                     NgayTao = DateTime.Now
//                 };

//                 muonTraList.Add(phieuMoi);

//                 return Ok(new { success = true, message = "Tạo phiếu mượn thành công!", data = phieuMoi });
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(new { success = false, message = ex.Message });
//             }
//         }

//         // Lấy danh sách tất cả phiếu mượn
//         public IActionResult Index()
//         {
//             return View(muonTraList);
//         }

//         // Xem chi tiết phiếu mượn
//         public IActionResult Details(int id)
//         {
//             var phieu = muonTraList.FirstOrDefault(p => (int)p.Id == id);
//             if (phieu == null)
//                 return NotFound();

//             return View(phieu);
//         }

//         // Xóa phiếu mượn
//         public IActionResult Delete(int id)
//         {
//             var phieu = muonTraList.FirstOrDefault(p => (int)p.Id == id);
//             if (phieu != null)
//                 muonTraList.Remove(phieu);

//             return RedirectToAction(nameof(Index));
//         }
//     }

//     // Model để nhận dữ liệu từ client
//     public class PhieuMuonModel
//     {
//         public string NguoiMuon { get; set; }
//         public string SachMuon { get; set; }
//         public string HanTra { get; set; }
//         public string GhiChu { get; set; }
//     }
// }


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Core.Entities;
using Library.Data;

namespace WebApp.Controllers
{
    public class MuonTraController : Controller
    {
        private readonly QuanLyThuVienContext _context;

        public MuonTraController(QuanLyThuVienContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        // API để lưu phiếu mượn vào database
        [HttpPost]
        [Route("api/muontra/save")]
        public async Task<IActionResult> SavePhieu([FromBody] PhieuMuonModel phieu)
        {
            if (phieu == null || string.IsNullOrWhiteSpace(phieu.NguoiMuon) ||
                string.IsNullOrWhiteSpace(phieu.SachMuon) || string.IsNullOrWhiteSpace(phieu.HanTra))
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
            }

            try
            {
                // Tìm người dùng theo tên
                var nguoiDung = await _context.NguoiDungs
                    .FirstOrDefaultAsync(n => n.HoTen == phieu.NguoiMuon);

                if (nguoiDung == null)
                {
                    // Nếu không tìm thấy, tạo mới người dùng
                    nguoiDung = new NguoiDung
                    {
                        HoTen = phieu.NguoiMuon,
                        Sdt = phieu.Sdt,
                        Email = phieu.Email,
                        Cccd = phieu.Cccd,
                        NgayTao = DateTime.Now,
                        TrangThai = "Hoạt động"
                    };
                    _context.NguoiDungs.Add(nguoiDung);
                    await _context.SaveChangesAsync();
                }

                // Tìm sách theo tên
                var sach = await _context.Saches
                    .FirstOrDefaultAsync(s => s.TieuDe == phieu.SachMuon);

                if (sach == null)
                {
                    return BadRequest(new { success = false, message = "Sách không tồn tại trong hệ thống" });
                }

                // Tìm đăng ký cá biệt sách (sách cụ thể) có sẵn
                var dangKyCaBiet = await _context.DangKyCaBiets
                    .FirstOrDefaultAsync(d => d.SachId == sach.Id && d.TinhTrang == "Có sẵn");

                if (dangKyCaBiet == null)
                {
                    return BadRequest(new { success = false, message = "Sách hiện không có sẵn để mượn" });
                }

                // Chuyển đổi HanTra từ string sang DateTime
                if (!DateTime.TryParse(phieu.HanTra, out DateTime hanTra))
                {
                    return BadRequest(new { success = false, message = "Định dạng hạn trả không hợp lệ" });
                }

                // Tạo phiếu mượn mới
                var muonTra = new MuonTra
                {
                    Loai = "Mượn",
                    NgayTao = DateTime.Now,
                    HanTra = hanTra,
                    TrangThai = "Đang mượn",
                    TienPhat = 0,
                    GhiChu = phieu.GhiChu,
                    NguoiDungId = nguoiDung.Id,
                    DangKyCaBietId = dangKyCaBiet.Id
                };

                _context.MuonTras.Add(muonTra);

                // Cập nhật trạng thái sách thành "Đã mượn"
                dangKyCaBiet.TinhTrang = "Đã mượn";
                dangKyCaBiet.NgayChoMuon = DateTime.Now;
                _context.DangKyCaBiets.Update(dangKyCaBiet);

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Tạo phiếu mượn thành công!",
                    data = new
                    {
                        id = muonTra.Id,
                        nguoiMuon = nguoiDung.HoTen,
                        sachMuon = sach.TieuDe,
                        hanTra = muonTra.HanTra.ToString("dd/MM/yyyy HH:mm"),
                        ghiChu = muonTra.GhiChu,
                        ngayTao = muonTra.NgayTao
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }

        // Lấy danh sách tất cả phiếu mượn
        public async Task<IActionResult> Index()
        {
            var muonTraList = await _context.MuonTras
                .Include(m => m.NguoiDung)
                .Include(m => m.DangKyCaBiet)
                    .ThenInclude(d => d.Sach)
                .OrderByDescending(m => m.NgayTao)
                .ToListAsync();

            return View(muonTraList);
        }

        // Xem chi tiết phiếu mượn
        public async Task<IActionResult> Details(int id)
        {
            var phieu = await _context.MuonTras
                .Include(m => m.NguoiDung)
                .Include(m => m.DangKyCaBiet)
                    .ThenInclude(d => d.Sach)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (phieu == null)
                return NotFound();

            return View(phieu);
        }

        // Xóa phiếu mượn
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var phieu = await _context.MuonTras.FindAsync(id);
            if (phieu != null)
            {
                // Cập nhật lại trạng thái sách
                var dangKyCaBiet = await _context.DangKyCaBiets.FindAsync(phieu.DangKyCaBietId);
                if (dangKyCaBiet != null)
                {
                    dangKyCaBiet.TinhTrang = "Có sẵn";
                    _context.DangKyCaBiets.Update(dangKyCaBiet);
                }

                _context.MuonTras.Remove(phieu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }

    // Model để nhận dữ liệu từ client
    public class PhieuMuonModel
    {
        public string NguoiMuon { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Cccd { get; set; }
        public string SachMuon { get; set; }
        public string Isbn { get; set; }
        public string TacGia { get; set; }
        public string NhaXuatBan { get; set; }
        public string NgayMuon { get; set; }
        public string HanTra { get; set; }
        public int SoLuong { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MuonTraController : Controller
    {
        // Mảng lưu trữ tạm thời các phiếu mượn (trong bộ nhớ)
        private static List<dynamic> muonTraList = new List<dynamic>();

        public IActionResult Create()
        {
            return View();
        }

        // API để lưu phiếu mượn vào mảng
        [HttpPost]
        [Route("api/muontra/save")]
        public IActionResult SavePhieu([FromBody] PhieuMuonModel phieu)
        {
            if (phieu == null || string.IsNullOrWhiteSpace(phieu.NguoiMuon) ||
                string.IsNullOrWhiteSpace(phieu.SachMuon) || string.IsNullOrWhiteSpace(phieu.HanTra))
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
            }

            try
            {
                // Thêm phiếu vào mảng
                var phieuMoi = new
                {
                    Id = muonTraList.Count + 1,
                    NguoiMuon = phieu.NguoiMuon,
                    SachMuon = phieu.SachMuon,
                    HanTra = phieu.HanTra,
                    GhiChu = phieu.GhiChu,
                    NgayTao = DateTime.Now
                };

                muonTraList.Add(phieuMoi);

                return Ok(new { success = true, message = "Tạo phiếu mượn thành công!", data = phieuMoi });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        // Lấy danh sách tất cả phiếu mượn
        public IActionResult Index()
        {
            return View(muonTraList);
        }

        // Xem chi tiết phiếu mượn
        public IActionResult Details(int id)
        {
            var phieu = muonTraList.FirstOrDefault(p => (int)p.Id == id);
            if (phieu == null)
                return NotFound();

            return View(phieu);
        }

        // Xóa phiếu mượn
        public IActionResult Delete(int id)
        {
            var phieu = muonTraList.FirstOrDefault(p => (int)p.Id == id);
            if (phieu != null)
                muonTraList.Remove(phieu);

            return RedirectToAction(nameof(Index));
        }
    }

    // Model để nhận dữ liệu từ client
    public class PhieuMuonModel
    {
        public string NguoiMuon { get; set; }
        public string SachMuon { get; set; }
        public string HanTra { get; set; }
        public string GhiChu { get; set; }
    }
}
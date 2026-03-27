using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("muon_tra")]
    public class MuonTra
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("loai")]
        [Required(ErrorMessage = "Loại mượn không được để trống")]
        [StringLength(50)]
        public string Loai { get; set; } // "Mượn", "Gia hạn", etc.

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("han_tra")]
        [Required(ErrorMessage = "Hạn trả không được để trống")]
        public DateTime HanTra { get; set; }

        [Column("ngay_tra")]
        public DateTime? NgayTra { get; set; }

        [Column("tien_phat")]
        public int? TienPhat { get; set; } = 0;

        [Column("trang_thai")]
        [Required(ErrorMessage = "Trạng thái không được để trống")]
        [StringLength(50)]
        public string TrangThai { get; set; } // "Đang mượn", "Đã trả", "Quá hạn"

        [Column("ghi_chu")]
        [DataType(DataType.MultilineText)]
        public string? GhiChu { get; set; }

        [Column("dkcb_id")]
        [Required]
        public int DangKyCapBietId { get; set; }

        [Column("nguoi_dung_id")]
        [Required]
        public int NguoiDungId { get; set; }

        // Navigation properties
        [ForeignKey("DangKyCapBietId")]
        public DangKyCapBiet? DangKyCapBiet { get; set; }

        [ForeignKey("NguoiDungId")]
        public NguoiDung? NguoiDung { get; set; }
    }
}
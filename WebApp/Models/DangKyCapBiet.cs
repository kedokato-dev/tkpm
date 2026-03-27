using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("dang_ky_ca_biet")]
    public class DangKyCapBiet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ma_ca_biet")]
        [Required]
        [StringLength(50)]
        public string MaCapBiet { get; set; }

        [Column("tinh_trang")]
        [Required]
        [StringLength(50)]
        public string TinhTrang { get; set; }

        [Column("trang_thai")]
        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        [Column("ngay_cho_muon")]
        public DateTime? NgayChoMuon { get; set; }

        [Column("ngay_nhan_sach")]
        public DateTime? NgayNhanSach { get; set; }

        [Column("ghi_chu")]
        public string? GhiChu { get; set; }

        [Column("vitri_id")]
        public int ViTriId { get; set; }

        [Column("sach_id")]
        public int SachId { get; set; }

        [ForeignKey("SachId")]
        public Sach? Sach { get; set; }
    }
}
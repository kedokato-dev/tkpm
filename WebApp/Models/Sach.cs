using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Sach
{
    public int Id { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? MaIsbn { get; set; }

    public string? Slug { get; set; }

    public string? BanMem { get; set; }

    public string? NamXuatBan { get; set; }

    public string? PhienBan { get; set; }

    public int? GiaTien { get; set; }

    public int? SoTrang { get; set; }

    public string? NgonNgu { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public int? SoLuongNhap { get; set; }

    public int? SoLuongTon { get; set; }

    public int? SoLuongChoMuon { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime NgaySua { get; set; }

    public string TrangThai { get; set; } = null!;

    public int TheloaiId { get; set; }

    public int NhaxuatbanId { get; set; }

    public virtual ICollection<DangKyCaBiet> DangKyCaBiets { get; set; } = new List<DangKyCaBiet>();

    public virtual ICollection<DatMuon> DatMuons { get; set; } = new List<DatMuon>();

    public virtual NhaXuatBan Nhaxuatban { get; set; } = null!;

    public virtual ICollection<SachTacgium> SachTacgia { get; set; } = new List<SachTacgium>();

    public virtual TheLoai Theloai { get; set; } = null!;
}

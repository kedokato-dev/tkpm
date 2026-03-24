using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class NguoiDung
{
    public int Id { get; set; }

    public string HoTen { get; set; } = null!;

    public string? GioiTinh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? Cccd { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? MaSoThe { get; set; }

    public string? LoaiThe { get; set; }

    public string? HinhAnh { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime? NgayHetHan { get; set; }

    public DateTime? NgayKhoaThe { get; set; }

    public string? LiDoKhoa { get; set; }

    public DateTime? NgayThayDoi { get; set; }

    public string? LiDoThayDoi { get; set; }

    public int? DanhTieng { get; set; }

    public string? Quyen { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<ChuDe> ChuDes { get; set; } = new List<ChuDe>();

    public virtual ICollection<DatMuon> DatMuons { get; set; } = new List<DatMuon>();

    public virtual ICollection<FormGopY> FormGopies { get; set; } = new List<FormGopY>();

    public virtual ICollection<MuonTra> MuonTras { get; set; } = new List<MuonTra>();
}

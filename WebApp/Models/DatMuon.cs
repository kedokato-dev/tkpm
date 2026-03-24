using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class DatMuon
{
    public int Id { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime NgayHetHan { get; set; }

    public DateTime? NgayLay { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public DateTime NgayDuyet { get; set; }

    public int SachId { get; set; }

    public int NguoidungId { get; set; }

    public virtual NguoiDung Nguoidung { get; set; } = null!;

    public virtual Sach Sach { get; set; } = null!;
}

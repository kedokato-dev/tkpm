using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class MuonTra
{
    public int Id { get; set; }

    public string Loai { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public DateTime HanTra { get; set; }

    public DateTime? NgayTra { get; set; }

    public int? TienPhat { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public int DkcbId { get; set; }

    public int NguoiDungId { get; set; }

    public virtual DangKyCaBiet Dkcb { get; set; } = null!;

    public virtual NguoiDung NguoiDung { get; set; } = null!;
}

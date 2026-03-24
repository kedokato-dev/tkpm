using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class ChuDe
{
    public int Id { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateTime NgayTao { get; set; }

    public int? SoLuongXem { get; set; }

    public string TrangThai { get; set; } = null!;

    public int NguoiDungId { get; set; }

    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    public virtual NguoiDung NguoiDung { get; set; } = null!;
}

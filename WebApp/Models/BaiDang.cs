using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class BaiDang
{
    public int Id { get; set; }

    public string NoiDung { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public int? SoLuongBinhLuan { get; set; }

    public DateTime NgaySua { get; set; }

    public string TrangThai { get; set; } = null!;

    public int NguoiDungId { get; set; }

    public int ChudeId { get; set; }

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ChuDe Chude { get; set; } = null!;

    public virtual NguoiDung NguoiDung { get; set; } = null!;
}

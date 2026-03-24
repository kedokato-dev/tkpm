using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class SachTacgium
{
    public int SachId { get; set; }

    public int TacGiaId { get; set; }

    public string? VaiTro { get; set; }

    public int? ThuTu { get; set; }

    public virtual Sach Sach { get; set; } = null!;

    public virtual TacGium TacGia { get; set; } = null!;
}

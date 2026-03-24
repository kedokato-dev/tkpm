using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class TheLoai
{
    public int Id { get; set; }

    public string Ten { get; set; } = null!;

    public int? TheLoaiCha { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime NgayCapNhat { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<TheLoai> InverseTheLoaiChaNavigation { get; set; } = new List<TheLoai>();

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();

    public virtual TheLoai? TheLoaiChaNavigation { get; set; }
}

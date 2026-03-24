using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class NhaXuatBan
{
    public int Id { get; set; }

    public string Ten { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? GhiChu { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}

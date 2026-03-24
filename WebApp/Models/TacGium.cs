using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class TacGium
{
    public int Id { get; set; }

    public string Ten { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public string? QueHuong { get; set; }

    public virtual ICollection<SachTacgium> SachTacgia { get; set; } = new List<SachTacgium>();
}

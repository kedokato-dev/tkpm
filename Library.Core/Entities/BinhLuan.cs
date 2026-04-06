namespace Library.Core.Entities;

public partial class BinhLuan
{
    public int Id { get; set; }

    public string NoiDung { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public DateTime NgaySua { get; set; }

    public string TrangThai { get; set; } = null!;

    public int NguoiDungId { get; set; }

    public int BaiDangId { get; set; }

    public virtual BaiDang BaiDang { get; set; } = null!;

    public virtual NguoiDung NguoiDung { get; set; } = null!;
}

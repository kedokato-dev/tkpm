namespace Library.Core.Entities;

public partial class DangKyCaBiet
{
    public int Id { get; set; }

    public string MaCaBiet { get; set; } = null!;

    public string TinhTrang { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public DateTime? NgayChoMuon { get; set; }

    public DateTime? NgayNhanSach { get; set; }

    public string? GhiChu { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime NgaySua { get; set; }

    public int VitriId { get; set; }

    public int SachId { get; set; }

    public virtual ICollection<MuonTra> MuonTras { get; set; } = new List<MuonTra>();

    public virtual Sach Sach { get; set; } = null!;

    public virtual ViTri Vitri { get; set; } = null!;
}

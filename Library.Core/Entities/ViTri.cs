namespace Library.Core.Entities;

public partial class ViTri
{
    public int Id { get; set; }

    public string GiaSach { get; set; } = null!;

    public string Phong { get; set; } = null!;

    public string Tang { get; set; } = null!;

    public string KhuVuc { get; set; } = null!;

    public virtual ICollection<DangKyCaBiet> DangKyCaBiets { get; set; } = new List<DangKyCaBiet>();
}

namespace Library.Core.Entities;

public partial class FormGopY
{
    public int Id { get; set; }

    public string HoTen { get; set; } = null!;

    public string LienHe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public string NgayTao { get; set; } = null!;

    public int NguoiDungId { get; set; }

    public virtual NguoiDung NguoiDung { get; set; } = null!;
}

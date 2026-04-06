using Library.Core.Entities;

namespace Library.Core.Interfaces;

public interface ISachService
{
    Task<List<Sach>> GetAllAsync(string? search, int? theloaiId, string? trangThai);
    Task<Sach?> GetByIdAsync(int id);
    Task<Sach?> GetByIdWithDetailsAsync(int id);
    Task CreateAsync(Sach sach);
    Task<bool> UpdateAsync(int id, Sach sach);
    Task DeleteAsync(int id);
    Task<List<TheLoai>> GetTheLoaisAsync();
    Task<List<NhaXuatBan>> GetNhaXuatBansAsync();
}

using Library.Core.Entities;

namespace Library.Core.Interfaces;

public interface ISachRepository
{
    Task<List<Sach>> GetAllAsync(string? search, int? theloaiId, string? trangThai);
    Task<Sach?> GetByIdAsync(int id);
    Task<Sach?> GetByIdWithDetailsAsync(int id);
    Task AddAsync(Sach sach);
    Task UpdateAsync(Sach sach);
    Task DeleteAsync(int id);
    Task<List<TheLoai>> GetTheLoaisAsync();
    Task<List<NhaXuatBan>> GetNhaXuatBansAsync();
}

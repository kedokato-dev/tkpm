using Library.Core.Entities;
using Library.Core.Interfaces;

namespace Library.Service;

public class SachService : ISachService
{
    private readonly ISachRepository _sachRepository;

    public SachService(ISachRepository sachRepository)
    {
        _sachRepository = sachRepository;
    }

    public async Task<List<Sach>> GetAllAsync(string? search, int? theloaiId, string? trangThai)
    {
        return await _sachRepository.GetAllAsync(search, theloaiId, trangThai);
    }

    public async Task<Sach?> GetByIdAsync(int id)
    {
        return await _sachRepository.GetByIdAsync(id);
    }

    public async Task<Sach?> GetByIdWithDetailsAsync(int id)
    {
        return await _sachRepository.GetByIdWithDetailsAsync(id);
    }

    public async Task CreateAsync(Sach sach)
    {
        sach.TrangThai = sach.TrangThai ?? "Hoạt động";
        await _sachRepository.AddAsync(sach);
    }

    public async Task<bool> UpdateAsync(int id, Sach sach)
    {
        var existing = await _sachRepository.GetByIdAsync(id);
        if (existing == null)
            return false;

        existing.TieuDe = sach.TieuDe;
        existing.MaIsbn = sach.MaIsbn;
        existing.Slug = sach.Slug;
        existing.BanMem = sach.BanMem;
        existing.NamXuatBan = sach.NamXuatBan;
        existing.PhienBan = sach.PhienBan;
        existing.GiaTien = sach.GiaTien;
        existing.SoTrang = sach.SoTrang;
        existing.NgonNgu = sach.NgonNgu;
        existing.MoTa = sach.MoTa;
        existing.HinhAnh = sach.HinhAnh;
        existing.SoLuongNhap = sach.SoLuongNhap;
        existing.SoLuongTon = sach.SoLuongTon;
        existing.SoLuongChoMuon = sach.SoLuongChoMuon;
        existing.TrangThai = sach.TrangThai;
        existing.TheloaiId = sach.TheloaiId;
        existing.NhaxuatbanId = sach.NhaxuatbanId;

        await _sachRepository.UpdateAsync(existing);
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        await _sachRepository.DeleteAsync(id);
    }

    public async Task<List<TheLoai>> GetTheLoaisAsync()
    {
        return await _sachRepository.GetTheLoaisAsync();
    }

    public async Task<List<NhaXuatBan>> GetNhaXuatBansAsync()
    {
        return await _sachRepository.GetNhaXuatBansAsync();
    }
}

using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repositories;

public class SachRepository : ISachRepository
{
    private readonly QuanLyThuVienContext _context;

    public SachRepository(QuanLyThuVienContext context)
    {
        _context = context;
    }

    public async Task<List<Sach>> GetAllAsync(string? search, int? theloaiId, string? trangThai)
    {
        var query = _context.Saches
            .Include(s => s.Theloai)
            .Include(s => s.Nhaxuatban)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(s => s.TieuDe.Contains(search) || (s.MaIsbn != null && s.MaIsbn.Contains(search)));
        }

        if (theloaiId.HasValue)
        {
            query = query.Where(s => s.TheloaiId == theloaiId.Value);
        }

        if (!string.IsNullOrWhiteSpace(trangThai))
        {
            query = query.Where(s => s.TrangThai == trangThai);
        }

        return await query.OrderByDescending(s => s.NgayTao).ToListAsync();
    }

    public async Task<Sach?> GetByIdAsync(int id)
    {
        return await _context.Saches.FindAsync(id);
    }

    public async Task<Sach?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Saches
            .Include(s => s.Theloai)
            .Include(s => s.Nhaxuatban)
            .Include(s => s.SachTacgia).ThenInclude(st => st.TacGia)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Sach sach)
    {
        _context.Saches.Add(sach);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sach sach)
    {
        _context.Saches.Update(sach);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sach = await _context.Saches.FindAsync(id);
        if (sach != null)
        {
            _context.Saches.Remove(sach);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<TheLoai>> GetTheLoaisAsync()
    {
        return await _context.TheLoais.OrderBy(t => t.Ten).ToListAsync();
    }

    public async Task<List<NhaXuatBan>> GetNhaXuatBansAsync()
    {
        return await _context.NhaXuatBans.OrderBy(n => n.Ten).ToListAsync();
    }
}

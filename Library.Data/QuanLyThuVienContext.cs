using Microsoft.EntityFrameworkCore;
using Library.Core.Entities;

namespace Library.Data;

public partial class QuanLyThuVienContext : DbContext
{
    public QuanLyThuVienContext(DbContextOptions<QuanLyThuVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiDang> BaiDangs { get; set; }

    public virtual DbSet<BinhLuan> BinhLuans { get; set; }

    public virtual DbSet<ChuDe> ChuDes { get; set; }

    public virtual DbSet<DangKyCaBiet> DangKyCaBiets { get; set; }

    public virtual DbSet<DatMuon> DatMuons { get; set; }

    public virtual DbSet<FormGopY> FormGopies { get; set; }

    public virtual DbSet<MuonTra> MuonTras { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<SachTacgium> SachTacgia { get; set; }

    public virtual DbSet<TacGium> TacGia { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<ViTri> ViTris { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiDang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bai_dang", "QLTHUVIEN");

            entity.HasIndex(e => e.ChudeId, "fk_bd_chude");

            entity.HasIndex(e => e.NguoiDungId, "fk_bd_nguoidung");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChudeId).HasColumnName("chude_id");
            entity.Property(e => e.NgaySua)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_sua");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NguoiDungId).HasColumnName("nguoi_dung_id");
            entity.Property(e => e.NoiDung)
                .HasColumnType("text")
                .HasColumnName("noi_dung");
            entity.Property(e => e.SoLuongBinhLuan)
                .HasDefaultValueSql("'0'")
                .HasColumnName("so_luong_binh_luan");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.Chude).WithMany(p => p.BaiDangs)
                .HasForeignKey(d => d.ChudeId)
                .HasConstraintName("fk_bd_chude");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.BaiDangs)
                .HasForeignKey(d => d.NguoiDungId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_bd_nguoidung");
        });

        modelBuilder.Entity<BinhLuan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("binh_luan", "QLTHUVIEN");

            entity.HasIndex(e => e.BaiDangId, "fk_bl_baidang");

            entity.HasIndex(e => e.NguoiDungId, "fk_bl_nguoidung");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaiDangId).HasColumnName("bai_dang_id");
            entity.Property(e => e.NgaySua)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_sua");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NguoiDungId).HasColumnName("nguoi_dung_id");
            entity.Property(e => e.NoiDung)
                .HasColumnType("text")
                .HasColumnName("noi_dung");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.BaiDang).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.BaiDangId)
                .HasConstraintName("fk_bl_baidang");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.NguoiDungId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_bl_nguoidung");
        });

        modelBuilder.Entity<ChuDe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chu_de", "QLTHUVIEN");

            entity.HasIndex(e => e.NguoiDungId, "fk_cd_nguoidung");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MoTa)
                .HasColumnType("text")
                .HasColumnName("mo_ta");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NguoiDungId).HasColumnName("nguoi_dung_id");
            entity.Property(e => e.SoLuongXem)
                .HasDefaultValueSql("'0'")
                .HasColumnName("so_luong_xem");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(500)
                .HasColumnName("tieu_de");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.ChuDes)
                .HasForeignKey(d => d.NguoiDungId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cd_nguoidung");
        });

        modelBuilder.Entity<DangKyCaBiet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dang_ky_ca_biet", "QLTHUVIEN");

            entity.HasIndex(e => e.SachId, "fk_dkcb_sach");

            entity.HasIndex(e => e.VitriId, "fk_dkcb_vitri");

            entity.HasIndex(e => e.MaCaBiet, "ma_ca_biet").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GhiChu)
                .HasColumnType("text")
                .HasColumnName("ghi_chu");
            entity.Property(e => e.MaCaBiet)
                .HasMaxLength(50)
                .HasColumnName("ma_ca_biet");
            entity.Property(e => e.NgayChoMuon)
                .HasColumnType("datetime")
                .HasColumnName("ngay_cho_muon");
            entity.Property(e => e.NgayNhanSach)
                .HasColumnType("datetime")
                .HasColumnName("ngay_nhan_sach");
            entity.Property(e => e.NgaySua)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_sua");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.SachId).HasColumnName("sach_id");
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(50)
                .HasColumnName("tinh_trang");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");
            entity.Property(e => e.VitriId).HasColumnName("vitri_id");

            entity.HasOne(d => d.Sach).WithMany(p => p.DangKyCaBiets)
                .HasForeignKey(d => d.SachId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dkcb_sach");

            entity.HasOne(d => d.Vitri).WithMany(p => p.DangKyCaBiets)
                .HasForeignKey(d => d.VitriId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dkcb_vitri");
        });

        modelBuilder.Entity<DatMuon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dat_muon", "QLTHUVIEN");

            entity.HasIndex(e => e.NguoidungId, "fk_dm_nguoidung");

            entity.HasIndex(e => e.SachId, "fk_dm_sach");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GhiChu)
                .HasColumnType("text")
                .HasColumnName("ghi_chu");
            entity.Property(e => e.NgayDuyet)
                .HasColumnType("datetime")
                .HasColumnName("ngay_duyet");
            entity.Property(e => e.NgayHetHan)
                .HasColumnType("datetime")
                .HasColumnName("ngay_het_han");
            entity.Property(e => e.NgayLay)
                .HasColumnType("datetime")
                .HasColumnName("ngay_lay");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NguoidungId).HasColumnName("nguoidung_id");
            entity.Property(e => e.SachId).HasColumnName("sach_id");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.Nguoidung).WithMany(p => p.DatMuons)
                .HasForeignKey(d => d.NguoidungId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dm_nguoidung");

            entity.HasOne(d => d.Sach).WithMany(p => p.DatMuons)
                .HasForeignKey(d => d.SachId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dm_sach");
        });

        modelBuilder.Entity<FormGopY>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("form_gop_y", "QLTHUVIEN");

            entity.HasIndex(e => e.NguoiDungId, "fk_fgy_nguoidung");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("ho_ten");
            entity.Property(e => e.LienHe)
                .HasMaxLength(255)
                .HasColumnName("lien_he");
            entity.Property(e => e.NgayTao)
                .HasMaxLength(50)
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NguoiDungId).HasColumnName("nguoi_dung_id");
            entity.Property(e => e.NoiDung)
                .HasColumnType("text")
                .HasColumnName("noi_dung");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.FormGopies)
                .HasForeignKey(d => d.NguoiDungId)
                .HasConstraintName("fk_fgy_nguoidung");
        });

        modelBuilder.Entity<MuonTra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("muon_tra", "QLTHUVIEN");

            entity.HasIndex(e => e.DangKyCaBietId, "fk_mt_dkcb");

            entity.HasIndex(e => e.NguoiDungId, "fk_mt_nguoidung");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DangKyCaBietId).HasColumnName("dkcb_id");
            entity.Property(e => e.GhiChu)
                .HasColumnType("text")
                .HasColumnName("ghi_chu");
            entity.Property(e => e.HanTra)
                .HasColumnType("datetime")
                .HasColumnName("han_tra");
            entity.Property(e => e.Loai)
                .HasMaxLength(50)
                .HasColumnName("loai");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NgayTra)
                .HasColumnType("datetime")
                .HasColumnName("ngay_tra");
            entity.Property(e => e.NguoiDungId).HasColumnName("nguoi_dung_id");
            entity.Property(e => e.TienPhat)
                .HasDefaultValueSql("'0'")
                .HasColumnName("tien_phat");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.DangKyCaBiet).WithMany(p => p.MuonTras)
                .HasForeignKey(d => d.DangKyCaBietId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_mt_dkcb");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.MuonTras)
                .HasForeignKey(d => d.NguoiDungId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_mt_nguoidung");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nguoi_dung", "QLTHUVIEN");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("cccd");
            entity.Property(e => e.DanhTieng)
                .HasDefaultValueSql("'0'")
                .HasColumnName("danh_tieng");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(500)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .HasColumnName("gioi_tinh");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .HasColumnName("hinh_anh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("ho_ten");
            entity.Property(e => e.LiDoKhoa)
                .HasMaxLength(500)
                .HasColumnName("li_do_khoa");
            entity.Property(e => e.LiDoThayDoi)
                .HasMaxLength(500)
                .HasColumnName("li_do_thay_doi");
            entity.Property(e => e.LoaiThe)
                .HasMaxLength(50)
                .HasColumnName("loai_the");
            entity.Property(e => e.MaSoThe)
                .HasMaxLength(50)
                .HasColumnName("ma_so_the");
            entity.Property(e => e.NgayHetHan)
                .HasColumnType("datetime")
                .HasColumnName("ngay_het_han");
            entity.Property(e => e.NgayKhoaThe)
                .HasColumnType("datetime")
                .HasColumnName("ngay_khoa_the");
            entity.Property(e => e.NgaySinh)
                .HasColumnType("datetime")
                .HasColumnName("ngay_sinh");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NgayThayDoi)
                .HasColumnType("datetime")
                .HasColumnName("ngay_thay_doi");
            entity.Property(e => e.Quyen)
                .HasMaxLength(50)
                .HasColumnName("quyen");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("sdt");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");
        });

        modelBuilder.Entity<NhaXuatBan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nha_xuat_ban", "QLTHUVIEN");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(500)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GhiChu)
                .HasColumnType("text")
                .HasColumnName("ghi_chu");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("sdt");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("website");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sach", "QLTHUVIEN");

            entity.HasIndex(e => e.NhaxuatbanId, "fk_sach_nxb");

            entity.HasIndex(e => e.TheloaiId, "fk_sach_theloai");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BanMem)
                .HasMaxLength(500)
                .HasColumnName("ban_mem");
            entity.Property(e => e.GiaTien).HasColumnName("gia_tien");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .HasColumnName("hinh_anh");
            entity.Property(e => e.MaIsbn)
                .HasMaxLength(20)
                .HasColumnName("ma_isbn");
            entity.Property(e => e.MoTa)
                .HasColumnType("text")
                .HasColumnName("mo_ta");
            entity.Property(e => e.NamXuatBan)
                .HasMaxLength(10)
                .HasColumnName("nam_xuat_ban");
            entity.Property(e => e.NgaySua)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_sua");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NgonNgu)
                .HasMaxLength(50)
                .HasColumnName("ngon_ngu");
            entity.Property(e => e.NhaxuatbanId).HasColumnName("nhaxuatban_id");
            entity.Property(e => e.PhienBan)
                .HasMaxLength(50)
                .HasColumnName("phien_ban");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("slug");
            entity.Property(e => e.SoLuongChoMuon)
                .HasDefaultValueSql("'0'")
                .HasColumnName("so_luong_cho_muon");
            entity.Property(e => e.SoLuongNhap)
                .HasDefaultValueSql("'0'")
                .HasColumnName("so_luong_nhap");
            entity.Property(e => e.SoLuongTon)
                .HasDefaultValueSql("'0'")
                .HasColumnName("so_luong_ton");
            entity.Property(e => e.SoTrang).HasColumnName("so_trang");
            entity.Property(e => e.TheloaiId).HasColumnName("theloai_id");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(500)
                .HasColumnName("tieu_de");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.Nhaxuatban).WithMany(p => p.Saches)
                .HasForeignKey(d => d.NhaxuatbanId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sach_nxb");

            entity.HasOne(d => d.Theloai).WithMany(p => p.Saches)
                .HasForeignKey(d => d.TheloaiId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sach_theloai");
        });

        modelBuilder.Entity<SachTacgium>(entity =>
        {
            entity.HasKey(e => new { e.SachId, e.TacGiaId }).HasName("PRIMARY");

            entity.ToTable("sach_tacgia", "QLTHUVIEN");

            entity.HasIndex(e => e.TacGiaId, "fk_st_tacgia");

            entity.Property(e => e.SachId).HasColumnName("sach_id");
            entity.Property(e => e.TacGiaId).HasColumnName("tac_gia_id");
            entity.Property(e => e.ThuTu).HasColumnName("thu_tu");
            entity.Property(e => e.VaiTro)
                .HasMaxLength(100)
                .HasColumnName("vai_tro");

            entity.HasOne(d => d.Sach).WithMany(p => p.SachTacgia)
                .HasForeignKey(d => d.SachId)
                .HasConstraintName("fk_st_sach");

            entity.HasOne(d => d.TacGia).WithMany(p => p.SachTacgia)
                .HasForeignKey(d => d.TacGiaId)
                .HasConstraintName("fk_st_tacgia");
        });

        modelBuilder.Entity<TacGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tac_gia", "QLTHUVIEN");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NgaySinh)
                .HasColumnType("datetime")
                .HasColumnName("ngay_sinh");
            entity.Property(e => e.QueHuong)
                .HasMaxLength(255)
                .HasColumnName("que_huong");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("the_loai", "QLTHUVIEN");

            entity.HasIndex(e => e.TheLoaiCha, "fk_theloai_cha");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NgayCapNhat)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_cap_nhat");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
            entity.Property(e => e.TheLoaiCha).HasColumnName("the_loai_cha");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.TheLoaiChaNavigation).WithMany(p => p.InverseTheLoaiChaNavigation)
                .HasForeignKey(d => d.TheLoaiCha)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_theloai_cha");
        });

        modelBuilder.Entity<ViTri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vi_tri", "QLTHUVIEN");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GiaSach)
                .HasMaxLength(100)
                .HasColumnName("gia_sach");
            entity.Property(e => e.KhuVuc)
                .HasMaxLength(100)
                .HasColumnName("khu_vuc");
            entity.Property(e => e.Phong)
                .HasMaxLength(100)
                .HasColumnName("phong");
            entity.Property(e => e.Tang)
                .HasMaxLength(50)
                .HasColumnName("tang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.WebApplication2.Models;

namespace WebApplication2.Models;

public  class DoanmonhocContext : IdentityDbContext<UserModel>
{
    

    public DoanmonhocContext(DbContextOptions<DoanmonhocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoHanh> BaoHanhs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

    public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }

    public virtual DbSet<DonViTinh> DonViTinhs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HangSx> HangSxes { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NguoiDungPhanQuyen> NguoiDungPhanQuyens { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<PhienBan> PhienBans { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<ThoiGianBaoHanh> ThoiGianBaoHanhs { get; set; }

    public virtual DbSet<TonKho> TonKhos { get; set; }
	public virtual DbSet<OrderModel> Orders { get; set; }

	public virtual DbSet<OrderDetails> OrderDetail { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=kyhuynh;Initial Catalog=doanmonhoc;User ID=sa;Password=0393144750;TrustServerCertificate=True");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<BaoHanh>(entity =>
//        {
//            entity.HasKey(e => e.IdBaohanh);

//            entity.ToTable("BaoHanh");

//            entity.Property(e => e.IdBaohanh).HasColumnName("id_baohanh");
//            entity.Property(e => e.IdHoadon).HasColumnName("id_hoadon");
//            entity.Property(e => e.IdSanpham).HasColumnName("id_sanpham");
//            entity.Property(e => e.NgayHetHan).HasColumnType("date");
//            entity.Property(e => e.NgayMua).HasColumnType("date");
//            entity.Property(e => e.TenKhachHang).HasMaxLength(50);

//            entity.HasOne(d => d.IdHoadonNavigation).WithMany(p => p.BaoHanhs)
//                .HasForeignKey(d => d.IdHoadon)
//                .HasConstraintName("FK_BaoHanh_HoaDon");

//            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.BaoHanhs)
//                .HasForeignKey(d => d.IdSanpham)
//                .HasConstraintName("FK_BaoHanh_SanPham");
//        });

//        modelBuilder.Entity<ChiTietHoaDon>(entity =>
//        {
//            entity.HasKey(e => e.IdChitiethoadon);

//            entity.ToTable("ChiTietHoaDon");

//            entity.Property(e => e.IdChitiethoadon).HasColumnName("id_chitiethoadon");
//            entity.Property(e => e.Dongia).HasColumnType("decimal(10, 2)");
//            entity.Property(e => e.IdHoadon).HasColumnName("id_hoadon");
//            entity.Property(e => e.IdSanpham).HasColumnName("id_sanpham");

//            entity.HasOne(d => d.IdHoadonNavigation).WithMany(p => p.ChiTietHoaDons)
//                .HasForeignKey(d => d.IdHoadon)
//                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

//            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.ChiTietHoaDons)
//                .HasForeignKey(d => d.IdSanpham)
//                .HasConstraintName("FK_ChiTietHoaDon_SanPham");
//        });

//        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
//        {
//            entity.HasKey(e => e.IdChitietphieunhap);

//            entity.ToTable("ChiTietPhieuNhap");

//            entity.Property(e => e.IdChitietphieunhap).HasColumnName("id_chitietphieunhap");
//            entity.Property(e => e.IdPhieunhap).HasColumnName("id_phieunhap");
//            entity.Property(e => e.MaSp).HasColumnName("MaSP");

//            entity.HasOne(d => d.IdPhieunhapNavigation).WithMany(p => p.ChiTietPhieuNhaps)
//                .HasForeignKey(d => d.IdPhieunhap)
//                .HasConstraintName("FK_ChiTietPhieuNhap_PhieuNhap");

//            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietPhieuNhaps)
//                .HasForeignKey(d => d.MaSp)
//                .HasConstraintName("FK_ChiTietPhieuNhap_SanPham1");
//        });

//        modelBuilder.Entity<ChiTietPhieuXuat>(entity =>
//        {
//            entity.HasKey(e => e.IdChitietphieuxuat);

//            entity.ToTable("ChiTietPhieuXuat");

//            entity.Property(e => e.IdChitietphieuxuat).HasColumnName("id_chitietphieuxuat");
//            entity.Property(e => e.DonGia).HasColumnName("DonGIa");
//            entity.Property(e => e.IdPhieuxuat).HasColumnName("id_phieuxuat");
//            entity.Property(e => e.MaSp).HasColumnName("MaSP");

//            entity.HasOne(d => d.IdPhieuxuatNavigation).WithMany(p => p.ChiTietPhieuXuats)
//                .HasForeignKey(d => d.IdPhieuxuat)
//                .HasConstraintName("FK_ChiTietPhieuXuat_PhieuXuat2");

//            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietPhieuXuats)
//                .HasForeignKey(d => d.MaSp)
//                .HasConstraintName("FK_ChiTietPhieuXuat_SanPham");
//        });

//        modelBuilder.Entity<DanhMucSanPham>(entity =>
//        {
//            entity.HasKey(e => e.IdDanhmuc).HasName("PK_DanhMuc_1");

//            entity.ToTable("DanhMucSanPham");

//            entity.Property(e => e.IdDanhmuc).HasColumnName("id_danhmuc");
//            entity.Property(e => e.Tendanhmuc)
//                .HasMaxLength(50)
//                .HasColumnName("tendanhmuc");
//        });

//        modelBuilder.Entity<DonViTinh>(entity =>
//        {
//            entity.HasKey(e => e.IdDvt);

//            entity.ToTable("DonViTinh");

//            entity.Property(e => e.IdDvt).HasColumnName("id_DVT");
//            entity.Property(e => e.Active).HasColumnName("active");
//            entity.Property(e => e.TenDvt)
//                .HasMaxLength(50)
//                .HasColumnName("TenDVT");
//        });

//        modelBuilder.Entity<GioHang>(entity =>
//        {
//            entity.HasKey(e => e.IdGiohang);

//            entity.ToTable("GioHang");

//            entity.Property(e => e.IdGiohang).HasColumnName("id_giohang");
//            entity.Property(e => e.IdNguoidung).HasColumnName("id_nguoidung");
//            entity.Property(e => e.IdSanpham).HasColumnName("id_sanpham");

//            entity.HasOne(d => d.IdNguoidungNavigation).WithMany(p => p.GioHangs)
//                .HasForeignKey(d => d.IdNguoidung)
//                .HasConstraintName("FK_GioHang_NguoiDung");
//        });

//        modelBuilder.Entity<HangSx>(entity =>
//        {
//            entity.HasKey(e => e.IdHangsx).HasName("PK_NuocSX");

//            entity.ToTable("HangSX");

//            entity.Property(e => e.IdHangsx).HasColumnName("id_hangsx");
//            entity.Property(e => e.Active).HasColumnName("active");
//            entity.Property(e => e.Tenhangsanxuat)
//                .HasMaxLength(50)
//                .HasColumnName("tenhangsanxuat");
//        });

//        modelBuilder.Entity<HoaDon>(entity =>
//        {
//            entity.HasKey(e => e.IdHoadon);

//            entity.ToTable("HoaDon");

//            entity.Property(e => e.IdHoadon).HasColumnName("id_hoadon");
//            entity.Property(e => e.IdNguoidung).HasColumnName("id_nguoidung");
//            entity.Property(e => e.NgayMua).HasColumnType("date");
//            entity.Property(e => e.TongTien).HasColumnType("decimal(10, 2)");
//            entity.Property(e => e.Trangthai)
//                .HasMaxLength(50)
//                .HasColumnName("trangthai");

//            entity.HasOne(d => d.IdNguoidungNavigation).WithMany(p => p.HoaDons)
//                .HasForeignKey(d => d.IdNguoidung)
//                .HasConstraintName("FK_HoaDon_NguoiDung");
//        });

//        modelBuilder.Entity<KhachHang>(entity =>
//        {
//            entity.HasKey(e => e.MaKh);

//            entity.ToTable("KhachHang");

//            entity.Property(e => e.MaKh).HasColumnName("MaKH");
//            entity.Property(e => e.DiaChi)
//                .HasMaxLength(50)
//                .HasColumnName("DIaChi");
//            entity.Property(e => e.Email).HasMaxLength(50);
//            entity.Property(e => e.TenKh)
//                .HasMaxLength(50)
//                .HasColumnName("TenKH");
//        });

//        modelBuilder.Entity<KhuyenMai>(entity =>
//        {
//            entity.HasKey(e => e.IdKhuyenmai);

//            entity.ToTable("KhuyenMai");

//            entity.Property(e => e.IdKhuyenmai).HasColumnName("id_khuyenmai");
//            entity.Property(e => e.TenKhuyenMai).HasMaxLength(50);
//        });

//        modelBuilder.Entity<Login>(entity =>
//        {
//            entity.HasKey(e => e.IdDangnhap);

//            entity.ToTable("Login");

//            entity.Property(e => e.IdDangnhap).HasColumnName("id_dangnhap");
//            entity.Property(e => e.DiaChi).HasMaxLength(50);
//            entity.Property(e => e.Email).HasMaxLength(50);
//            entity.Property(e => e.HoTen).HasMaxLength(50);
//            entity.Property(e => e.MatKhau).HasMaxLength(50);
//            entity.Property(e => e.Quyen).HasMaxLength(50);
//            entity.Property(e => e.Sdt)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SDT");
//            entity.Property(e => e.TenDangnhap).HasMaxLength(50);
//        });

//        modelBuilder.Entity<NguoiDung>(entity =>
//        {
//            entity.HasKey(e => e.IdNguoidung).HasName("PK__NguoiDun__2725D724BED4A25D");

//            entity.ToTable("NguoiDung");

//            entity.Property(e => e.IdNguoidung).HasColumnName("id_nguoidung");
//            entity.Property(e => e.DiaChi)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.Email)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.Hoten)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.IdDangnhap).HasColumnName("id_dangnhap");
//            entity.Property(e => e.SoDienThoai)
//                .HasMaxLength(10)
//                .IsUnicode(false)
//                .IsFixedLength();

//            entity.HasOne(d => d.IdDangnhapNavigation).WithMany(p => p.NguoiDungs)
//                .HasForeignKey(d => d.IdDangnhap)
//                .HasConstraintName("FK_NguoiDung_Login");
//        });

//        modelBuilder.Entity<NguoiDungPhanQuyen>(entity =>
//        {
//            entity.HasKey(e => e.IdNguoidung);

//            entity.ToTable("NguoiDung_PhanQuyen");

//            entity.Property(e => e.IdNguoidung)
//                .ValueGeneratedNever()
//                .HasColumnName("id_nguoidung");
//            entity.Property(e => e.IdPhanquyen).HasColumnName("id_phanquyen");

//            entity.HasOne(d => d.IdNguoidungNavigation).WithOne(p => p.NguoiDungPhanQuyen)
//                .HasForeignKey<NguoiDungPhanQuyen>(d => d.IdNguoidung)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_NguoiDung_PhanQuyen_NguoiDung");

//            entity.HasOne(d => d.IdPhanquyenNavigation).WithMany(p => p.NguoiDungPhanQuyens)
//                .HasForeignKey(d => d.IdPhanquyen)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_NguoiDung_PhanQuyen_PhanQuyen");
//        });

//        modelBuilder.Entity<NhaCungCap>(entity =>
//        {
//            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEB048EAAFD");

//            entity.ToTable("NhaCungCap");

//            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
//            entity.Property(e => e.DiaChi).HasMaxLength(100);
//            entity.Property(e => e.Email).HasMaxLength(50);
//            entity.Property(e => e.SoDienThoai)
//                .HasMaxLength(10)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.TenNcc)
//                .HasMaxLength(50)
//                .HasColumnName("TenNCC");
//        });

//        modelBuilder.Entity<PhanQuyen>(entity =>
//        {
//            entity.HasKey(e => e.IdPhanquyen);

//            entity.ToTable("PhanQuyen");

//            entity.Property(e => e.IdPhanquyen).HasColumnName("id_phanquyen");
//            entity.Property(e => e.TenQuyen).HasMaxLength(50);
//        });

//        modelBuilder.Entity<PhienBan>(entity =>
//        {
//            entity.HasKey(e => e.IdPhienban);

//            entity.ToTable("PhienBan");

//            entity.Property(e => e.IdPhienban).HasColumnName("id_phienban");
//            entity.Property(e => e.Active).HasColumnName("active");
//            entity.Property(e => e.TenPhienBan).HasMaxLength(50);
//        });

//        modelBuilder.Entity<PhieuNhap>(entity =>
//        {
//            entity.HasKey(e => e.IdPhieunhap).HasName("PK__BanNhapH__3521469EA500629A");

//            entity.ToTable("PhieuNhap");

//            entity.Property(e => e.IdPhieunhap).HasColumnName("id_phieunhap");
//            entity.Property(e => e.IdNguoidung).HasColumnName("id_nguoidung");
//            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
//            entity.Property(e => e.NgayNhap).HasColumnType("date");

//            entity.HasOne(d => d.IdNguoidungNavigation).WithMany(p => p.PhieuNhaps)
//                .HasForeignKey(d => d.IdNguoidung)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_BanNhapHang_NguoiDung");

//            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.PhieuNhaps)
//                .HasForeignKey(d => d.MaNcc)
//                .HasConstraintName("FK_PhieuNhap_NhaCungCap");
//        });

//        modelBuilder.Entity<PhieuXuat>(entity =>
//        {
//            entity.HasKey(e => e.IdPhieuxuat).HasName("PK__BanXuatH__35202A7F8D39B856");

//            entity.ToTable("PhieuXuat");

//            entity.Property(e => e.IdPhieuxuat).HasColumnName("id_phieuxuat");
//            entity.Property(e => e.IdKhuyenmai).HasColumnName("id_khuyenmai");
//            entity.Property(e => e.IdNguoidung).HasColumnName("id_nguoidung");
//            entity.Property(e => e.MaKh).HasColumnName("MaKH");
//            entity.Property(e => e.NgayXuat).HasColumnType("date");

//            entity.HasOne(d => d.IdKhuyenmaiNavigation).WithMany(p => p.PhieuXuats)
//                .HasForeignKey(d => d.IdKhuyenmai)
//                .HasConstraintName("FK_PhieuXuat_KhuyenMai");

//            entity.HasOne(d => d.IdNguoidungNavigation).WithMany(p => p.PhieuXuats)
//                .HasForeignKey(d => d.IdNguoidung)
//                .HasConstraintName("FK_PhieuXuat_NhanVien");

//            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.PhieuXuats)
//                .HasForeignKey(d => d.MaKh)
//                .HasConstraintName("FK_PhieuXuat_KhachHang");
//        });

//        modelBuilder.Entity<SanPham>(entity =>
//        {
//            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C692E7911");

//            entity.ToTable("SanPham");

//            entity.Property(e => e.MaSp)
//                .ValueGeneratedNever()
//                .HasColumnName("MaSP");
//            entity.Property(e => e.IdDanhmuc).HasColumnName("id_danhmuc");
//            entity.Property(e => e.IdDvt).HasColumnName("id_DVT");
//            entity.Property(e => e.IdHangsx).HasColumnName("id_hangsx");
//            entity.Property(e => e.IdPhienban).HasColumnName("id_phienban");
//            entity.Property(e => e.IdThoigianbaohanh).HasColumnName("id_thoigianbaohanh");
//            entity.Property(e => e.Imageurl).HasColumnName("imageurl");
//            entity.Property(e => e.TenSp)
//                .HasMaxLength(50)
//                .HasColumnName("TenSP");

//            entity.HasOne(d => d.IdDanhmucNavigation).WithMany(p => p.SanPhams)
//                .HasForeignKey(d => d.IdDanhmuc)
//                .HasConstraintName("FK_SanPham_DanhMuc");

//            entity.HasOne(d => d.IdDvtNavigation).WithMany(p => p.SanPhams)
//                .HasForeignKey(d => d.IdDvt)
//                .HasConstraintName("FK_SanPham_DonViTinh");

//            entity.HasOne(d => d.IdHangsxNavigation).WithMany(p => p.SanPhams)
//                .HasForeignKey(d => d.IdHangsx)
//                .HasConstraintName("FK_SanPham_NuocSX");

//            entity.HasOne(d => d.IdPhienbanNavigation).WithMany(p => p.SanPhams)
//                .HasForeignKey(d => d.IdPhienban)
//                .HasConstraintName("FK_SanPham_PhienBan");

//            entity.HasOne(d => d.IdThoigianbaohanhNavigation).WithMany(p => p.SanPhams)
//                .HasForeignKey(d => d.IdThoigianbaohanh)
//                .HasConstraintName("FK_SanPham_ThoiGianBaoHanh");
//        });

//        modelBuilder.Entity<ThanhToan>(entity =>
//        {
//            entity.HasKey(e => e.IdThanhtoan);

//            entity.ToTable("ThanhToan");

//            entity.Property(e => e.IdThanhtoan).HasColumnName("id_thanhtoan");
//            entity.Property(e => e.IdHoadon).HasColumnName("id_hoadon");
//            entity.Property(e => e.NgayMua).HasColumnType("date");
//            entity.Property(e => e.PhuongThuc).HasMaxLength(50);
//            entity.Property(e => e.TongTien).HasColumnType("decimal(10, 2)");
//            entity.Property(e => e.TrangThai)
//                .HasMaxLength(10)
//                .IsFixedLength();
//            entity.Property(e => e.TransactionId).HasMaxLength(50);

//            entity.HasOne(d => d.IdHoadonNavigation).WithMany(p => p.ThanhToans)
//                .HasForeignKey(d => d.IdHoadon)
//                .HasConstraintName("FK_ThanhToan_HoaDon");
//        });

//        modelBuilder.Entity<ThoiGianBaoHanh>(entity =>
//        {
//            entity.HasKey(e => e.IdTgbh);

//            entity.ToTable("ThoiGianBaoHanh");

//            entity.Property(e => e.IdTgbh).HasColumnName("id_TGBH");
//            entity.Property(e => e.ThoiGian).HasMaxLength(50);
//        });

//        modelBuilder.Entity<TonKho>(entity =>
//        {
//            entity.HasKey(e => e.IdTonkho);

//            entity.ToTable("TonKho");

//            entity.Property(e => e.IdTonkho).HasColumnName("id_tonkho");
//            entity.Property(e => e.IdChitietphieunhap).HasColumnName("id_chitietphieunhap");
//            entity.Property(e => e.IdChitietphieuxuat).HasColumnName("id_chitietphieuxuat");

//            entity.HasOne(d => d.IdChitietphieunhapNavigation).WithMany(p => p.TonKhos)
//                .HasForeignKey(d => d.IdChitietphieunhap)
//                .HasConstraintName("FK_TonKho_ChiTietPhieuNhap");

//            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TonKhos)
//                .HasForeignKey(d => d.MaSp)
//                .HasConstraintName("FK_TonKho_SanPham");
//        });
        
//		modelBuilder.Entity<OrderDetails>(entity =>
//		{
//			// Các cấu hình khác cho OrderDetails

//			entity.Property(e => e.Price)
//				.HasColumnType("decimal(18, 2)");
//		});
//		OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

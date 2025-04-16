using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NET_Midterm2025.Models;

public partial class ThuVienContext : DbContext
{
    public ThuVienContext()
    {
    }

    public ThuVienContext(DbContextOptions<ThuVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bangcap> Bangcaps { get; set; }

    public virtual DbSet<Docgium> Docgia { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }

    public virtual DbSet<Phieumuonsach> Phieumuonsaches { get; set; }

    public virtual DbSet<Phieuthutien> Phieuthutiens { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<Thamso> Thamsos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bangcap>(entity =>
        {
            entity.HasKey(e => e.MaBangCap);

            entity.ToTable("BANGCAP");

            entity.Property(e => e.TenBangCap).HasMaxLength(40);
        });

        modelBuilder.Entity<Docgium>(entity =>
        {
            entity.HasKey(e => e.MaDocGia);

            entity.ToTable("DOCGIA");

            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.HoTenDocGia).HasMaxLength(40);
            entity.Property(e => e.NgayHetHan).HasColumnType("datetime");
            entity.Property(e => e.NgayLapThe).HasColumnType("datetime");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien);

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.HoTenNhanVien).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");

            entity.HasOne(d => d.MaBangCapNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.MaBangCap)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_NHANVIEN_BANGCAP");
        });

        modelBuilder.Entity<Nhaxuatban>(entity =>
        {
            entity.HasKey(e => e.MaNxb);

            entity.ToTable("NHAXUATBAN");

            entity.Property(e => e.MaNxb)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNXB");
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.TenNxb)
                .HasMaxLength(50)
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<Phieumuonsach>(entity =>
        {
            entity.HasKey(e => e.MaPhieuMuon);

            entity.ToTable("PHIEUMUONSACH");

            entity.Property(e => e.NgayMuon).HasColumnType("datetime");

            entity.HasOne(d => d.MaDocGiaNavigation).WithMany(p => p.Phieumuonsaches)
                .HasForeignKey(d => d.MaDocGia)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PHIEUMUONSACH_DOCGIA");
        });

        modelBuilder.Entity<Phieuthutien>(entity =>
        {
            entity.HasKey(e => e.MaPhieuThuTien);

            entity.ToTable("PHIEUTHUTIEN");

            entity.HasOne(d => d.MaDocGiaNavigation).WithMany(p => p.Phieuthutiens)
                .HasForeignKey(d => d.MaDocGia)
                .HasConstraintName("FK_PHIEUTHUTIEN_DOCGIA");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Phieuthutiens)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PHIEUTHUTIEN_NHANVIEN");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach);

            entity.ToTable("SACH");

            entity.Property(e => e.AnhBia).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.MaNxb)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNXB");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
            entity.Property(e => e.TacGia).HasMaxLength(30);
            entity.Property(e => e.TenSach).HasMaxLength(40);

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_SACH_NHAXUATBAN");

            entity.HasMany(d => d.MaPhieuMuons).WithMany(p => p.MaSaches)
                .UsingEntity<Dictionary<string, object>>(
                    "Chitietphieumuon",
                    r => r.HasOne<Phieumuonsach>().WithMany()
                        .HasForeignKey("MaPhieuMuon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CHITIETPHIEUMUON_PHIEUMUONSACH"),
                    l => l.HasOne<Sach>().WithMany()
                        .HasForeignKey("MaSach")
                        .HasConstraintName("FK_CHITIETPHIEUMUON_SACH"),
                    j =>
                    {
                        j.HasKey("MaSach", "MaPhieuMuon");
                        j.ToTable("CHITIETPHIEUMUON");
                    });
        });

        modelBuilder.Entity<Thamso>(entity =>
        {
            entity.HasKey(e => e.TenThamSo);

            entity.ToTable("THAMSO");

            entity.Property(e => e.TenThamSo).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

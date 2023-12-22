using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHocAPI.Entity;
using System.Data;

namespace QuanLyKhoaHocAPI.AppDBContexxt
{
    public class AppDBContext:DbContext
    {
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<ChuDe> ChuDes { get; set; }
        public DbSet<DangKiHoc> DangKiHocs { get; set; }
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<LoaiBaiViet> LoaiBaiViets { get; set; }
        public DbSet<QuyenHan> QuyenHans { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<TinhTrangHoc> TinhTrangHocs { get; set; }
        public DbSet<LoaiKhoaHoc> LoaiKhoaHocs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server = DESKTOP-FJ29HTR ; Database = QuanLyKhoaHocAPI ; Trusted_Connection = True; TrustServerCertificate = True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

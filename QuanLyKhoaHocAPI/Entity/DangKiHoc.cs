namespace QuanLyKhoaHocAPI.Entity
{
    public class DangKiHoc
    {
        public int ID { get; set; }
        public int? KhoaHocID { get; set; }
        public int? HocVienID { get; set; }
        public DateTime? NgayDangKi {  get; set; }
        public DateTime? NgaybatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? TinhTrangHocID { get; set; }
        public int? TaiKhoanID { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
        public virtual HocVien HocVien { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual TinhTrangHoc TinhTrangHoc { get; set; }
    }
}

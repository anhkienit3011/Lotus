using QuanLyKhoaHocAPI.Entity;

namespace QuanLyKhoaHocAPI.PayLoad.DTOs
{
    public class DangKiHocDTO
    {
        public int? KhoaHocID { get; set; }
        public int? HocVienID { get; set; }
        public DateTime? NgayDangKi { get; set; }
        public DateTime? NgaybatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? TinhTrangHocID { get; set; }
        public int? TaiKhoanID { get; set; }
        
    }
}

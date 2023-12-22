using QuanLyKhoaHocAPI.Entity;

namespace QuanLyKhoaHocAPI.PayLoad.Request.DangKiHoc
{
    public class ThemDangKiHocRequest
    {
        public int? KhoaHocID { get; set; }
        public int? HocVienID { get; set; }
        //public DateTime? NgayDangKi { get; set; }
        //public DateTime? NgaybatDau { get; set; }
        //public DateTime? NgayKetThuc { get; set; }
        //public int? TinhTrangHocID { get; set; }
        public int? TaiKhoanID { get; set; }


    }
}

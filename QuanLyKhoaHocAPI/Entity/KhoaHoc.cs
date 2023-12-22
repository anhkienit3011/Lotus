using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaHocAPI.Entity
{
    public class KhoaHoc
    {
        
        public int KhoaHocID { get; set; }
        public int? LoaiKhoaHocID { get; set; }
        [MaxLength(50)]
        public string? TenKhoaHoc {  get; set; }
        public int? ThoiGianHoc { get; set; }
        public string? GioiThieu { get; set; }
        public string? NoiDung {  get; set; }
        public float? HocPhi { get; set; }
        public int? SoHocVien { get; set; }
        public int? SoLuongMon { get; set; }
        public string? HinhAnh { get; set; }
        
        public virtual LoaiKhoaHoc LoaiKhoaHoc { get; set; }
        

    }
}

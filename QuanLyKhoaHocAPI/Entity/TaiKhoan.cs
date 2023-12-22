using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.Entity
{
    public class TaiKhoan
    {
        public int TaiKhoanID { get; set;}
        [MaxLength(50)]
        public string? TenNguoiDung { get; set;}
        [MaxLength(50)]
        public string? Tai_Khoan {  get; set;}
        [MaxLength(50)]
        public string? MatKhau { get; set; }
        public int? QuyenHanId { get; set;}
        public virtual QuyenHan QuyenHans { get; set;}
    }
}

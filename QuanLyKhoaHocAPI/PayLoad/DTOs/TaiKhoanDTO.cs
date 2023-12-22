using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.DTOs
{
    public class TaiKhoanDTO
    {
        
        public string? TenNguoiDung { get; set; }
        [MaxLength(50)]
        public string? Tai_Khoan { get; set; }
        [MaxLength(50)]
        public string? MatKhau { get; set; }
        public int? QuyenHanId { get; set; }
    }
}

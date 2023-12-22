using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.DTOs
{
    public class BaiVietDTO
    {
        
        [MaxLength(50)]
        public string? TenBaiViet { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        [MaxLength(50)]
        public string? TenTacGia { get; set; }
        public string? NoiDung { get; set; }
        [MaxLength(100)]
        public string? NoiDungNgan { get; set; }
        public string? HinhAnh { get; set; }
        public int? ChuDeID { get; set; }
        public int? TaiKhoanID { get; set; }
    }
}

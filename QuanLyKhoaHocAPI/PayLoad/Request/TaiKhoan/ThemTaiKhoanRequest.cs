using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan
{
    public class ThemTaiKhoanRequest
    {
        
        [MaxLength(50)]
        public string? TenNguoiDung { get; set; }
        [MaxLength(50)]
        public string? Tai_Khoan { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Mật khẩu phải có ít nhất {2} và tối đa {1} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Mật khẩu phải có ít nhất một chữ hoa, một chữ thường, một chữ số và một ký tự đặc biệt.")]

        public string? MatKhau { get; set; }
        public int? QuyenHanId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.Request.LoaiBaiVIet
{
    public class ThemLoaiBaiVietRequest
    {
        
        [MaxLength(50)]
        public string? TenLoai { get; set; }
    }
}

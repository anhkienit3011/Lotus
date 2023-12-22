using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.DTOs
{
    public class LoaiBaiVietDTO
    {
        
        [MaxLength(50)]
        public string? TenLoai { get; set; }
    }
}

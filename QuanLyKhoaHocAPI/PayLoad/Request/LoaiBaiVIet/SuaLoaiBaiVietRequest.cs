using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.Request.LoaiBaiVIet
{
    public class SuaLoaiBaiVietRequest
    {
        public int LoaiBaiVietID { get; set; }
        [MaxLength(50)]
        public string? TenLoai { get; set; }
    }
}

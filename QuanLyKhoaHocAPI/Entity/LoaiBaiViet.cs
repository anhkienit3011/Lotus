using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.Entity
{
    public class LoaiBaiViet
    {
        public int LoaiBaiVietID { get; set; }
        [MaxLength(50)]
        public string? TenLoai {  get; set; }
    }
}

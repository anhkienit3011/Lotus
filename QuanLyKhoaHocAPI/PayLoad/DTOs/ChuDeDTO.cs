using QuanLyKhoaHocAPI.Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.DTOs
{
    public class ChuDeDTO
    {
        
        [MaxLength(50)]
        public string? TenChuDe { get; set; }
        public string? NoiDung { get; set; }
        public int? LoaiBaiVietID { get; set; }
        
    }
}

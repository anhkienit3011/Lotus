using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.Entity
{
    public class ChuDe
    {
        public int ChuDeID { get; set; }
        [MaxLength(50)]
        public string? TenChuDe {  get; set; }
        public string? NoiDung {  get; set; }
        public int? LoaiBaiVietID { get; set; }
        public virtual LoaiBaiViet LoaiBaiViet { get; set; }
    }
}

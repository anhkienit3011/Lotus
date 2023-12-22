using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.Request.ChuDe
{
    public class SuaChuDeRequest
    {
        public int ChuDeID { get; set; }
        [MaxLength(50)]
        public string? TenChuDe { get; set; }
        public string? NoiDung { get; set; }
        public int? LoaiBaiVietID { get; set; }
    }
}

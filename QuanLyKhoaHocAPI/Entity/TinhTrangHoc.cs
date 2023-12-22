using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.Entity
{
    public class TinhTrangHoc
    {
        public int TinhTrangHocID { get; set; }
        [MaxLength(40)]
        public string? TenTinhTrang {  get; set; }
    }
}

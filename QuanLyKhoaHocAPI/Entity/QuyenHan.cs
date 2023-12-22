using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.Entity
{
    public class QuyenHan
    {
        public int QuyenHanID { get; set; }
        [MaxLength(50)]
        public string? TenQuyenHan {  get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.Request.QuyenHanRequest
{
    public class SuaQuyenHanRequest
    {
        public int QuyenHanID { get; set; }
        [MaxLength(50)]
        public string? TenQuyenHan { get; set; }
    }
}

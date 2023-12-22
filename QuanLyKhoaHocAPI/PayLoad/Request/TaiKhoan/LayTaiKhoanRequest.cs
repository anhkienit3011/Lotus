using QuanLyKhoaHocAPI.Entity;

namespace QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan
{
    public class LayTaiKhoanRequest
    {
        public string? NameKeyWord { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

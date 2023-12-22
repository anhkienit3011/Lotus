using QuanLyKhoaHocAPI.Entity;

namespace QuanLyKhoaHocAPI.PayLoad.Request.BaiViet
{
    public class LayBaiVietRequest
    {
        public string? NameKeyWord { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

using QuanLyKhoaHocAPI.Entity;

namespace QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc
{
    public class LayKhoaHoc
    {
        public string? NameKeyWord { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

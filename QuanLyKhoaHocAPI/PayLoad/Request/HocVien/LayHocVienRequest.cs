using QuanLyKhoaHocAPI.Entity;

namespace QuanLyKhoaHocAPI.PayLoad.Request.HocVien
{
    public class LayHocVienRequest
    {
        public string? NameKeyWord { get; set; }
        public string? EmailKeyWord { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

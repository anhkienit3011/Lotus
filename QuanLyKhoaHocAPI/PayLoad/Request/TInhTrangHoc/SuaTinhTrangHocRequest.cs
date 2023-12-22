using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.Request.TInhTrangHoc
{
    public class SuaTinhTrangHocRequest
    {
        public int TinhTrangHocID { get; set; }
        [MaxLength(40)]
        public string? TenTinhTrang { get; set; }
    }
}

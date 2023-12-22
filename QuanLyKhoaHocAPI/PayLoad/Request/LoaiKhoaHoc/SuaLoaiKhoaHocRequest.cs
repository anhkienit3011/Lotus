using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc
{
    public class SuaLoaiKhoaHocRequest
    {
        public int LoaiKhoaHocID { get; set; }        
        public string? TenLoai { get; set; }
    }
}

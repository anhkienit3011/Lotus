using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.Entity
{
    public class LoaiKhoaHoc
    {
        public int LoaiKhoaHocID { get; set; }
        [MaxLength(30)]
        public string? TenLoai {  get; set; }
    }
}

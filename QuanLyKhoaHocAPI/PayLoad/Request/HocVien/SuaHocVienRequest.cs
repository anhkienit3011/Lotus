using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHocAPI.PayLoad.Request.HocVien
{
    public class SuaHocVienRequest
    {
        public int HocVienID { get; set; }
        public string? HinhAnh { get; set; }
        [MaxLength(50)]
        public string? HoTen { get; set; }
        public string? NgaySinh { get; set; }
        [Column(TypeName = "varchar(11)")]
        public string? SDT { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? TinhThanh { get; set; }
        [MaxLength(50)]
        public string? QuanHuyen { get; set; }
        [MaxLength(50)]
        public string? PhuongXa { get; set; }
        [MaxLength(50)]
        public string? SoNha { get; set; }
    }
}

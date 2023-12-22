using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaHocAPI.Entity
{
    public class HocVien
    {
        [Key]
        public int HocVienID { get; set; }
        public string? HinhAnh { get; set; }
        [MaxLength(50)]
        public string? HoTen {  get; set; }
        public string? NgaySinh { get; set; }
        [Column(TypeName = "varchar(11)")]
        public string? SDT { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? TinhThanh { get; set; }
        [MaxLength(50)]
        public string? QuanHuyen {  get; set; }
        [MaxLength(50)]
        public string? PhuongXa { get; set; }
        [MaxLength(50)]
        public string? SoNha {  get; set; }
        public IEnumerable<DangKiHoc> DangKiHocs { get; set; }
    }
}

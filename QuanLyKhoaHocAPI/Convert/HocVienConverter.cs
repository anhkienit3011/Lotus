using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.HocVien;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;

namespace QuanLyKhoaHocAPI.Convert
{
    public class HocVienConverter
    {
        public HocVienDTO EntityToDTO(HocVien hocVien)
        {
            return new HocVienDTO
            {
                HinhAnh = hocVien.HinhAnh,
                HoTen = hocVien.HoTen,
                Email = hocVien.Email,
                NgaySinh = hocVien.NgaySinh,
                SDT = hocVien.SDT,
                PhuongXa = hocVien.PhuongXa,
                QuanHuyen = hocVien.QuanHuyen,
                SoNha = hocVien.SoNha,
                TinhThanh = hocVien.TinhThanh
    };
        }
        public HocVien ThemHocVien(ThemHocVienRequest request)
        {
            return new HocVien
            {
                HoTen = request.HoTen,
                Email = request.Email,
                HinhAnh = request.HinhAnh,
                NgaySinh = request.NgaySinh,
                SDT = request.SDT,
                TinhThanh = request.TinhThanh,
                QuanHuyen = request.QuanHuyen,
                PhuongXa= request.PhuongXa,
                SoNha= request.SoNha
            };
        }
        public HocVien SuaHocVien(HocVien hocvien, SuaHocVienRequest request)
        {
            hocvien.HinhAnh = request.HinhAnh;
            hocvien.HoTen = request.HoTen;
            hocvien.Email = request.Email;
            hocvien.NgaySinh = request.NgaySinh;
            hocvien.SDT = request.SDT;
            hocvien.TinhThanh= request.TinhThanh;
            hocvien.QuanHuyen = request.QuanHuyen;
            hocvien.PhuongXa = request.PhuongXa;
            hocvien.SoNha = request.SoNha;
            return hocvien;
        }
    }
}

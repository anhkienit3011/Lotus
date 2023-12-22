using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan;

namespace QuanLyKhoaHocAPI.Convert
{
    public class TaiKhoanConverter
    {
        public TaiKhoanDTO EntityToDTO(TaiKhoan taikhoan)
        {
            return new TaiKhoanDTO
            {
                Tai_Khoan = taikhoan.Tai_Khoan,
                MatKhau = taikhoan.MatKhau,
                QuyenHanId = taikhoan.QuyenHanId,
                TenNguoiDung = taikhoan.TenNguoiDung
            };
        }
        public TaiKhoan ThemTaiKhoan(ThemTaiKhoanRequest request)
        {
            return new TaiKhoan
            {
                TenNguoiDung = request.TenNguoiDung,
                MatKhau = request.MatKhau,
                Tai_Khoan = request.Tai_Khoan,
                QuyenHanId = request.QuyenHanId
                
            };
        }
        public TaiKhoan SuaTaiKhoan(TaiKhoan taikhoan, SuaTaiKhoanRequest request)
        {
            taikhoan.TenNguoiDung = request.TenNguoiDung;
            taikhoan.Tai_Khoan = request.Tai_Khoan;
            taikhoan.MatKhau = request.MatKhau;
            taikhoan.QuyenHanId = request.QuyenHanId; return taikhoan;
        }
    }
}

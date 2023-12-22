using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.BaiViet;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;

namespace QuanLyKhoaHocAPI.Convert
{
    public class BaiVietConverter
    {
        public BaiVietDTO EntityToDTO(BaiViet baiviet)
        {
            return new BaiVietDTO
            {
                ChuDeID = baiviet.ChuDeID,
                HinhAnh = baiviet.HinhAnh,
                NoiDung = baiviet.NoiDung,
                NoiDungNgan = baiviet.NoiDungNgan,
                TaiKhoanID = baiviet.TaiKhoanID,
                TenBaiViet = baiviet.TenBaiViet,
                TenTacGia = baiviet.TenTacGia,
                ThoiGianTao = baiviet.ThoiGianTao
            };
        }
        public BaiViet ThemBaiViet(ThemBaiVietRequest request)
        {
            return new BaiViet
            {
                ChuDeID = request.ChuDeID,
                HinhAnh = request.HinhAnh,
                NoiDung = request.NoiDung,
                NoiDungNgan = request.NoiDungNgan,
                TaiKhoanID = request.TaiKhoanID,
                TenBaiViet = request.TenBaiViet,
                TenTacGia = request.TenTacGia,
                ThoiGianTao = DateTime.Now

            };
        }
        public BaiViet SuaBaiViet(BaiViet baiviet, SuaBaiVietRequest request)
        {
            baiviet.TenBaiViet = request.TenBaiViet;
            baiviet.ChuDeID = request.ChuDeID;
            baiviet.NoiDung = request.NoiDung;
            baiviet.NoiDungNgan = request.NoiDungNgan;
            baiviet.TaiKhoanID = request.TaiKhoanID;
            baiviet.TenTacGia = request .TenTacGia;
            baiviet.HinhAnh= request .HinhAnh;
            return baiviet;
        }
    }
}

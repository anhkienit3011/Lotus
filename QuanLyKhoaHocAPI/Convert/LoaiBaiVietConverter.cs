using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiBaiVIet;
using QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan;

namespace QuanLyKhoaHocAPI.Convert
{
    public class LoaiBaiVietConverter
    {
        public LoaiBaiVietDTO EntityToDTO(LoaiBaiViet loaibaiviet)
        {
            return new LoaiBaiVietDTO
            {
                TenLoai = loaibaiviet.TenLoai
            };
        }
        public LoaiBaiViet ThemLoaiBaiViet(ThemLoaiBaiVietRequest request)
        {
            return new LoaiBaiViet
            {
                TenLoai = request.TenLoai

            };
        }
        public LoaiBaiViet SuaLoaiBaiViet(LoaiBaiViet loaibaiviet, SuaLoaiBaiVietRequest request)
        {
            loaibaiviet.TenLoai = request.TenLoai;
            return loaibaiviet;
        }
    }
}

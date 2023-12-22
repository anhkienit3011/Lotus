using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;

namespace QuanLyKhoaHocAPI.Convert
{
    public class LoaiKhoaHocConverter
    {
        public LoaiKhoaHocDTO EntityToDTO(LoaiKhoaHoc loaiKhoaHoc)
        {
            return new LoaiKhoaHocDTO
            {
                TenLoai = loaiKhoaHoc.TenLoai
            };
        }
        public LoaiKhoaHoc ThemLoaiKhoaHoc(ThemLoaiKhoaHocRequest request)
        {
            return new LoaiKhoaHoc
            {
                TenLoai = request.TenLoai
            };
        }
        public LoaiKhoaHoc SuaLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHoc,SuaLoaiKhoaHocRequest request)
        {
            loaiKhoaHoc.TenLoai = request.TenLoai;
            return loaiKhoaHoc;
        }
    }
}

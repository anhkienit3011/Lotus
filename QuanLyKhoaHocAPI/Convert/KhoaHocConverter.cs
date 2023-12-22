using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;

namespace QuanLyKhoaHocAPI.Convert
{
    public class KhoaHocConverter
    {
        public KhoaHocDTO EntityToDTO(KhoaHoc khoaHoc)
        {
            return new KhoaHocDTO
            {
                LoaiKhoaHocID = khoaHoc.LoaiKhoaHocID,
                TenKhoaHoc = khoaHoc.TenKhoaHoc,
                ThoiGianHoc = khoaHoc.ThoiGianHoc,
                GioiThieu = khoaHoc.GioiThieu,
                NoiDung = khoaHoc.NoiDung,
                HocPhi = khoaHoc.HocPhi,
                HinhAnh = khoaHoc.HinhAnh,
                SoHocVien = khoaHoc.SoHocVien,
                SoLuongMon = khoaHoc.SoLuongMon
            };
        }
        public KhoaHoc ThemKhoaHoc(ThemKhoaHocRequest request)
        {
            return new KhoaHoc
            {
                LoaiKhoaHocID = request.LoaiKhoaHocID,
                TenKhoaHoc = request.TenKhoaHoc,
                ThoiGianHoc = request.ThoiGianHoc,
                GioiThieu = request.GioiThieu,
                NoiDung = request.NoiDung,
                HocPhi = request.HocPhi,
                HinhAnh = request.HinhAnh,
                SoHocVien = 0,
                SoLuongMon = request.SoLuongMon
            };
        }
        public KhoaHoc SuaKhoaHoc(KhoaHoc KhoaHoc, SuaKhoaHocRequest request)
        {
            KhoaHoc.LoaiKhoaHocID = request.LoaiKhoaHocID;
            KhoaHoc.TenKhoaHoc = request.TenKhoaHoc;
            KhoaHoc.ThoiGianHoc = request.ThoiGianHoc;
            KhoaHoc.GioiThieu = request.GioiThieu;
            KhoaHoc.NoiDung = request.NoiDung;
            KhoaHoc.HocPhi = request.HocPhi;
            KhoaHoc.HinhAnh = request .HinhAnh;
            KhoaHoc.SoHocVien = request .SoHocVien;
            KhoaHoc.SoLuongMon = request .SoLuongMon;
            return KhoaHoc;
        }
    }
}

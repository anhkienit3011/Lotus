using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.DangKiHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;

namespace QuanLyKhoaHocAPI.Convert
{
    public class DangKiHocConverter
    {
        public DangKiHocDTO EntityToDTO(DangKiHoc dangkiHoc)
        {
            return new DangKiHocDTO
            {
                HocVienID = dangkiHoc.HocVienID,
                KhoaHocID = dangkiHoc.KhoaHocID,
                NgaybatDau = dangkiHoc.NgaybatDau,
                NgayKetThuc = dangkiHoc.NgayKetThuc,
                NgayDangKi = dangkiHoc.NgayDangKi,
                TaiKhoanID = dangkiHoc.TaiKhoanID,
                TinhTrangHocID = dangkiHoc.TinhTrangHocID
            };
        }
        public DangKiHoc ThemDangKiHoc(ThemDangKiHocRequest request)
        {
            return new DangKiHoc
            {
                HocVienID = request.HocVienID,
                KhoaHocID = request.KhoaHocID,                               
                NgayDangKi = DateTime.Now,
                NgaybatDau = null,
                NgayKetThuc = null,
                TaiKhoanID = null,
                TinhTrangHocID = null
            };
        }
        public DangKiHoc SuaDangKiHoc(DangKiHoc dangkihoc, SuaDangKiHocRequest request)
        {
            dangkihoc.ID = request.ID;
            dangkihoc.HocVienID = request.HocVienID;
            dangkihoc.TinhTrangHocID = request.TinhTrangHocID;
            dangkihoc.NgayDangKi = null;
            dangkihoc.NgayKetThuc = null;
            dangkihoc.TaiKhoanID = request.TaiKhoanID;
            dangkihoc.KhoaHocID = request.KhoaHocID; return dangkihoc;
        }
    }
}

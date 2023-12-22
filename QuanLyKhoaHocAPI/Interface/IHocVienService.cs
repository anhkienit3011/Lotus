using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.HocVien;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface IHocVienService
    {
        ResponseObject<HocVienDTO> ThemHocVien(ThemHocVienRequest request);
        ResponseObject<HocVienDTO> SuaHocVien(SuaHocVienRequest request);
        ResponseObject<HocVienDTO> XoaHocVien(XoaHocVienRequest request);
        public PageResult<HocVienDTO> LayHocVien(LayHocVienRequest request);
    }
}

using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface iTaiKhoanService
    {
        ResponseObject<TaiKhoanDTO> ThemTaiKhoan(ThemTaiKhoanRequest request);
        ResponseObject<TaiKhoanDTO> SuaTaiKhoan(SuaTaiKhoanRequest request);
        ResponseObject<TaiKhoanDTO> XoaTaiKhoan(XoaTaiKhoanRequest request);
        PageResult<TaiKhoanDTO> LayTaiKhoan(LayTaiKhoanRequest request);
    }
}

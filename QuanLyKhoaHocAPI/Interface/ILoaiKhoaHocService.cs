using Azure;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface ILoaiKhoaHocService
    {
        ResponseObject<LoaiKhoaHocDTO> ThemLoaiKhoaHoc(ThemLoaiKhoaHocRequest request);
        ResponseObject<LoaiKhoaHocDTO> SuaLoaiKhoaHoc(SuaLoaiKhoaHocRequest request);
        ResponseObject<LoaiKhoaHocDTO> XoaLoaiKhoaHoc(XoaLoaiKhoaHocRequest request);
    }
}

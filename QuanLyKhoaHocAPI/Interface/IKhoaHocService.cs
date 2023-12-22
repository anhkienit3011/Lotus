using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface IKhoaHocService
    {
        ResponseObject<KhoaHocDTO> ThemKhoaHoc(ThemKhoaHocRequest request);
        ResponseObject<KhoaHocDTO> SuaKhoaHoc(SuaKhoaHocRequest request);
        ResponseObject<KhoaHocDTO> XoaKhoaHoc(XoaKhoaHocRequest request);
        public PageResult<KhoaHocDTO> LayKhoaHoc(LayKhoaHoc request);
    }
}

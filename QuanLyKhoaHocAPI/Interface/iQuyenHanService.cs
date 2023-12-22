using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.DangKiHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.QuyenHanRequest;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface iQuyenHanService
    {
        ResponseObject<QuyenHanDTO> ThemQuyenHan(ThemQuyenHanRequest request);
        ResponseObject<QuyenHanDTO> SuaQuyenHan(SuaQuyenHanRequest request);
        ResponseObject<QuyenHanDTO> XoaQuyenHan(XoaQuyenHanRequest request);
        public PageResult<QuyenHanDTO> LayQuyenHan(LayQuyenHanRequest request);
    }
}

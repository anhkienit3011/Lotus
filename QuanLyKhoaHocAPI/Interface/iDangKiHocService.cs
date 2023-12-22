using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.DangKiHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface iDangKiHocService
    {
        ResponseObject<DangKiHocDTO> ThemDangKiHoc(ThemDangKiHocRequest request);
        ResponseObject<DangKiHocDTO> SuaDangKiHoc(SuaDangKiHocRequest request);
        ResponseObject<DangKiHocDTO> XoaDangKiHoc(XoaDangKiHocRequest request);
        public PageResult<DangKiHocDTO> LayDangKihoc(LayDangKiHocRequest request);
    }
}

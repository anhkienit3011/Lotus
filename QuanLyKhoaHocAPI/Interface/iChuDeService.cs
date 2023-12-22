using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;
using QuanLyKhoaHocAPI.PayLoad.Request.DangKiHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface iChuDeService
    {
        ResponseObject<ChuDeDTO> ThemChuDe(ThemChuDeRequest request);
        ResponseObject<ChuDeDTO> SuaChuDe(SuaChuDeRequest request);
        ResponseObject<ChuDeDTO> XoaChuDe(XoaChuDeRequest request);
        PageResult<ChuDeDTO> LayChuDe(LayChuDeRequest request);
    }
}

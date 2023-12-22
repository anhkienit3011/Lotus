using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.HocVien;
using QuanLyKhoaHocAPI.PayLoad.Request.TInhTrangHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface ITinhTrangHocService
    {
        ResponseObject<TinhTrangHocDTO> ThemTinhTrangHoc(ThemTinhTrangHocRequest request);
        ResponseObject<TinhTrangHocDTO> SuaTinhTrangHoc(SuaTinhTrangHocRequest request);
        ResponseObject<TinhTrangHocDTO> XoaTinhTrangHoc(XoaTinhTrangHoc request);
        public IQueryable<TinhTrangHocDTO> LayTinhTrangHoc();
    }
}

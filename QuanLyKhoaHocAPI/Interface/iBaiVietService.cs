using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.BaiViet;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface iBaiVietService
    {
        ResponseObject<BaiVietDTO> ThemBaiViet(ThemBaiVietRequest request);
        ResponseObject<BaiVietDTO> SuaBaiViet(SuaBaiVietRequest request);
        ResponseObject<BaiVietDTO> XoaBaiViet(XoaBaiVietRequest request);
        PageResult<BaiVietDTO> LayBaiViet(LayBaiVietRequest request);
    }
}


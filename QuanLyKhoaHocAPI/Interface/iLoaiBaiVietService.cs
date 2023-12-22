using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiBaiVIet;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Interface
{
    public interface iLoaiBaiVietService
    {
        ResponseObject<LoaiBaiVietDTO> ThemLoaiBaiViet(ThemLoaiBaiVietRequest request);
        ResponseObject<LoaiBaiVietDTO> SuaLoaiBaiViet(SuaLoaiBaiVietRequest request);
        ResponseObject<LoaiBaiVietDTO> XoaLoaiBaiViet(XoaLoaiBaiVietRequest request);
         PageResult<LoaiBaiVietDTO> LayLoaiBaiViet(LayLoaiBaiVietRequest request);
    }
}

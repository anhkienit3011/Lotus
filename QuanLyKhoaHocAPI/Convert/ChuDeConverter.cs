using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiBaiVIet;

namespace QuanLyKhoaHocAPI.Convert
{
    public class ChuDeConverter
    {
        public ChuDeDTO EntityToDTO(ChuDe chude)
        {
            return new ChuDeDTO
            {
                TenChuDe = chude.TenChuDe,
                NoiDung = chude.NoiDung,
                LoaiBaiVietID = chude.LoaiBaiVietID
            };
        }
        public ChuDe ThemChuDe(ThemChuDeRequest request)
        {
            return new ChuDe
            {
                TenChuDe = request.TenChuDe,
                NoiDung = request.NoiDung,
                LoaiBaiVietID = request.LoaiBaiVietID

            };
        }
        public ChuDe SuaChuDe(ChuDe chude, SuaChuDeRequest request)
        {
            chude.TenChuDe = request.TenChuDe;
            chude.NoiDung = request.NoiDung;
            chude.LoaiBaiVietID = request.LoaiBaiVietID; return chude;
        }
    }
}

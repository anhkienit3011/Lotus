using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.HocVien;
using QuanLyKhoaHocAPI.PayLoad.Request.TInhTrangHoc;

namespace QuanLyKhoaHocAPI.Convert
{
    public class TinhTrangHocConverter
    {
        public TinhTrangHocDTO EntityToDTO(TinhTrangHoc tinhTrangHoc)
        {
            return new TinhTrangHocDTO
            {
                TenTinhTrang = tinhTrangHoc.TenTinhTrang
            };
        }
        public TinhTrangHoc ThemTinhTrangHoc(ThemTinhTrangHocRequest request)
        {
            return new TinhTrangHoc
            {
                TenTinhTrang = request.TenTinhTrang
            };
        }
        public TinhTrangHoc SuaTinhTrangHoc(TinhTrangHoc tinhTrangHoc, SuaTinhTrangHocRequest request)
        {
            tinhTrangHoc.TenTinhTrang = request.TenTinhTrang; return tinhTrangHoc;
        }
    }
}

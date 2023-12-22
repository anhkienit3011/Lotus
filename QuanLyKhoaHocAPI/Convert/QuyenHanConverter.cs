using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.QuyenHanRequest;

namespace QuanLyKhoaHocAPI.Convert
{
    public class QuyenHanConverter
    {
        public QuyenHanDTO EntityToDTO(QuyenHan quyenhan)
        {
            return new QuyenHanDTO
            {
                TenQuyenHan = quyenhan.TenQuyenHan
            };
        }
        public QuyenHan ThemQuyenHan(ThemQuyenHanRequest request)
        {
            return new QuyenHan
            {
                TenQuyenHan = request.TenQuyenHan
            };
        }
        public QuyenHan SuaQuyenHan(QuyenHan quyenhan, SuaQuyenHanRequest request)
        {
            quyenhan.TenQuyenHan = request.TenQuyenHan;
            return quyenhan;
        }
    }
}

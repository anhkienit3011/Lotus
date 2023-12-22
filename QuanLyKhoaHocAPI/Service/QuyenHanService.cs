using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.QuyenHanRequest;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class QuyenHanService : iQuyenHanService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<QuyenHanDTO> responseObject;
        private readonly QuyenHanConverter converter;
        public QuyenHanService()
        {
            appDBContext = new AppDBContext();
            converter = new QuyenHanConverter();
            responseObject = new ResponseObject<QuyenHanDTO>();
        }
        public PageResult<QuyenHanDTO> LayQuyenHan(LayQuyenHanRequest request)
        {
            var lstQuyenHan = appDBContext.QuyenHans.AsQueryable();
            if (lstQuyenHan.Count() == 0)
            {
                throw new Exception("Không tìm thấy khoa hoc nào theo yêu cầu !");
            }
            Pagination pagination = new Pagination();
            pagination.PageNumber = request.PageNumber;
            pagination.PageSize = request.PageSize;
            var res = PageResult<QuyenHanDTO>.ToPageResult(pagination, lstQuyenHan.Select(x => converter.EntityToDTO(x)));
            pagination.TotalCount = res.Count();
            return new PageResult<QuyenHanDTO>(pagination, res);
        }

        public ResponseObject<QuyenHanDTO> SuaQuyenHan(SuaQuyenHanRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkQuyenHan = appDBContext.QuyenHans.FirstOrDefault(x => x.QuyenHanID == request.QuyenHanID);
                if (checkQuyenHan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Quyen han chua ton tai! !", null);
                }
                QuyenHan quyenhanSua = converter.SuaQuyenHan(checkQuyenHan, request);
                appDBContext.QuyenHans.Update(quyenhanSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(quyenhanSua));
            }
        }

        public ResponseObject<QuyenHanDTO> ThemQuyenHan(ThemQuyenHanRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkQuyenHan = appDBContext.QuyenHans.FirstOrDefault(x => x.TenQuyenHan == request.TenQuyenHan);
                if (checkQuyenHan != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Quyen han da ton tai !", null);
                }
                QuyenHan QuyenHanThem = converter.ThemQuyenHan(request);
                appDBContext.QuyenHans.Add(QuyenHanThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(QuyenHanThem));
            }
        }

        public ResponseObject<QuyenHanDTO> XoaQuyenHan(XoaQuyenHanRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkQuyenHan = appDBContext.QuyenHans.FirstOrDefault(x => x.QuyenHanID == request.QuyenHanID);
                if (checkQuyenHan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Quyen han chua ton tai! !", null);
                }
                var quyenhanXoa = appDBContext.QuyenHans.Find(request.QuyenHanID);
                appDBContext.QuyenHans.Remove(quyenhanXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(quyenhanXoa));
            }
        }
    }
}

using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.TInhTrangHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class TinhTrangHocService:ITinhTrangHocService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<TinhTrangHocDTO> responseObject;
        private readonly TinhTrangHocConverter converter;
        public TinhTrangHocService()
        {
            appDBContext = new AppDBContext();
            converter = new TinhTrangHocConverter();
            responseObject = new ResponseObject<TinhTrangHocDTO>();
        }



        public ResponseObject<TinhTrangHocDTO> ThemTinhTrangHoc(ThemTinhTrangHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkTinhTrang = appDBContext.TinhTrangHocs.FirstOrDefault(x => x.TenTinhTrang == request.TenTinhTrang);
                if (checkTinhTrang != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tinh trang hoc da ton tai !", null);
                }
                TinhTrangHoc TinhTrangHocThem = converter.ThemTinhTrangHoc(request);
                appDBContext.TinhTrangHocs.Add(TinhTrangHocThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(TinhTrangHocThem));
            }

        }



        public ResponseObject<TinhTrangHocDTO> SuaTinhTrangHoc(SuaTinhTrangHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkTinhTrang = appDBContext.TinhTrangHocs.FirstOrDefault(x => x.TinhTrangHocID == request.TinhTrangHocID);
                if (checkTinhTrang == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tinh trang hoc chua ton tai! !", null);
                }
                TinhTrangHoc TinhTrangHocSua = converter.SuaTinhTrangHoc(checkTinhTrang, request);
                appDBContext.TinhTrangHocs.Update(TinhTrangHocSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(TinhTrangHocSua));
            }
        }

        public ResponseObject<TinhTrangHocDTO> XoaTinhTrangHoc(XoaTinhTrangHoc request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkTinhTrang = appDBContext.TinhTrangHocs.FirstOrDefault(x => x.TinhTrangHocID == request.TinhTrangHocID);
                if (checkTinhTrang == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tinh trang hoc chua ton tai! !", null);
                }
                var TinhTrangHocXoa = appDBContext.TinhTrangHocs.Find(request.TinhTrangHocID);
                appDBContext.TinhTrangHocs.Remove(TinhTrangHocXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(TinhTrangHocXoa));
            }
        }

        public IQueryable<TinhTrangHocDTO> LayTinhTrangHoc()
        {
            var CheckTinhTrangHoc = appDBContext.TinhTrangHocs.AsQueryable();
            if(CheckTinhTrangHoc.Count() == 0)
            {
                throw new Exception("Chua co tinh trang hoc nao !");
            }
            return CheckTinhTrangHoc.Select(x=> converter.EntityToDTO(x));
        }
    }
}

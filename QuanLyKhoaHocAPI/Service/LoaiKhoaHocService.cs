using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class LoaiKhoaHocService : ILoaiKhoaHocService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<LoaiKhoaHocDTO> responseObject;
        private readonly LoaiKhoaHocConverter converter;
        public LoaiKhoaHocService()
        {
            appDBContext = new AppDBContext();
            converter = new LoaiKhoaHocConverter();
            responseObject = new ResponseObject<LoaiKhoaHocDTO>();
        }



        public ResponseObject<LoaiKhoaHocDTO> ThemLoaiKhoaHoc(ThemLoaiKhoaHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkKhoaHoc = appDBContext.LoaiKhoaHocs.FirstOrDefault(x => x.TenLoai == request.TenLoai);
                if(checkKhoaHoc != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, "Loai khoa hoc da ton tai !", null);
                }
                LoaiKhoaHoc LoaiKhoaHocThem = converter.ThemLoaiKhoaHoc(request);
                appDBContext.LoaiKhoaHocs.Add(LoaiKhoaHocThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ",converter.EntityToDTO(LoaiKhoaHocThem));
            }

        }
        public ResponseObject<LoaiKhoaHocDTO> SuaLoaiKhoaHoc(SuaLoaiKhoaHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkKhoaHoc = appDBContext.LoaiKhoaHocs.FirstOrDefault(x => x.LoaiKhoaHocID == request.LoaiKhoaHocID);
                if (checkKhoaHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, "Loai khoa hoc chua ton tai! !", null);
                }
                LoaiKhoaHoc LoaiKhoaHocSua = converter.SuaLoaiKhoaHoc(checkKhoaHoc,request);
                appDBContext.LoaiKhoaHocs.Update(LoaiKhoaHocSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(LoaiKhoaHocSua));
            }

        }
        public ResponseObject<LoaiKhoaHocDTO> XoaLoaiKhoaHoc(XoaLoaiKhoaHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkKhoaHoc = appDBContext.LoaiKhoaHocs.FirstOrDefault(x => x.LoaiKhoaHocID == request.LoaiKhoaHocID);
                if (checkKhoaHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, "Loai khoa hoc chua ton tai! !", null);
                }
                var LoaiKhoaHocXoa = appDBContext.LoaiKhoaHocs.Find(request.LoaiKhoaHocID);
                appDBContext.LoaiKhoaHocs.Remove(LoaiKhoaHocXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(LoaiKhoaHocXoa));
            }

        }

    }
}

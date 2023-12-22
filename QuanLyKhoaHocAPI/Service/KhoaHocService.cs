using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<KhoaHocDTO> responseObject;
        private readonly KhoaHocConverter converter;
        public KhoaHocService()
        {
            appDBContext = new AppDBContext();
            converter = new KhoaHocConverter();
            responseObject = new ResponseObject<KhoaHocDTO>();
        }



        public ResponseObject<KhoaHocDTO> ThemKhoaHoc(ThemKhoaHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkKhoaHoc = appDBContext.KhoaHocs.FirstOrDefault(x => x.TenKhoaHoc == request.TenKhoaHoc);
                if (checkKhoaHoc != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Khoa hoc da ton tai !", null);
                }          
                var checkLoaiKhoaHoc = appDBContext.LoaiKhoaHocs.FirstOrDefault(x => x.LoaiKhoaHocID == request.LoaiKhoaHocID);
                if (checkLoaiKhoaHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Loai khoa hoc ID chua ton tai !", null);
                }
                KhoaHoc KhoaHocThem = converter.ThemKhoaHoc(request);
                appDBContext.KhoaHocs.Add(KhoaHocThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(KhoaHocThem));
            }

        }
        
        

        public ResponseObject<KhoaHocDTO> SuaKhoaHoc(SuaKhoaHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkKhoaHoc = appDBContext.KhoaHocs.FirstOrDefault(x => x.KhoaHocID == request.KhoaHocID);
                if (checkKhoaHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Khoa hoc chua ton tai! !", null);
                }
                var checkLoaiKhoaHoc = appDBContext.KhoaHocs.Include(x => x.LoaiKhoaHoc).FirstOrDefault(x => x.LoaiKhoaHocID == request.LoaiKhoaHocID);
                if (checkLoaiKhoaHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Loai khoa hoc ID chua ton tai !", null);
                }
                KhoaHoc KhoaHocSua = converter.SuaKhoaHoc(checkKhoaHoc, request);
                appDBContext.KhoaHocs.Update(KhoaHocSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(KhoaHocSua));
            }
        }

        public ResponseObject<KhoaHocDTO> XoaKhoaHoc(XoaKhoaHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkKhoaHoc = appDBContext.KhoaHocs.FirstOrDefault(x => x.KhoaHocID == request.KhoaHocID);
                if (checkKhoaHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khoa hoc chua ton tai! !", null);
                }
               
                var KhoaHocXoa = appDBContext.KhoaHocs.Find(request.KhoaHocID);
                appDBContext.KhoaHocs.Remove(KhoaHocXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(KhoaHocXoa));
            }
        }

        public PageResult<KhoaHocDTO> LayKhoaHoc(LayKhoaHoc request)
        {
            var lstKhoaHoc = appDBContext.KhoaHocs.AsQueryable();
            if (!request.NameKeyWord.IsNullOrEmpty())
            {
                lstKhoaHoc = appDBContext.KhoaHocs.Where(x => x.TenKhoaHoc.ToLower().Contains(request.NameKeyWord.ToLower()));
            }
            if (lstKhoaHoc.Count() == 0)
            {
                throw new Exception("Không tìm thấy khoa hoc nào theo yêu cầu !");
            }
            Pagination pagination = new Pagination();
            pagination.PageNumber = request.PageNumber;
            pagination.PageSize = request.PageSize;
            var res = PageResult<KhoaHocDTO>.ToPageResult(pagination, lstKhoaHoc.Select(x => converter.EntityToDTO(x)));
            pagination.TotalCount = res.Count();
            return new PageResult<KhoaHocDTO>(pagination, res);
        }
    }
}


using Microsoft.IdentityModel.Tokens;
using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.HocVien;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class HocVienService : IHocVienService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<HocVienDTO> responseObject;
        private readonly HocVienConverter converter;
        public HocVienService()
        {
            appDBContext = new AppDBContext();
            converter = new HocVienConverter();
            responseObject = new ResponseObject<HocVienDTO>();
        }
        public PageResult<HocVienDTO> LayHocVien(LayHocVienRequest request)
        {
            var lstHocVien = appDBContext.HocViens.AsQueryable();
            if (!request.NameKeyWord.IsNullOrEmpty())
            {
                lstHocVien = lstHocVien.Where(x => x.HoTen.ToLower().Contains(request.NameKeyWord.ToLower()));
            }
            if (!request.EmailKeyWord.IsNullOrEmpty())
            {
                lstHocVien = lstHocVien.Where(x => x.Email.ToLower().Contains(request.EmailKeyWord.ToLower()));
            }
            if (lstHocVien.Count() == 0)
            {
                throw new Exception("Không tìm thấy hoc vien nào theo yêu cầu !");
            }
            Pagination pagination = new Pagination();
            pagination.PageNumber = request.PageNumber;
            pagination.PageSize = request.PageSize;
            var res = PageResult<HocVienDTO>.ToPageResult(pagination, lstHocVien.Select(x => converter.EntityToDTO(x)));
            pagination.TotalCount = res.Count();
            return new PageResult<HocVienDTO>(pagination, res);
        }

        public ResponseObject<HocVienDTO> SuaHocVien(SuaHocVienRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkHocVien = appDBContext.HocViens.FirstOrDefault(x => x.HocVienID == request.HocVienID);
                if (checkHocVien == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Hoc vien chua ton tai! !", null);
                }
                HocVien hocvienSua = converter.SuaHocVien(checkHocVien, request);
                appDBContext.HocViens.Update(hocvienSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(hocvienSua));
            }
        }

        public ResponseObject<HocVienDTO> ThemHocVien(ThemHocVienRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkHocVien = appDBContext.HocViens.Any(x => x.Email == request.Email
                                                                        ||x.SDT == request.SDT);
                if (checkHocVien )
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Hoc vien da ton tai !", null);
                }
                HocVien HocVienThem = converter.ThemHocVien(request);
                appDBContext.HocViens.Add(HocVienThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(HocVienThem));
            }
        }

        public ResponseObject<HocVienDTO> XoaHocVien(XoaHocVienRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkHocVien = appDBContext.HocViens.FirstOrDefault(x => x.HocVienID == request.HocVienID);
                if (checkHocVien == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, "Hoc vien chua ton tai! !", null);
                }
                var hocvienXoa = appDBContext.HocViens.Find(request.HocVienID);
                appDBContext.HocViens.Remove(hocvienXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(hocvienXoa));
            }
        }
    }
}

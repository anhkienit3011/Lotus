using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class TaiKhoanService:iTaiKhoanService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<TaiKhoanDTO> responseObject;
        private readonly TaiKhoanConverter converter;
        public TaiKhoanService()
        {
            appDBContext = new AppDBContext();
            converter = new TaiKhoanConverter();
            responseObject = new ResponseObject<TaiKhoanDTO>();
        }



        public ResponseObject<TaiKhoanDTO> ThemTaiKhoan(ThemTaiKhoanRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkTaiKhoan = appDBContext.TaiKhoans.FirstOrDefault(x => x.Tai_Khoan == request.Tai_Khoan);
                if (checkTaiKhoan != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Ten tai khoan da ton tai !", null);
                }
                var checkQuyenHan = appDBContext.QuyenHans.FirstOrDefault(x=> x.QuyenHanID==request.QuyenHanId);
                if (checkQuyenHan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Quyen han chua ton tai !", null);
                }
                TaiKhoan taikhoanThem = converter.ThemTaiKhoan(request);
                appDBContext.TaiKhoans.Add(taikhoanThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(taikhoanThem));
            }

        }



        public ResponseObject<TaiKhoanDTO> SuaTaiKhoan(SuaTaiKhoanRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkTaiKhoan = appDBContext.TaiKhoans.FirstOrDefault(x => x.TaiKhoanID == request.TaiKhoanID);
                if (checkTaiKhoan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tai khoan chua ton tai! !", null);
                }
                var checkQuyenHan = appDBContext.TaiKhoans.Include(x => x.QuyenHans).FirstOrDefault(x => x.QuyenHanId == request.QuyenHanId);
                if (checkQuyenHan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Quyen han chua ton tai !", null);
                }
                TaiKhoan taikhoanSua = converter.SuaTaiKhoan(checkTaiKhoan, request);
                appDBContext.TaiKhoans.Update(taikhoanSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(taikhoanSua));
            }
        }

        public ResponseObject<TaiKhoanDTO> XoaTaiKhoan(XoaTaiKhoanRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkTaiKhoan = appDBContext.TaiKhoans.FirstOrDefault(x => x.TaiKhoanID == request.TaiKhoanID);
                if (checkTaiKhoan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tai khoan chua ton tai! !", null);
                }
                var taikhoanXoa = appDBContext.TaiKhoans.Find(request.TaiKhoanID);
                appDBContext.TaiKhoans.Remove(taikhoanXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(taikhoanXoa));
            }
        }

        public PageResult<TaiKhoanDTO> LayTaiKhoan(LayTaiKhoanRequest request)
        {
            var lstTaiKhoan = appDBContext.TaiKhoans.Where(x => x.Tai_Khoan.ToLower().Contains(request.NameKeyWord.ToLower())).AsQueryable();
            if (lstTaiKhoan.Count() == 0)
            {
                throw new Exception("Không tìm thấy tai khoan nào theo yêu cầu !");
            }
            Pagination pagination = new Pagination();
            pagination.PageNumber = request.PageNumber;
            pagination.PageSize = request.PageSize;
            var res = PageResult<TaiKhoanDTO>.ToPageResult(pagination, lstTaiKhoan.Select(x => converter.EntityToDTO(x)));
            pagination.TotalCount = res.Count();
            return new PageResult<TaiKhoanDTO>(pagination, res);
        }

        
    }
}

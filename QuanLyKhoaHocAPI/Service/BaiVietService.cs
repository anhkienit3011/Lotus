using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.BaiViet;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class BaiVietService :iBaiVietService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<BaiVietDTO> responseObject;
        private readonly BaiVietConverter converter;
        public BaiVietService()
        {
            appDBContext = new AppDBContext();
            converter = new BaiVietConverter();
            responseObject = new ResponseObject<BaiVietDTO>();
        }



        public ResponseObject<BaiVietDTO> ThemBaiViet(ThemBaiVietRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkBaiViet = appDBContext.BaiViets.FirstOrDefault(x => x.TenBaiViet == request.TenBaiViet);
                if (checkBaiViet != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Bai viet da ton tai !", null);
                }
                var checkChuDe = appDBContext.BaiViets.Include(x => x.ChuDe).FirstOrDefault(x => x.ChuDeID == request.ChuDeID);
                if (checkChuDe == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Chu de chua ton tai !", null);
                }
                var checkTaiKhoan = appDBContext.BaiViets.Include(x => x.TaiKhoan).FirstOrDefault(x => x.TaiKhoanID == request.TaiKhoanID);
                if (checkTaiKhoan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tai khoan ID chua ton tai !", null);
                }
                BaiViet baivietThem = converter.ThemBaiViet(request);
                appDBContext.BaiViets.Add(baivietThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(baivietThem));
            }

        }



        public ResponseObject<BaiVietDTO> SuaBaiViet(SuaBaiVietRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkBaiViet = appDBContext.BaiViets.FirstOrDefault(x => x.BaiVietID == request.BaiVietID);
                if (checkBaiViet == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Bai viet chua ton tai! !", null);
                }
                var checkChuDe = appDBContext.BaiViets.Include(x => x.ChuDe).FirstOrDefault(x => x.ChuDeID == request.ChuDeID);
                if (checkChuDe == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Chu de chua ton tai !", null);
                }
                var checkTaiKhoan = appDBContext.BaiViets.Include(x => x.TaiKhoan).FirstOrDefault(x => x.TaiKhoanID == request.TaiKhoanID);
                if (checkTaiKhoan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tai khoan ID chua ton tai !", null);
                }
                BaiViet baivietSua = converter.SuaBaiViet(checkBaiViet, request);
                appDBContext.BaiViets.Update(baivietSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(baivietSua));
            }
        }

        public ResponseObject<BaiVietDTO> XoaBaiViet(XoaBaiVietRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkBaiViet = appDBContext.BaiViets.FirstOrDefault(x => x.BaiVietID == request.BaiVietID);
                if (checkBaiViet == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Bai viet chua ton tai! !", null);
                }
                var baivietXoa = appDBContext.BaiViets.Find(request.BaiVietID);
                appDBContext.BaiViets.Remove(baivietXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(baivietXoa));
            }
        }

        public PageResult<BaiVietDTO> LayBaiViet(LayBaiVietRequest request)
        {
            var lstBaiViet = appDBContext.BaiViets.Where(x=> x.TenBaiViet.ToLower().Contains(request.NameKeyWord.ToLower())).AsQueryable();
            if (lstBaiViet.Count() == 0)
            {
                throw new Exception("Không tìm thấy chu de nao !");
            }
            Pagination pagination = new Pagination();
            pagination.PageNumber = request.PageNumber;
            pagination.PageSize = request.PageSize;
            var res = PageResult<BaiVietDTO>.ToPageResult(pagination, lstBaiViet.Select(x => converter.EntityToDTO(x)));
            pagination.TotalCount = res.Count();
            return new PageResult<BaiVietDTO>(pagination, res);
        }

       
    }
}

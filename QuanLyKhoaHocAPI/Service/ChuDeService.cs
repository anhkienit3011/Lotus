using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;
using QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan;
using QuanLyKhoaHocAPI.PayLoad.Request.TInhTrangHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class ChuDeService : iChuDeService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<ChuDeDTO> responseObject;
        private readonly ChuDeConverter converter;
        public ChuDeService()
        {
            appDBContext = new AppDBContext();
            converter = new ChuDeConverter();
            responseObject = new ResponseObject<ChuDeDTO>();
        }



        public ResponseObject<ChuDeDTO> ThemChuDe(ThemChuDeRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkChuDe = appDBContext.ChuDes.FirstOrDefault(x => x.TenChuDe == request.TenChuDe);
                //var checkLoaiBaiViet = appDBContext.LoaiBaiViets.FirstOrDefault(x=> x.LoaiBaiVietID == request.LoaiBaiVietID);
                
                if (checkChuDe != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Chu de da ton tai !", null);
                }
                var checkLoaiBaiViet = appDBContext.ChuDes.Include(x => x.LoaiBaiViet).FirstOrDefault(x => x.LoaiBaiVietID == request.LoaiBaiVietID);
                if (checkLoaiBaiViet == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Loai bai viet chua ton tai !", null);
                }
                ChuDe chudeThem = converter.ThemChuDe(request);
                appDBContext.ChuDes.Add(chudeThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(chudeThem));
            }

        }



        public ResponseObject<ChuDeDTO> SuaChuDe(SuaChuDeRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkChuDe = appDBContext.ChuDes.FirstOrDefault(x => x.ChuDeID == request.ChuDeID);
                if (checkChuDe == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Chu de chua ton tai! !", null);
                }
                var checkLoaiBaiViet = appDBContext.ChuDes.Include(x => x.LoaiBaiViet).FirstOrDefault(x => x.LoaiBaiVietID == request.LoaiBaiVietID);
                if (checkLoaiBaiViet == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Loai bai viet chua ton tai !", null);
                }
                ChuDe chudeSua = converter.SuaChuDe(checkChuDe, request);
                appDBContext.ChuDes.Update(chudeSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(chudeSua));
            }
        }

        public ResponseObject<ChuDeDTO> XoaChuDe(XoaChuDeRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkChuDe = appDBContext.ChuDes.FirstOrDefault(x => x.ChuDeID == request.ChuDeID);
                if (checkChuDe == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Chu de chua ton tai! !", null);
                }
                var chudeXoa = appDBContext.ChuDes.Find(request.ChuDeID);
                appDBContext.ChuDes.Remove(chudeXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(chudeXoa));
            }
        }

        public PageResult<ChuDeDTO> LayChuDe(LayChuDeRequest request)
        {
            var lstChuDe = appDBContext.ChuDes.AsQueryable();
            if (lstChuDe.Count() == 0)
            {
                throw new Exception("Không tìm thấy chu de nao !");
            }
            Pagination pagination = new Pagination();
            pagination.PageNumber = request.PageNumber;
            pagination.PageSize = request.PageSize;
            var res = PageResult<ChuDeDTO>.ToPageResult(pagination, lstChuDe.Select(x => converter.EntityToDTO(x)));
            pagination.TotalCount = res.Count();
            return new PageResult<ChuDeDTO>(pagination, res);
        }
    }
}

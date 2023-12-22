using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiBaiVIet;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class LoaiBaiVietService :iLoaiBaiVietService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<LoaiBaiVietDTO> responseObject;
        private readonly LoaiBaiVietConverter converter;
        public LoaiBaiVietService()
        {
            appDBContext = new AppDBContext();
            converter = new LoaiBaiVietConverter();
            responseObject = new ResponseObject<LoaiBaiVietDTO>();
        }



        public ResponseObject<LoaiBaiVietDTO> ThemLoaiBaiViet(ThemLoaiBaiVietRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkLoaibaiViet = appDBContext.LoaiBaiViets.FirstOrDefault(x => x.TenLoai == request.TenLoai);
                if (checkLoaibaiViet != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Loai bai viet da ton tai !", null);
                }
                LoaiBaiViet loaibaivietThem = converter.ThemLoaiBaiViet(request);
                appDBContext.LoaiBaiViets.Add(loaibaivietThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(loaibaivietThem));
            }

        }



        public ResponseObject<LoaiBaiVietDTO> SuaLoaiBaiViet(SuaLoaiBaiVietRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkLoaibaiViet = appDBContext.LoaiBaiViets.FirstOrDefault(x => x.LoaiBaiVietID == request.LoaiBaiVietID);
                if (checkLoaibaiViet == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Loai bai viet chua ton tai! !", null);
                }
                LoaiBaiViet loaibaivietSua = converter.SuaLoaiBaiViet(checkLoaibaiViet, request);
                appDBContext.LoaiBaiViets.Update(loaibaivietSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(loaibaivietSua));
            }
        }

        public ResponseObject<LoaiBaiVietDTO> XoaLoaiBaiViet(XoaLoaiBaiVietRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkLoaibaiViet = appDBContext.LoaiBaiViets.FirstOrDefault(x => x.LoaiBaiVietID == request.LoaiBaiVietID);
                if (checkLoaibaiViet == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Loai bai viet chua ton tai! !", null);
                }
                var loaibaivietXoa = appDBContext.LoaiBaiViets.Find(request.LoaiBaiVietID);
                appDBContext.LoaiBaiViets.Remove(loaibaivietXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(loaibaivietXoa));
            }
        }

        public PageResult<LoaiBaiVietDTO> LayLoaiBaiViet(LayLoaiBaiVietRequest request)
        {
            var lstLoaiBaiViet = appDBContext.LoaiBaiViets.AsQueryable();
            if (lstLoaiBaiViet.Count() == 0)
            {
                throw new Exception("Không tìm thấy loai bai viet nao !");
            }
            Pagination pagination = new Pagination();
            pagination.PageNumber = request.PageNumber;
            pagination.PageSize = request.PageSize;
            var res = PageResult<LoaiBaiVietDTO>.ToPageResult(pagination, lstLoaiBaiViet.Select(x => converter.EntityToDTO(x)));
            pagination.TotalCount = res.Count();
            return new PageResult<LoaiBaiVietDTO>(pagination, res);
        }

        
    }
}

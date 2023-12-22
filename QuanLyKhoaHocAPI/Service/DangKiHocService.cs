using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHocAPI.AppDBContexxt;
using QuanLyKhoaHocAPI.Convert;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.DTOs;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;
using QuanLyKhoaHocAPI.PayLoad.Request.DangKiHoc;
using QuanLyKhoaHocAPI.PayLoad.Response;

namespace QuanLyKhoaHocAPI.Service
{
    public class DangKiHocService :iDangKiHocService
    {
        private readonly AppDBContext appDBContext;
        private readonly ResponseObject<DangKiHocDTO> responseObject;
        private readonly DangKiHocConverter converter;
        public DangKiHocService()
        {
            appDBContext = new AppDBContext();
            converter = new DangKiHocConverter();
            responseObject = new ResponseObject<DangKiHocDTO>();
        }
        public static DateTime CalculateCourseEndTime(DateTime startTime,int month)
        {
            return startTime.AddMonths(month);
        }



        public ResponseObject<DangKiHocDTO> ThemDangKiHoc(ThemDangKiHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkDangKiHoc = appDBContext.DangKiHocs.FirstOrDefault(x => x.KhoaHocID == request.KhoaHocID
                                                                                && x.HocVienID == request.HocVienID);
                if (checkDangKiHoc != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Dang ki da ton tai !", null);
                }
                var checkKhoaHoc = appDBContext.KhoaHocs.FirstOrDefault(x => x.KhoaHocID == request.KhoaHocID);
                if (checkKhoaHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " khoa hoc ID chua ton tai !", null);
                }
                var checkHocVien = appDBContext.HocViens.FirstOrDefault(x => x.HocVienID == request.HocVienID);
                if (checkHocVien == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Hoc vien ID chua ton tai !", null);
                }
                var checkTinhTrangHoc = appDBContext.TinhTrangHocs.FirstOrDefault(x => x.TinhTrangHocID == request.KhoaHocID);            
                var check = appDBContext.TinhTrangHocs.FirstOrDefault(x=> x.TenTinhTrang == "Chờ duyệt");
                
                DangKiHoc DangKiHocThem = converter.ThemDangKiHoc(request);
                DangKiHocThem.TinhTrangHocID = check.TinhTrangHocID;
                appDBContext.DangKiHocs.Add(DangKiHocThem);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Them thanh cong ", converter.EntityToDTO(DangKiHocThem));
            }

        }



        public ResponseObject<DangKiHocDTO> SuaDangKiHoc(SuaDangKiHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkDangKiHoc = appDBContext.DangKiHocs.FirstOrDefault(x => x.ID == request.ID);
                if (checkDangKiHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Dang ki chua chua ton tai! !", null);
                }
                var checkKhoaHoc = appDBContext.KhoaHocs.FirstOrDefault(x => x.KhoaHocID == request.KhoaHocID);
                if (checkKhoaHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " khoa hoc ID chua ton tai !", null);
                }
                var checkHocVien = appDBContext.HocViens.FirstOrDefault(x => x.HocVienID == request.HocVienID);
                if (checkHocVien == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Hoc vien ID chua ton tai !", null);
                }
                var checkTinhTrangHocID = appDBContext.TinhTrangHocs.FirstOrDefault(x => x.TinhTrangHocID == request.TinhTrangHocID);
                if (checkTinhTrangHocID == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tinh trang hoc ID chua ton tai !", null);
                }
                var checkTaiKhoan = appDBContext.TaiKhoans.FirstOrDefault(x => x.TaiKhoanID == request.TaiKhoanID);
                if (checkTaiKhoan == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Tai khoan ID chua ton tai !", null);
                }
                //var joinColumn = appDBContext.DangKiHocs.Include(x => x.TinhTrangHoc).Include(x => x.KhoaHoc)
                var checkTinhTrangHoc =  appDBContext.TinhTrangHocs.FirstOrDefault(x => x.TenTinhTrang == "Đang học chính");
                //var checkKhoaHoc = appDBContext.DangKiHocs.Include(x => x.KhoaHoc).FirstOrDefault(x=> x.KhoaHocID == request.KhoaHocID);
                DangKiHoc dangkihocSua = converter.SuaDangKiHoc(checkDangKiHoc, request);
                if (dangkihocSua.TinhTrangHocID == checkTinhTrangHoc.TinhTrangHocID)
                {
                    dangkihocSua.NgaybatDau = DateTime.Now;
                    dangkihocSua.NgayKetThuc = CalculateCourseEndTime(DateTime.Now, int.Parse(checkKhoaHoc.ThoiGianHoc.ToString()));
                    checkKhoaHoc.SoHocVien += 1;
                }
                appDBContext.KhoaHocs.Update(checkKhoaHoc);
                appDBContext.DangKiHocs.Update(dangkihocSua);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Sua thanh cong ", converter.EntityToDTO(dangkihocSua));
            }
        }

        public ResponseObject<DangKiHocDTO> XoaDangKiHoc(XoaDangKiHocRequest request)
        {
            using (var trans = appDBContext.Database.BeginTransaction())
            {
                var checkDangKiHoc = appDBContext.DangKiHocs.FirstOrDefault(x => x.ID == request.ID);
                if (checkDangKiHoc == null)
                {
                    return responseObject.ResponseError(StatusCodes.Status404NotFound, " Dang ki chua chua ton tai! !", null);
                }
                var dangkihocXoa = appDBContext.DangKiHocs.Find(request.ID);
                appDBContext.DangKiHocs.Remove(dangkihocXoa);
                appDBContext.SaveChanges();
                trans.Commit();
                return responseObject.ResponseSuccess("Xoa thanh cong ", converter.EntityToDTO(dangkihocXoa));
            }
        }

        public PageResult<DangKiHocDTO> LayDangKihoc(LayDangKiHocRequest request)
        {
            var lstDangKi = appDBContext.DangKiHocs.AsQueryable();
            if (lstDangKi.Count() == 0)
            {
                throw new Exception("Không tìm thấy chu de nao !");
            }
            Pagination pagination = new Pagination();
            pagination.PageNumber = request.PageNumber;
            pagination.PageSize = request.PageSize;
            var res = PageResult<DangKiHocDTO>.ToPageResult(pagination, lstDangKi.Select(x => converter.EntityToDTO(x)));
            pagination.TotalCount = res.Count();
            return new PageResult<DangKiHocDTO>(pagination, res);
        }

        
       
    }

}

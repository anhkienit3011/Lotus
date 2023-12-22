using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.BaiViet;
using QuanLyKhoaHocAPI.PayLoad.Request.DangKiHoc;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class DangKiHocController : ControllerBase
    {
        private readonly iDangKiHocService iDangKiHoc;
        public DangKiHocController()
        {
            iDangKiHoc = new DangKiHocService();
        }
        [HttpPost("themDangKiHoc")]
        public IActionResult ThemDangKihoc(ThemDangKiHocRequest request)
        {
            return Ok(iDangKiHoc.ThemDangKiHoc(request));
        }
        [HttpPost("suaDangKihoc")]
        public IActionResult SuaDangKiHoc(SuaDangKiHocRequest request)
        {
            return Ok(iDangKiHoc.SuaDangKiHoc(request));
        }
        [HttpPost("xoaDangKihoc")]
        public IActionResult XoaDangKiHoc(XoaDangKiHocRequest request)
        {
            return Ok(iDangKiHoc.XoaDangKiHoc(request));
        }
        [HttpPost("layDangKiHoc")]
        public IActionResult LayDangKiHoc(LayDangKiHocRequest request)
        {
            return Ok(iDangKiHoc.LayDangKihoc(request));
        }
    }
}

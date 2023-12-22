using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class KhoaHocController : ControllerBase
    {
        private readonly IKhoaHocService iKhoaHoc;
        public KhoaHocController()
        {
            iKhoaHoc = new KhoaHocService();
        }
        [HttpPost("themkhoahoc")]
        public IActionResult ThemHoaDon([FromBody] ThemKhoaHocRequest request)
        {
            return Ok(iKhoaHoc.ThemKhoaHoc(request));
        }
        [HttpPost("suakhoahoc")]
        public IActionResult SuaKhoaHoc(SuaKhoaHocRequest request)
        {
            return Ok(iKhoaHoc.SuaKhoaHoc(request));
        }
        [HttpPost("xoakhoahoc")]
        public IActionResult XoaKhoaHoc(XoaKhoaHocRequest request)
        {
            return Ok(iKhoaHoc.XoaKhoaHoc(request));
        }
        [HttpPost("LayKhoaHoc")]
        public IActionResult LayKhoaHoc(LayKhoaHoc request)
        {
            return Ok(iKhoaHoc.LayKhoaHoc(request));
        }
    }
}

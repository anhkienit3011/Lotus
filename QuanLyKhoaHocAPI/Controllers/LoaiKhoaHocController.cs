using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;
using QuanLyKhoaHocAPI.Service;
using Microsoft.AspNetCore.Http;
using QuanLyKhoaHocAPI.PayLoad.Response;
using QuanLyKhoaHocAPI.PayLoad.DTOs;

namespace QuanLyKhoaHocAPI.Controllers
{
    
    public class LoaiKhoaHocController : ControllerBase
    {
        private readonly ILoaiKhoaHocService iLoaiKhoaHoc;
        public LoaiKhoaHocController()
        {
            iLoaiKhoaHoc = new LoaiKhoaHocService();
        }
        [HttpPost("themloaikhoahoc")]
        public IActionResult ThemLoaiKhoaHoc( ThemLoaiKhoaHocRequest request)
        {
            return Ok(iLoaiKhoaHoc.ThemLoaiKhoaHoc(request));
        }
        [HttpPost("sualoaiKhoahoc")]
        public IActionResult SuaLoaiKhoaHoc(SuaLoaiKhoaHocRequest request)
        {
            return Ok(iLoaiKhoaHoc.SuaLoaiKhoaHoc(request));
        }
        [HttpPost("xoaloaiKhoahoc")]
        public IActionResult XoaLoaiKhoaHoc(XoaLoaiKhoaHocRequest request)
        {
            return Ok(iLoaiKhoaHoc.XoaLoaiKhoaHoc(request));
        }

    }
}

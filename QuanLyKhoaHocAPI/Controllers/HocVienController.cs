using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.HocVien;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class HocVienController:ControllerBase
    {
        private readonly IHocVienService iHocVien;
        public HocVienController()
        {
            iHocVien = new HocVienService();
        }
        [HttpPost("themhocvien")]
        public IActionResult ThemHocVien(ThemHocVienRequest request)
        {
            return Ok(iHocVien.ThemHocVien(request));
        }
        [HttpPost("suahocvien")]
        public IActionResult SuaHocVien(SuaHocVienRequest request)
        {
            return Ok(iHocVien.SuaHocVien(request));
        }
        [HttpPost("xoahocvien")]
        public IActionResult XoaHocVien(XoaHocVienRequest request)
        {
            return Ok(iHocVien.XoaHocVien(request));
        }
        [HttpPost("LayHocVien")]
        public IActionResult LayHocVien(LayHocVienRequest request)
        {
            return Ok(iHocVien.LayHocVien(request));
        }
    }
}

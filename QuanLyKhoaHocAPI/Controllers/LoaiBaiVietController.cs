using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiBaiVIet;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class LoaiBaiVietController:ControllerBase
    {
        private readonly iLoaiBaiVietService iLoaiBaiViet;
        public LoaiBaiVietController()
        {
            iLoaiBaiViet = new LoaiBaiVietService();
        }
        [HttpPost("themloaibaiviet")]
        public IActionResult ThemLoaiBaiViet(ThemLoaiBaiVietRequest request)
        {
            return Ok(iLoaiBaiViet.ThemLoaiBaiViet(request));
        }
        [HttpPost("suaLoaiBaiViet")]
        public IActionResult SuaLoaiBaiViet(SuaLoaiBaiVietRequest request)
        {
            return Ok(iLoaiBaiViet.SuaLoaiBaiViet(request));
        }
        [HttpPost("xoaloaiBaiViet")]
        public IActionResult XoaLoaiBaiViet(XoaLoaiBaiVietRequest request)
        {
            return Ok(iLoaiBaiViet.XoaLoaiBaiViet(request));
        }
        public IActionResult LayLoaiBaiViet(LayLoaiBaiVietRequest request)
        {
            return Ok(iLoaiBaiViet.LayLoaiBaiViet(request));
        }
    }
}

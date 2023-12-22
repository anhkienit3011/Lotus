using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.BaiViet;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class BaiVietController : ControllerBase
    {
        private readonly iBaiVietService iBaiViet;
        public BaiVietController()
        {
            iBaiViet = new BaiVietService();
        }
        [HttpPost("themBaiViet")]
        public IActionResult ThemBaiViet(ThemBaiVietRequest request)
        {
            return Ok(iBaiViet.ThemBaiViet(request));
        }
        [HttpPost("suaBaiViet")]
        public IActionResult SuaBaiViet(SuaBaiVietRequest request)
        {
            return Ok(iBaiViet.SuaBaiViet(request));
        }
        [HttpPost("xoaBaiViet")]
        public IActionResult XoaBaiViet(XoaBaiVietRequest request)
        {
            return Ok(iBaiViet.XoaBaiViet(request));
        }
        [HttpPost("layBaiViet")]
        public IActionResult LayBaiViet(LayBaiVietRequest request)
        {
            return Ok(iBaiViet.LayBaiViet(request));
        }
    }
}

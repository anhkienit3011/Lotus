using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Entity;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.LoaiKhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.QuyenHanRequest;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class QuyenHanController : ControllerBase
    {
        private readonly iQuyenHanService iQuyenHan;
        public QuyenHanController()
        {
            iQuyenHan = new QuyenHanService();
        }
        [HttpPost("themquyenhan")]
        public IActionResult ThemQuyenHan(ThemQuyenHanRequest request)
        {
            return Ok(iQuyenHan.ThemQuyenHan(request));
        }
        [HttpPost("suaquyenhan")]
        public IActionResult SuaQuyenHan(SuaQuyenHanRequest request)
        {
            return Ok(iQuyenHan.SuaQuyenHan(request));
        }
        [HttpPost("xoaquyenhan")]
        public IActionResult XoaQuyenHan(XoaQuyenHanRequest request)
        {
            return Ok(iQuyenHan.XoaQuyenHan(request));
        }
        [HttpPost("LayQuyenHan")]
        public IActionResult LayQuyenhan(LayQuyenHanRequest request)
        {
            return Ok(iQuyenHan.LayQuyenHan(request));
        }
    }
}

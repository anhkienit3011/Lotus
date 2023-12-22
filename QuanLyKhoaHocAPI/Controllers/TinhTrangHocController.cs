using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.KhoaHoc;
using QuanLyKhoaHocAPI.PayLoad.Request.TInhTrangHoc;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class TinhTrangHocController:ControllerBase
    {
        private readonly ITinhTrangHocService iTinhTrangHoc;
        public TinhTrangHocController()
        {
            iTinhTrangHoc = new TinhTrangHocService();
        }
        [HttpPost("themtinhtrnaghoc")]
        public IActionResult ThemTinhTrangHoc( ThemTinhTrangHocRequest request)
        {
            return Ok(iTinhTrangHoc.ThemTinhTrangHoc(request));
        }
        [HttpPost("suaTinhTrangHoc")]
        public IActionResult SuaTinhTrangHoc(SuaTinhTrangHocRequest request)
        {
            return Ok(iTinhTrangHoc.SuaTinhTrangHoc(request));
        }
        [HttpPost("xoaTinhTrangHoc")]
        public IActionResult XoaTinhTrangHoc(XoaTinhTrangHoc request)
        {
            return Ok(iTinhTrangHoc.XoaTinhTrangHoc(request));
        }
        [HttpPost("LayTinhTrangHoc")]
        public IActionResult LayTinhTrangHoc()
        {
            return Ok(iTinhTrangHoc.LayTinhTrangHoc());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.ChuDe;
using QuanLyKhoaHocAPI.PayLoad.Request.HocVien;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class ChuDeController : ControllerBase
    {
        private readonly iChuDeService iChuDe;
        public ChuDeController()
        {
            iChuDe = new ChuDeService();
        }
        [HttpPost("themchude")]
        public IActionResult ThemHocVien( ThemChuDeRequest request)
        {
            return Ok(iChuDe.ThemChuDe(request));
        }
        [HttpPost("suaChuDe")]
        public IActionResult SuaChuDe(SuaChuDeRequest request)
        {
            return Ok(iChuDe.SuaChuDe(request));
        }
        [HttpPost("xoaChuDe")]
        public IActionResult XoaChuDe(XoaChuDeRequest request)
        {
            return Ok(iChuDe.XoaChuDe(request));
        }
        [HttpPost("layChuDe")]
        public IActionResult LayChuDe(LayChuDeRequest request)
        {
            return Ok(iChuDe.LayChuDe(request));
        }
    }
}

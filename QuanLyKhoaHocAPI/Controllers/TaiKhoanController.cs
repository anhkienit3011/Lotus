using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHocAPI.Interface;
using QuanLyKhoaHocAPI.PayLoad.Request.QuyenHanRequest;
using QuanLyKhoaHocAPI.PayLoad.Request.TaiKhoan;
using QuanLyKhoaHocAPI.Service;

namespace QuanLyKhoaHocAPI.Controllers
{
    public class TaiKhoanController:ControllerBase
    {
        private readonly iTaiKhoanService iTaiKhoan;
        public TaiKhoanController()
        {
            iTaiKhoan = new TaiKhoanService();
        }
        [HttpPost("themtaikhoan")]
        public IActionResult ThemTaiKhoan(ThemTaiKhoanRequest request)
        {
            return Ok(iTaiKhoan.ThemTaiKhoan(request));
        }
        [HttpPost("suaTaiKhoan")]
        public IActionResult SuaTaiKhoan(SuaTaiKhoanRequest request)
        {
            return Ok(iTaiKhoan.SuaTaiKhoan(request));
        }
        [HttpPost("xoaTaiKhoan")]
        public IActionResult XoaTaikhoan(XoaTaiKhoanRequest request)
        {
            return Ok(iTaiKhoan.XoaTaiKhoan(request));
        }
        [HttpPost("LayTaiKhoan")]
        public IActionResult LayTaiKhoan(LayTaiKhoanRequest request)
        {
            return Ok(iTaiKhoan.LayTaiKhoan(request));
        }
    }
}

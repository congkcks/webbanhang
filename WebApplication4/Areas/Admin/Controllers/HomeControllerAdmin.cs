using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace WebApplication4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    public class HomeControllerAdmin : Controller
    {
        private readonly QlbanVaLiContext db;

        public HomeControllerAdmin(QlbanVaLiContext context)
        {
            db = context;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public IActionResult DanhSachSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lssanpham = db.TDanhMucSps.AsNoTracking().OrderBy(p => p.MaSp);
            PagedList<TDanhMucSp> model = new PagedList<TDanhMucSp>(lssanpham, pageNumber, pageSize);
            return View(model);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {


            var bien1 = db.TChatLieus.Select(item => new SelectListItem
            {
                Text = item.ChatLieu,
                Value = item.MaChatLieu.ToString()
            }).ToList();
            ViewBag.MaChatLieu = bien1;

            var bien2 = db.TLoaiDts.Select(item => new SelectListItem
            {
                Text = item.TenLoai,
                Value = item.MaDt.ToString()
            }).ToList();
            ViewBag.MaDt = bien2;

            var bien3 = db.THangSxes.Select(item => new SelectListItem
            {
                Text = item.HangSx,
                Value = item.MaHangSx.ToString()
            }).ToList();
            ViewBag.MaHangSx = bien3;

            var bien4 = db.TLoaiSps.Select(item => new SelectListItem
            {
                Text = item.Loai,
                Value = item.MaLoai.ToString()
            }).ToList();
            ViewBag.MaLoai = bien4;

            var bien5 = db.TQuocGia.Select(item => new SelectListItem
            {
                Text = item.TenNuoc,
                Value = item.MaNuoc.ToString()
            }).ToList();
            ViewBag.MaNuocSx = bien5;

            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sp)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sp);
                db.SaveChanges();
                return RedirectToAction(nameof(DanhSachSanPham));
            }
            var bien1 = db.TChatLieus.Select(item => new SelectListItem
            {
                Text = item.ChatLieu,
                Value = item.MaChatLieu.ToString()
            }).ToList();
            ViewBag.MaChatLieu = bien1;

            var bien2 = db.TLoaiDts.Select(item => new SelectListItem
            {
                Text = item.TenLoai,
                Value = item.MaDt.ToString()
            }).ToList();
            ViewBag.MaDt = bien2;

            var bien3 = db.THangSxes.Select(item => new SelectListItem
            {
                Text = item.HangSx,
                Value = item.MaHangSx.ToString()
            }).ToList();
            ViewBag.MaHangSx = bien3;

            var bien4 = db.TLoaiSps.Select(item => new SelectListItem
            {
                Text = item.Loai,
                Value = item.MaLoai.ToString()
            }).ToList();
            ViewBag.MaLoai = bien4;

            var bien5 = db.TQuocGia.Select(item => new SelectListItem
            {
                Text = item.TenNuoc,
                Value = item.MaNuoc.ToString()
            }).ToList();
            ViewBag.MaNuocSx = bien5;
            return View(sp);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(String id)
        {


            var bien1 = db.TChatLieus.Select(item => new SelectListItem
            {
                Text = item.ChatLieu,
                Value = item.MaChatLieu.ToString()
            }).ToList();
            ViewBag.MaChatLieu = bien1;

            var bien2 = db.TLoaiDts.Select(item => new SelectListItem
            {
                Text = item.TenLoai,
                Value = item.MaDt.ToString()
            }).ToList();
            ViewBag.MaDt = bien2;

            var bien3 = db.THangSxes.Select(item => new SelectListItem
            {
                Text = item.HangSx,
                Value = item.MaHangSx.ToString()
            }).ToList();
            ViewBag.MaHangSx = bien3;

            var bien4 = db.TLoaiSps.Select(item => new SelectListItem
            {
                Text = item.Loai,
                Value = item.MaLoai.ToString()
            }).ToList();
            ViewBag.MaLoai = bien4;

            var bien5 = db.TQuocGia.Select(item => new SelectListItem
            {
                Text = item.TenNuoc,
                Value = item.MaNuoc.ToString()
            }).ToList();
            ViewBag.MaNuocSx = bien5;
            var sanpham=db.TDanhMucSps.Find(id);
            return View(sanpham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sp)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Update(sp);
                db.SaveChanges();
                return RedirectToAction(nameof(DanhSachSanPham));
            }
            var bien1 = db.TChatLieus.Select(item => new SelectListItem
            {
                Text = item.ChatLieu,
                Value = item.MaChatLieu.ToString()
            }).ToList();
            ViewBag.MaChatLieu = bien1;

            var bien2 = db.TLoaiDts.Select(item => new SelectListItem
            {
                Text = item.TenLoai,
                Value = item.MaDt.ToString()
            }).ToList();
            ViewBag.MaDt = bien2;

            var bien3 = db.THangSxes.Select(item => new SelectListItem
            {
                Text = item.HangSx,
                Value = item.MaHangSx.ToString()
            }).ToList();
            ViewBag.MaHangSx = bien3;

            var bien4 = db.TLoaiSps.Select(item => new SelectListItem
            {
                Text = item.Loai,
                Value = item.MaLoai.ToString()
            }).ToList();
            ViewBag.MaLoai = bien4;

            var bien5 = db.TQuocGia.Select(item => new SelectListItem
            {
                Text = item.TenNuoc,
                Value = item.MaNuoc.ToString()
            }).ToList();
            ViewBag.MaNuocSx = bien5;
            return View();
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(String id)
        {
            var bien1 = db.TChatLieus.Select(item => new SelectListItem
            {
                Text = item.ChatLieu,
                Value = item.MaChatLieu.ToString()
            }).ToList();
            ViewBag.MaChatLieu = bien1;

            var bien2 = db.TLoaiDts.Select(item => new SelectListItem
            {
                Text = item.TenLoai,
                Value = item.MaDt.ToString()
            }).ToList();
            ViewBag.MaDt = bien2;

            var bien3 = db.THangSxes.Select(item => new SelectListItem
            {
                Text = item.HangSx,
                Value = item.MaHangSx.ToString()
            }).ToList();
            ViewBag.MaHangSx = bien3;

            var bien4 = db.TLoaiSps.Select(item => new SelectListItem
            {
                Text = item.Loai,
                Value = item.MaLoai.ToString()
            }).ToList();
            ViewBag.MaLoai = bien4;

            var bien5 = db.TQuocGia.Select(item => new SelectListItem
            {
                Text = item.TenNuoc,
                Value = item.MaNuoc.ToString()
            }).ToList();
            ViewBag.MaNuocSx = bien5;
            var sanpham = db.TDanhMucSps.Find(id);
            return View(sanpham);
        }

    }
}

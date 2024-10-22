using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication4.Models;
using X.PagedList;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlbanVaLiContext db = new QlbanVaLiContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lssanpham = db.TDanhMucSps.AsNoTracking().OrderBy(p => p.MaSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lssanpham, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewMoi()
        {
            return View();
        }

        public IActionResult SanPhamTheoLoai(string maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lssanpham = db.TDanhMucSps.AsNoTracking().Where(p => p.MaLoai == maloai).OrderBy(p => p.MaSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lssanpham, pageNumber, pageSize);
            return View(lst);
        }

        [HttpGet]
        public JsonResult TimKiem(string keyword)
        {
            var products = db.TDanhMucSps.AsNoTracking()
                                         .Where(p => p.TenSp.Contains(keyword))
                                         .Select(p => new { label = p.TenSp, value = p.TenSp, id = p.MaSp })
                                         .ToList();
            return Json(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

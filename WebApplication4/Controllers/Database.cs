using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Database : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            var sanpham = (from sp in db.TDanhMucSps
                           select new Product
                           {
                               AnhDaiDien = sp.AnhDaiDien,
                               Gia = sp.GiaLonNhat,
                               MaSp = sp.MaSp,
                               TenSp = sp.TenSp
                           });
            return sanpham;
        }
    }
}

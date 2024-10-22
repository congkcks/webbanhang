using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
namespace WebApplication4.Controllers
{
    public class GioHangController : Controller
    {
        [Route("giohang")]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(TDanhMucSp sp)
        {
            var cart = HttpContext.Session.GetCart();
            var cartItem = cart.FirstOrDefault(p => p.ProductId.Equals(sp.MaSp));

            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = sp.MaSp,
                    ProductName = sp.TenSp ?? string.Empty,
                    Quantity = 1, // Default quantity to 1
                    Price = sp.GiaLonNhat ?? 0,
                    AnhDaiDien=sp.AnhDaiDien,
                });
            }
            else
            {
                cartItem.Quantity += 1; // Increment quantity by 1
            }

            HttpContext.Session.SetCart(cart);
            return RedirectToAction("Index", "GioHang");
        }
    }
}

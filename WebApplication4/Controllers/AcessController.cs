using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
namespace WebApplication4.Controllers
{
    public class AcessController : Controller
    {
        QlbanVaLiContext db=new QlbanVaLiContext();
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("Username")==null)
            {
                return View();
            }
            else
            {

               return RedirectToAction("Index", "Home");

            }
        }
        [HttpPost]
        public IActionResult Login(TUser user)
        {
            var user1 = db.TUsers.Where(p => p.Username == user.Username && p.Password == user.Password).FirstOrDefault();
            if (user1 != null)
            {
                HttpContext.Session.SetString("Username", user1.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login");
        }

    }
}

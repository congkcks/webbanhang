using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using System.Linq;
using System.Diagnostics;
using WebApplication4.Controllers;

public class ProductController : Controller
{
    private readonly QlbanVaLiContext _context;
    public ProductController(QlbanVaLiContext context) // Corrected parameter name
    {
        _context = context; // Assign to class-level variable
    }
   

    public IActionResult ViewMoi(string id)
    {
        var product = _context.TDanhMucSps
            .Include(p => p.MaChatLieuNavigation)
            .Include(p => p.MaDtNavigation)
            .Include(p => p.MaHangSxNavigation)
            .Include(p => p.MaLoaiNavigation)
            .Include(p => p.MaNuocSxNavigation)
            .FirstOrDefault(p => p.MaSp == id); // Convert id to string
        var anhsanpham = _context.TAnhSps.Where(p => p.MaSp == id);// Convert id to string
        ViewBag .anhsanpham = anhsanpham;

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

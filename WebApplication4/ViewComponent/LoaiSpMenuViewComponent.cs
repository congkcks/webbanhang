using Microsoft.AspNetCore.Mvc;
using WebApplication4.PhanTrang;
using System.Linq;
using WebApplication4.Models;

namespace WebApplication4.ViewComponents
{
    public class LoaimenuViewComponent : ViewComponent // Ensure the class name matches the view file path
    {
        private readonly ILoaiSpRepository _loaiSpRepository;
        public LoaimenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSpRepository = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSpRepository.GetAll().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}

using WebApplication4.Models;
namespace WebApplication4.PhanTrang
{
    public interface ILoaiSpRepository
    {
        TLoaiSp GetLoaiSp(string maloaisp);
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(string maloaisp);
        IEnumerable<TLoaiSp> GetAll();

    }
}

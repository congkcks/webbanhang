using WebApplication4.Models;
namespace WebApplication4.PhanTrang
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QlbanVaLiContext _context;
        public LoaiSpRepository(QlbanVaLiContext context)
        {
            _context = context;
        }
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp Delete(string maloaisp)
        {
            throw new NotImplementedException();

        }
        public IEnumerable<TLoaiSp> GetAll()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(string maloaisp)
        {
            return _context.TLoaiSps.Find(maloaisp);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

    }
}

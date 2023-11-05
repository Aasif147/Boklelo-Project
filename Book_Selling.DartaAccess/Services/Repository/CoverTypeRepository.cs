using BookLelo.DartaAccess.Data;
using BookLelo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLelo.DartaAccess.Services.Repository
{
    public class CoverTypeRepository : ICoverTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public CoverTypeRepository(ApplicationDbContext Coverdata)
        {
            _context = Coverdata;
        }
        public void Create(CoverType CoverType)
        {
            _context.CoverType.Add(CoverType);
            _context.SaveChanges();
        }

        public void Edit(CoverType CoverType)
        {
            _context.CoverType.Update(CoverType);
            _context.SaveChanges();

        }

        public void Delete(CoverType id) 
        {
            _context.CoverType.Remove(id);
            _context.SaveChanges();
        }

        public List<CoverType> GetAllProduct()
        {
            var data = _context.CoverType.ToList();
            return data;
        }

        public CoverType GetCoverType(int ID)
        {
            var data=_context.CoverType.Find(ID);
            return data;
        }
    }
}

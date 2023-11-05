using BookLelo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLelo.DartaAccess.Services.Repository
{
    internal interface ICoverTypeRepository
    {
        List<CoverType> GetAllProduct();
        void Create(CoverType coverdata);
        void Edit(CoverType coverdata);
        void Delete(CoverType ID);
        CoverType GetCoverType(int ID);
    }
}

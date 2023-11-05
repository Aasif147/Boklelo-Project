using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLelo.Model;

namespace BookLelo.DartaAccess.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        
        }

        public DbSet<Category>Categories {  get; set; }
        public DbSet<CoverType> CoverType { get; set; }

    }
}

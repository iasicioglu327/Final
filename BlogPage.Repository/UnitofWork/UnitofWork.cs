using BlogPage.Core.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Repository.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;

        public UnitofWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}

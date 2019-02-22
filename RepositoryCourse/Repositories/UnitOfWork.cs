using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryCourse.Models;

namespace RepositoryCourse.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly RepositoryCourseContext _context;

        public UnitOfWork(RepositoryCourseContext context)
        {
            _context = context;
        }

        public ICourse Courses { get; set; }
        public IAutor Autors { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

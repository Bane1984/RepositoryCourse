using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using RepositoryCourse.Models;

namespace RepositoryCourse.Repositories
{
    public class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly RepositoryCourseContext _context;
        private IDbContextTransaction trans;

        public UnitOfWork(RepositoryCourseContext context)
        {
            _context = context;
        }

        public ICourse Courses { get; set; }
        public IAutor Autors { get; set; }


        public void Start()
        {
            trans = _context.Database.BeginTransaction();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Commit()
        {
            trans.Commit();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryCourse.Models;

namespace RepositoryCourse.Repositories
{
    public class RAutor:Repository<Autor>, IAutor
    {
        public RAutor(RepositoryCourseContext context):base(context)
        {
              
        }
        public RepositoryCourseContext RepositoryCourseContext
        {
            get { return _context as RepositoryCourseContext; }
        }

        public Autor GetAutor(int id)
        {
            var uzmi = RepositoryCourseContext.Autors.Include(c => c.Courses).SingleOrDefault(c => c.AutorId == id);
            return uzmi;
        }
    }
}
